using FirstBrick.Dtos.Responses;

namespace FirstBrick.Interfaces;

public interface IPaymentService
{
    public Task<BalanceDto> CreateWalletAsync(string userId);
    public Task<BalanceDto> DepositAsync(string userId, double amount);
    public Task<BalanceDto> WithdrawAsync(string userId, double amount);
    public Task<BalanceDto> GetBalanceAsync(string userId);
    
    // TODO: transactions?
}
