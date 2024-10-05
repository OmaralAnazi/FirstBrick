namespace FirstBrick.Entities;

public class Wallet
{
    public int Id { get; set; }
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public string AppUserId { get; set; }
    public double Balance { get; set; }
}
