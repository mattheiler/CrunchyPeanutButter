using System.Reflection;
using MediatR.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ServiceRegistrar.AddMediatRClasses(services, new[] {Assembly.GetExecutingAssembly()});
            return services;
        }
    }
}