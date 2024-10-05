using FirstBrick.Entities;
using FirstBrick.Enums;

namespace FirstBrick.Dtos.Responses;

public class TransactionsDto
{
    public string Id { get; set; } 
    public string WalletId { get; set; } 
    public TransactionType TransactionType { get; set; }
    public bool IsCashIn { get; set; }
    public double Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string Description { get; set; }

    public TransactionsDto(Transaction transaction, Wallet wallet)
    {
        Id = transaction.Key;
        WalletId = wallet.Key;
        TransactionType = transaction.TransactionType;
        IsCashIn = transaction.IsCashIn;
        Amount = transaction.Amount;
        Timestamp = transaction.Timestamp;
        Description = transaction.Description;
    }
}
