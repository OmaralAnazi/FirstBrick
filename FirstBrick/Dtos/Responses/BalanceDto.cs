using FirstBrick.Entities;

namespace FirstBrick.Dtos.Responses;

public class BalanceDto(Wallet wallet)
{
    public double Balance { get; set; } = Math.Round(wallet.Balance, 2);
}
