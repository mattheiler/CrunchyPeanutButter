using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Domain.Commands
{
    public static class Setup
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}