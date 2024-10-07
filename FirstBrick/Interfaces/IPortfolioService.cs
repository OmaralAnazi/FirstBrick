namespace FirstBrick.Interfaces;

public interface IPortfolioService
{
    Task<List<string>> getUserInvestmentsAsync(string userId);
    Task<List<string>> getUserInvestmentsAsync(string userId, string fundId);
}
