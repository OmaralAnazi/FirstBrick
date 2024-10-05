using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;
using FirstBrick.Interfaces;

namespace FirstBrick.Services;

public class FundService(IFundRepository fundRepository) : IFundService
{
    private readonly IFundRepository _fundRepository = fundRepository;

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
}
