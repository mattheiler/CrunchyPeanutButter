using System.Reflection;
using CrunchyPeanutButter.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Application
{
    public static class Setup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly()).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            return services;
        }
    }
}