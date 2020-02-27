using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Data.Queries
{
    public static class Setup
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}