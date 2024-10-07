using FirstBrick.Dtos.Responses;
using FirstBrick.Entities;
using FirstBrick.Enums;
using FirstBrick.Events;

namespace FirstBrick.Interfaces;

public interface IPaymentRepository
{
    Task<Wallet> FindWalletByUserId(string userId);
    Task<Wallet> CreateWalletAsync(string userId);
    Task<Wallet> DepositAsync(string userId, double amount);
    Task<Wallet> WithdrawAsync(string userId, double amount);
    Task<PaginatedResponse<Transaction>> GetTransactionsAsync(string userId, int pageNumber, int pageSize);
    Task<Transaction> CreateTransactionAsync(int walletId, TransactionType type, double amount, string description);
}
