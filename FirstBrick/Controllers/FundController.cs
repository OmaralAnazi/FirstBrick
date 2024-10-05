using FirstBrick.Attributes;
using FirstBrick.Dtos.Requests;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/funds")]
[ApiController]
public class FundController(IFundService fundService) : BaseController
{
    private readonly IFundService _fundService = fundService;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetFunds()
    {
        var fundDtos = await _fundService.GetAllFundsAsync();
        return Ok(fundDtos);
    }

    [HttpPost]
    [RequireAdminRole]
    public async Task<IActionResult> PostFund([FromBody] CreateFundDto creatFundDto)
    {
        var fundDto = await _fundService.CreateFundAsync(creatFundDto);
        return Ok(fundDto);
    }
}
