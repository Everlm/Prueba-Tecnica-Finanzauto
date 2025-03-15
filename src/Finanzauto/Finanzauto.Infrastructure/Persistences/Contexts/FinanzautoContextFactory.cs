using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Finanzauto.Infrastructure.Persistences.Contexts
{
    public class FinanzautoContextFactory : IDesignTimeDbContextFactory<FinanzautoContext>
    {
        public FinanzautoContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Finanzauto.API");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Connection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró una cadena de conexión válida en appsettings.json.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<FinanzautoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FinanzautoContext(optionsBuilder.Options);
        }

    }
}
