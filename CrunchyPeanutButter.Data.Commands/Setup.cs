using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Data.Commands
{
    public static class Setup
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}