using FirstBrick.Data;
using FirstBrick.Entities;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstBrick.Repositories;

public class PortfolioRepository(ApplicationDbContext context) : IPortfolioRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Investment>> getUserInvestmentsAsync(string userId)
    {
        return await _context.Investments.Where(i => i.AppUserId == userId).ToListAsync();
    }

    public async Task<List<Investment>> getUserInvestmentsAsync(string userId, string fundId)
    {
        var fund = await _context.Funds.FirstOrDefaultAsync(f => f.Key == fundId) ?? throw ApiExceptions.FundNotFound;
        return await _context.Investments.Where(i => i.AppUserId == userId && i.FundId == fund.Id).ToListAsync();
    }
}
