using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CrunchyPeanutButter.Persistence
{
    public class CrunchyPeanutButterDbContextDesignTimeFactory : IDesignTimeDbContextFactory<CrunchyPeanutButterDbContext>
    {
        public CrunchyPeanutButterDbContext CreateDbContext(string[] args)
        {
            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .AddUserSecrets<CrunchyPeanutButterDbContextDesignTimeFactory>(true)
                    .Build();
            var options =
                new DbContextOptionsBuilder<CrunchyPeanutButterDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("CrunchyPeanutButter"))
                    .Options;
            return new CrunchyPeanutButterDbContext(options);
        }
    }
}