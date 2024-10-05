using FirstBrick.Dtos.Requests;
using FirstBrick.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstBrick.Controllers;

[Route("api/payment")]
[ApiController]
public class PaymentController : BaseController
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost("withdraw")]
    [Authorize]
    public async Task<IActionResult> WithdrawForCurrentUser([FromBody] WithdrawRequestDto withdrawRequestDto)
    {
        var balanceDto = await _paymentService.WithdrawAsync(UserId, withdrawRequestDto.Amount);
        return Ok(balanceDto);
    }

    [HttpPost("deposit")]
    [Authorize]
    public async Task<IActionResult> DepositForCurrentUser([FromBody] DepositRequestDto depositRequestDto)
    {
        var balanceDto = await _paymentService.DepositAsync(UserId, depositRequestDto.Amount);
        return Ok(balanceDto);
    }

    [HttpGet("balance")]
    [Authorize]
    public async Task<IActionResult> GetBalanceForCurrentUser()
    {
        var balanceDto = await _paymentService.GetBalanceAsync(UserId);
        return Ok(balanceDto);
    }

    [HttpGet("transactions")]
    [Authorize]
    public async Task<IActionResult> GetTransactionsForCurrentUser()
    {
        var transactions = await _paymentService.GetTransactionsAsync(UserId);
        return Ok(transactions);
    }
}
