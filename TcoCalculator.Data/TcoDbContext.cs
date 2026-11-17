using Microsoft.EntityFrameworkCore;
using TcoCalculator.Core.Models;

namespace TcoCalculator.Data;

public class TcoDbContext(DbContextOptions<TcoDbContext> options) : DbContext(options)
{
    public DbSet<EnergyPrice> EnergyPrices => Set<EnergyPrice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnergyPrice>(entity =>
        {
            entity.Property(p => p.Region).HasMaxLength(50);
            entity.Property(p => p.EnergyVector).HasMaxLength(50);
            entity.Property(p => p.Unit).HasMaxLength(10);
        });
    }
}
