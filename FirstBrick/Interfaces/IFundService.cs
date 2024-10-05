using FirstBrick.Dtos.Requests;
using FirstBrick.Dtos.Responses;

namespace FirstBrick.Interfaces;

public interface IFundService
{
    public Task<FundDto> CreateFundAsync(CreateFundDto createFundDto);
    public Task<List<FundDto>> GetAllFundsAsync();
}
