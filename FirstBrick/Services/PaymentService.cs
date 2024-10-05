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
        await _paymentRepository.CreateTransactionAsync(wallet.Id, Enums.TransactionType.Deposit, amount, "Direct deposit to the wallet");
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
        await _paymentRepository.CreateTransactionAsync(wallet.Id, Enums.TransactionType.Withdraw, amount, "Direct withdraw to the wallet");
        return new BalanceDto(wallet);
    }

    public async Task<List<TransactionsDto>> GetTransactionsAsync(string userId)
    {
        var wallet = await _paymentRepository.FindWalletByUserId(userId);
        var transactions = await _paymentRepository.GetTransactionsAsync(userId);
        return transactions.Select(transaction => new TransactionsDto(transaction, wallet)).ToList();
    }
}
