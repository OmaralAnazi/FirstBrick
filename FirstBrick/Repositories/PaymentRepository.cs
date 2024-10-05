using FirstBrick.Data;
using FirstBrick.Entities;
using FirstBrick.Enums;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstBrick.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Wallet> FindWalletByUserId(string userId)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId) ?? throw ApiExceptions.WalletNotFound;
        return wallet;
    }

    public async Task<Wallet> CreateWalletAsync(string userId)
    {
        var wallet = new Wallet { AppUserId = userId, Balance = 0 };
        await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<Wallet> DepositAsync(string userId, double amount)
    {
        var wallet = await FindWalletByUserId(userId);
        wallet.Balance += amount;
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<Wallet> WithdrawAsync(string userId, double amount)
    {
        var wallet = await FindWalletByUserId(userId);

        if (wallet.Balance - amount < 0)
        {
            throw ApiExceptions.InsufficientBalance;
        }

        wallet.Balance -= amount;
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<List<Transaction>> GetTransactionsAsync(string userId)
    {
        var wallet = await FindWalletByUserId(userId);
        var transactions = await _context.Transactions.Where(t => t.WalletId == wallet.Id).ToListAsync();
        return transactions;
    }

    public async Task<Transaction> CreateTransactionAsync(int walletId, TransactionType type, double amount, string description)
    {
        var transaction = new Transaction(walletId, type, amount, description);
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }
}
