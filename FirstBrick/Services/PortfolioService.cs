using FirstBrick.Dtos.Responses;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;

namespace FirstBrick.Services;

public class PortfolioService(IPortfolioRepository portfolioRepository, IFundRepository fundRepository) : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
    private readonly IFundRepository _fundRepository = fundRepository;

    public async Task<List<InvestmentDto>> getUserInvestmentsAsync(string userId)
    {
        // TODO: refactor this, ensure all ur code uses the key id, not the database id ...
        var investments = await _portfolioRepository.getUserInvestmentsAsync(userId);
        var funds = await _fundRepository.GetAllFundsAsync(); // DELETE THIS LATER

        var investmentDtos = investments.Select(i =>
        {
            var fund = funds.FirstOrDefault(f => f.Id == i.FundId) ?? throw ApiExceptions.FundNotFound;
            return new InvestmentDto(i, fund);  
        }).ToList();

        return investmentDtos;
    }


    public async Task<List<InvestmentDto>> getUserInvestmentsAsync(string userId, string fundId)
    {
        var fund = await _fundRepository.GetFundByIdAsync(fundId);
        var investments = await _portfolioRepository.getUserInvestmentsAsync(userId, fundId);
        var investmentDtos = investments.Select(i => new InvestmentDto(i, fund)).ToList();
        return investmentDtos;
    }
}
