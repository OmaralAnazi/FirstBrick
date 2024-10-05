using FirstBrick.Dtos.Responses;
using FirstBrick.Interfaces;

namespace FirstBrick.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<BalanceDto> CreateWalletAsync(string userId)
    {
        var wallet = await _paymentRepository.CreateWalletAsync(userId);
        return new BalanceDto(wallet);
    }

    public async Task<BalanceDto> DepositAsync(string userId, double amount)
    {
        var wallet = await _paymentRepository.DepositAsync(userId, amount);
        return new BalanceDto(wallet);
    }

    public async Task<BalanceDto> GetBalanceAsync(string userId)
    {
        var wallet = await _paymentRepository.FindWalletByUserId(userId);
        return new BalanceDto(wallet);
    }

    public async Task<BalanceDto> WithdrawAsync(string userId, double amount)
    {
        var wallet = await _paymentRepository.WithdrawAsync(userId, amount);
        return new BalanceDto(wallet);
    }
}
