using FirstBrick.Interfaces;
using FirstBrick.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/protfolio")]
[ApiController]
public class PortfolioController(IPortfolioService portfolioService) : BaseController
{
    private readonly IPortfolioService _portfolioService = portfolioService;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetProtolioForCurrentUser()
    {
        return Ok(await _portfolioService.getUserInvestmentsAsync(UserId));
    }

    [HttpGet("{fundId}")]
    [Authorize]
    public async Task<IActionResult> GetProtolioForCurrentUser([FromRoute] string fundId)
    {
        return Ok(await _portfolioService.getUserInvestmentsAsync(UserId, fundId));
    }
}
