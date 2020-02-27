using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Domain.Queries
{
    public static class Setup
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}