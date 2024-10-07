using EasyNetQ;
using FirstBrick.Dtos.Responses;
using FirstBrick.Events;
using FirstBrick.Interfaces;

namespace FirstBrick.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IBus _bus;

    public PaymentService(IPaymentRepository paymentRepository, IBus bus)
    {
        _paymentRepository = paymentRepository;
        _bus = bus;
    }

    public async Task<BalanceDto> CreateWalletAsync(string userId)
    {
        var wallet = await _paymentRepository.CreateWalletAsync(userId);
        return new BalanceDto(wallet);
    }

    public async Task<BalanceDto> DepositAsync(string userId, double amount)
    {
        var wallet = await _paymentRepository.DepositAsync(userId, amount);
        await _paymentRepository.CreateTransactionAsync(wallet.Id, Enums.TransactionType.Deposit, amount, $"Deposit {amount}SAR to the wallet");
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
        await _paymentRepository.CreateTransactionAsync(wallet.Id, Enums.TransactionType.Withdraw, amount, $"Withdraw {amount}SAR from the wallet");
        return new BalanceDto(wallet);
    }

    public async Task HandleInvestAsync(InvestmentRequestedEvent eventMessage)
    {
        Console.WriteLine("HandleInvestAsync - EventMessage: " + eventMessage);
        try
        {
            var wallet = await _paymentRepository.WithdrawAsync(eventMessage.UserId, eventMessage.Amount);
            await _paymentRepository.CreateTransactionAsync(wallet.Id, Enums.TransactionType.Invest, eventMessage.Amount, $"Invested {eventMessage.Amount}SAR from the wallet");
            await _bus.PubSub.PublishAsync(new InvestmentProcessedEvent(eventMessage.InvestmentId, true));
        }
        catch 
        {
            await _bus.PubSub.PublishAsync(new InvestmentProcessedEvent(eventMessage.InvestmentId, false));
        }
    }

    public async Task<PaginatedResponse<TransactionsDto>> GetTransactionsAsync(string userId, int pageNumber, int pageSize)
    {
        var wallet = await _paymentRepository.FindWalletByUserId(userId);
        var paginatedTransactions = await _paymentRepository.GetTransactionsAsync(userId, pageNumber, pageSize);

        var transactionsDto = paginatedTransactions.Items
            .Select(transaction => new TransactionsDto(transaction, wallet))
            .ToList();
        
        return new PaginatedResponse<TransactionsDto>(transactionsDto, paginatedTransactions.TotalCount, pageNumber, pageSize);
    }
}
