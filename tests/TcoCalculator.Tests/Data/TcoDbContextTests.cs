using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TcoCalculator.Core.Models;
using TcoCalculator.Data;

namespace TcoCalculator.Tests.Data;

public class TcoDbContextTests
{
    [Fact]
    public void MigrationsCreateDatabaseAndEnergyPriceIsSavedAndReadBack()
    {
        // Base SQLite en mémoire : rien n'est écrit sur le disque
        using var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        var options = new DbContextOptionsBuilder<TcoDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new TcoDbContext(options))
        {
            // Applique les vraies migrations, comme au démarrage de l'application
            context.Database.Migrate();
            context.EnergyPrices.Add(new EnergyPrice
            {
                Year = 2026,
                Region = "Wallonia",
                EnergyVector = "Diesel",
                Unit = "L",
                PricePerUnit = 1.80m
            });
            context.SaveChanges();
        }

        // Nouveau contexte : on relit vraiment depuis la base, pas depuis le cache
        using (var context = new TcoDbContext(options))
        {
            var saved = Assert.Single(context.EnergyPrices);
            Assert.Equal(2026, saved.Year);
            Assert.Equal("Diesel", saved.EnergyVector);
            Assert.Equal(1.80m, saved.PricePerUnit);
        }
    }
}
