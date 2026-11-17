using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TcoCalculator.Data;

// Utilisée uniquement par l'outil dotnet-ef (en local et dans la CI),
// pour créer le DbContext sans lancer l'application MAUI.
public class TcoDbContextFactory : IDesignTimeDbContextFactory<TcoDbContext>
{
    public TcoDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<TcoDbContext>()
            .UseSqlite("Data Source=design-time.db")
            .Options;
        return new TcoDbContext(options);
    }
}
