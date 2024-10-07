using FirstBrick.Dtos.Responses;

namespace FirstBrick.Interfaces;

public interface IPortfolioService
{
    Task<List<InvestmentDto>> getUserInvestmentsAsync(string userId);
    Task<List<InvestmentDto>> getUserInvestmentsAsync(string userId, string fundId);
}
