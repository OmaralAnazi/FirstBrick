using FirstBrick.Data;
using FirstBrick.Entities;
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

    public async Task<Wallet> CreateWalletAsync(string userId)
    {
        var wallet = new Wallet { AppUserId = userId, Balance = 0 };
        await _context.Wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<Wallet> DepositAsync(string userId, double amount)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId) ?? throw ApiExceptions.WalletNotFound;
        wallet.Balance += amount;
        await _context.SaveChangesAsync();
        return wallet;
    }

    public async Task<Wallet> FindWalletByUserId(string userId)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId) ?? throw ApiExceptions.WalletNotFound;
        return wallet;
    }

    public async Task<Wallet> WithdrawAsync(string userId, double amount)
    {
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId) ?? throw ApiExceptions.WalletNotFound;

        if (wallet.Balance - amount < 0)
        {
            throw ApiExceptions.InsufficientBalance;
        }

        wallet.Balance -= amount;
        await _context.SaveChangesAsync();
        return wallet;
    }
}
