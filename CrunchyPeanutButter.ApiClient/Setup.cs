using System;
using CrunchyPeanutButter.ApiClient.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrunchyPeanutButter.ApiClient
{
    public static class Setup
    {
        private static IServiceCollection AddCrunchyPeanutButter(this IServiceCollection services)
        {
            services.AddTransient<ICrunchyPeanutButter, CrunchyPeanutButterProxy>();
            return services;
        }

        public static IServiceCollection AddCrunchyPeanutButter(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.Configure<CrunchyPeanutButterProxyOptions>(configuration);
            return services.AddCrunchyPeanutButter();
        }

        public static IServiceCollection AddCrunchyPeanutButter(this IServiceCollection services, Action<CrunchyPeanutButterProxyOptions> configure)
        {
            services.Configure(configure);
            return services.AddCrunchyPeanutButter();
        }

        public static IServiceCollection AddCrunchyPeanutButter(this IServiceCollection services, string baseUrl)
        {
            return services.AddCrunchyPeanutButter(options => options.BaseUrl = baseUrl);
        }
    }
}