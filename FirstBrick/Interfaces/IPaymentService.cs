using FirstBrick.Dtos.Responses;
using FirstBrick.Events;

namespace FirstBrick.Interfaces;

public interface IPaymentService
{
    public Task<BalanceDto> CreateWalletAsync(string userId);
    public Task<BalanceDto> DepositAsync(string userId, double amount);
    public Task<BalanceDto> WithdrawAsync(string userId, double amount);
    Task HandleInvestAsync(InvestmentRequestedEvent eventMessage);
    public Task<BalanceDto> GetBalanceAsync(string userId);
    public Task<PaginatedResponse<TransactionsDto>> GetTransactionsAsync(string userId, int pageNumber, int pageSize);
}
