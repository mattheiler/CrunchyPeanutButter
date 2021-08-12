using CrunchyPeanutButter.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Persistence
{
    public static class Setup
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrunchyPeanutButterDbContext>(ef => ef.UseSqlServer(configuration.GetConnectionString("CrunchyPeanutButter")));
            services.AddScoped<IDbContext, CrunchyPeanutButterDbContext>();
            return services;
        }
    }
}