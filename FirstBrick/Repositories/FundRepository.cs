using FirstBrick.Data;
using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;
using FirstBrick.Exceptions;
using FirstBrick.Interfaces;
using FirstBrick.Types;
using Microsoft.EntityFrameworkCore;

namespace FirstBrick.Repositories;

public class FundRepository(ApplicationDbContext context) : IFundRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Fund> CreateFundAsync(CreateFundDto createFundDto)
    {
        var fund = new Fund(createFundDto);
        await _context.Funds.AddAsync(fund);
        await _context.SaveChangesAsync();
        return fund;
    }

    public async Task<List<Fund>> GetAllFundsAsync()
    {
        return await _context.Funds.ToListAsync();
    }

    public async Task<Fund> GetFundByIdAsync(string id)
    {
        return await _context.Funds.FirstOrDefaultAsync(f => f.Key == id) ?? throw ApiExceptions.FundNotFound;
    }

    public async Task<Investment> CreateInvestment(string userId, Fund fund, int units)
    {
        var investment = new Investment(fund, userId, units);
        await _context.Investments.AddAsync(investment);
        fund.ReservedUnits += units;
        await _context.SaveChangesAsync();
        return investment;
    }

    public async Task UpdateInvestmentStatusAsync(int investmentId, bool isApproved)
    {
        var investment = await _context.Investments.FirstOrDefaultAsync(i => i.Id == investmentId) ?? throw ApiExceptions.InvestmentNotFound;
        investment.status = isApproved ? InvestmentStatusTypes.APPROVED : InvestmentStatusTypes.REJECTED;

        if (!isApproved) 
        {
            var fund = await _context.Funds.FirstOrDefaultAsync(f => f.Id == investment.FundId) ?? throw ApiExceptions.FundNotFound;
            fund.ReservedUnits -= investment.Units;
        }

        await _context.SaveChangesAsync();
    }
}
