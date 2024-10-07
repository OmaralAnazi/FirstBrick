using EasyNetQ;
using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;
using FirstBrick.Events;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;

namespace FirstBrick.Services;

public class FundService(IFundRepository fundRepository, IBus bus) : IFundService
{
    private readonly IFundRepository _fundRepository = fundRepository;
    private readonly IBus _bus = bus;

    public async Task<FundDto> CreateFundAsync(CreateFundDto createFundDto)
    {
        var fund = await _fundRepository.CreateFundAsync(createFundDto);
        return new FundDto(fund);
    }

    public async Task<List<FundDto>> GetAllFundsAsync()
    {
        var funds = await _fundRepository.GetAllFundsAsync();
        var fundDtos = funds.Select(f => new FundDto(f)).ToList();
        return fundDtos;
    }

    public async Task<InvestmentDto> InvestAsync(string userId, FundInvestDto fundInvestDto)
    {
        var fund = await _fundRepository.GetFundByIdAsync(fundInvestDto.FundId);

        var isMoreThanMinimumUnits = fund.MinimumInvestmentUnits <= fundInvestDto.Units;
        if (!isMoreThanMinimumUnits)
        {
            throw ApiExceptions.UnitsBelowMinimum;
        }

        var isThereEnoughUnits = fund.ReservedUnits + fundInvestDto.Units <= fund.TotalUnits;
        if (!isThereEnoughUnits)
        {
            throw ApiExceptions.UnitsExceedAvailable;
        }

        var investment = await _fundRepository.CreateInvestment(userId, fund, fundInvestDto.Units);

        var investmentRequestedEvent = new InvestmentRequestedEvent(investment.Id, userId, investment.Amount);
        await _bus.PubSub.PublishAsync(investmentRequestedEvent);

        return new InvestmentDto(investment, fund);
    }

    public async Task UpdateInvestmentStatusAsync(int investmentId, bool isApproved)
    {
        await _fundRepository.UpdateInvestmentStatusAsync(investmentId, isApproved);
    }
}
