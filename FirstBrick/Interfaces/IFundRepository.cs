using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;

namespace FirstBrick.Interfaces;

public interface IFundRepository
{
    public Task<Fund> CreateFundAsync(CreateFundDto createFundDto);
    public Task<List<Fund>> GetAllFundsAsync();
    public Task<Fund> GetFundByIdAsync(string id);
    public Task<Investment> CreateInvestment(string userId, Fund fund, int units);
    public Task UpdateInvestmentStatusAsync(int investmentId, bool isApproved);
}
