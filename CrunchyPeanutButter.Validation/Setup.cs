using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Validation
{
    public static class Setup
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}