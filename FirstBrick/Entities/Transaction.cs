using FirstBrick.Enums;

namespace FirstBrick.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public TransactionType TransactionType { get; set; }
    public bool IsCashIn { get; set; }
    public double Amount { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now.ToUniversalTime();
    public string Description { get; set; }

    public Transaction() { } // Parameterless constructor required by EF Core

    public Transaction(int walletId, TransactionType type, double amount, string description)
    {
        WalletId = walletId;
        TransactionType = type;
        IsCashIn = type == TransactionType.Earnings || type == TransactionType.Deposit || type == TransactionType.CancelInvest;
        Amount = amount;
        Description = description;
    }
}
