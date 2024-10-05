using FirstBrick.Entities;
using FirstBrick.Enums;

namespace FirstBrick.Interfaces;

public interface IPaymentRepository
{
    Task<Wallet> FindWalletByUserId(string userId);
    Task<Wallet> CreateWalletAsync(string userId);
    Task<Wallet> DepositAsync(string userId, double amount);
    Task<Wallet> WithdrawAsync(string userId, double amount);
    Task<List<Transaction>> GetTransactionsAsync(string userId);
    Task<Transaction> CreateTransactionAsync(int walletId, TransactionType type, double amount, string description);
}
