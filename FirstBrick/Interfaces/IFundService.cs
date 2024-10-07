using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;

namespace FirstBrick.Interfaces;

public interface IFundService
{
    public Task<FundDto> CreateFundAsync(CreateFundDto createFundDto);
    public Task<List<FundDto>> GetAllFundsAsync();
    public Task<InvestmentDto> InvestAsync(string userId, FundInvestDto fundInvestDto);
    public Task UpdateInvestmentStatusAsync(int investmentId, bool isApproved);
}
