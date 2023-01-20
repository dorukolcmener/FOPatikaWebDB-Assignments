namespace BankingApi.Models;

public class InterestRate
{
    public long Id { get; set; }
    public int MinAmount { get; set; }
    public int MaxAmount { get; set; }
    public decimal InterestAmount { get; set; }
}