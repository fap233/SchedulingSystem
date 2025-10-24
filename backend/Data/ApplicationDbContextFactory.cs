using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SchedulingSystem.Api.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string basePath = Path.GetFullPath(
                Path.Combine(Directory.GetCurrentDirectory(), "..", "..")
            );

            string appSettingsPath = Path.Combine(basePath, "appsettings.Development.json");

            if (!File.Exists(appSettingsPath))
            {
                basePath = Directory.GetCurrentDirectory();
                appSettingsPath = Path.Combine(basePath, "appsettings.Development.json");
            }

            if (!File.Exists(appSettingsPath))
            {
                throw new FileNotFoundException(
                    $"Não foi possível encontrar 'appsettings.Development.json'. Caminho tentado: {appSettingsPath}"
                );
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "A 'DefaultConnection' está vazia ou não foi encontrada no 'appsettings.Development.json'."
                );
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
