namespace BankingApi.Models;

// Generate random interestrate data via services
public class DataGenerator
{
    public static void Initialize(BankingContext _context)
    {
        if (_context.InterestRates.Any())
        {
            return;   // Data was already generated
        }

        var rng = new Random();
        _context.InterestRates.AddRange(
            new InterestRate() { MinAmount = 10000, MaxAmount = 25000, InterestAmount = 1.0m },
            new InterestRate() { MinAmount = 25001, MaxAmount = 50000, InterestAmount = 1.1m },
            new InterestRate() { MinAmount = 50001, MaxAmount = 100000, InterestAmount = 1.2m }
        );
        _context.SaveChanges();
    }
}