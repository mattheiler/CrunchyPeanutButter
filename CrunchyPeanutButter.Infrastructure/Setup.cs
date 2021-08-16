using System.Reflection;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Infrastructure.Data;
using MediatR.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ServiceRegistrar.AddMediatRClasses(services, new[] {Assembly.GetExecutingAssembly()});

            services.AddDbContext<CrunchyPeanutButterDbContext>(ef => ef.UseSqlServer(configuration.GetConnectionString("CrunchyPeanutButter")));
            services.AddScoped<IDbContext, CrunchyPeanutButterDbContext>();

            return services;
        }
    }
}