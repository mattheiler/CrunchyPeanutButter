﻿using System.Reflection;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.Domain
{
    public static class Setup
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            ServiceRegistrar.AddMediatRClasses(services, new[] {Assembly.GetExecutingAssembly()});
            return services;
        }
    }
}