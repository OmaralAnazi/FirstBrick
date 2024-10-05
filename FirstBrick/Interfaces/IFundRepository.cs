using FirstBrick.Dtos.Requests;
using FirstBrick.Entities;

namespace FirstBrick.Interfaces;

public interface IFundRepository
{
    public Task<Fund> CreateFundAsync(CreateFundDto createFundDto);
    public Task<List<Fund>> GetAllFundsAsync();
}
