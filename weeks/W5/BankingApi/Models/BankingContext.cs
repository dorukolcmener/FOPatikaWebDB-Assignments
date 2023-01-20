using Microsoft.EntityFrameworkCore;

namespace BankingApi.Models;

public class BankingContext : DbContext
{
    public BankingContext(DbContextOptions<BankingContext> options)
        : base(options)
    {
    }

    public DbSet<InterestRate> InterestRates { get; set; } = null!;
}