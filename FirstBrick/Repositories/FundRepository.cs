using FirstBrick.Data;
using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;
using FirstBrick.Interfaces;
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
}
