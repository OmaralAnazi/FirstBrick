using FirstBrick.Entities;

namespace FirstBrick.Interfaces;

public interface IPortfolioRepository
{
    Task<List<Investment>> getUserInvestmentsAsync(string userId);
    Task<List<Investment>> getUserInvestmentsAsync(string userId, string fundId);
}
