using System.Linq;
using System.Net;
using System.Net.Mime;
using CrunchyPeanutButter.Core;
using CrunchyPeanutButter.Infrastructure;
using CrunchyPeanutButter.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CrunchyPeanutButter.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCore()
                .AddInfrastructure(Configuration)
                .AddPersistence(Configuration);

            services.AddControllers();

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "App/dist");

            services.AddSwaggerGen(options =>
            {
                options.CustomOperationIds(api => api.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null);
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature?.Error is ValidationException e)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(e.Errors.Select(error => error.ErrorMessage).ToList()));
                    }
                });
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "./App";

                if (env.IsDevelopment())
                    spa.UseProxyToSpaDevelopmentServer("http://host.docker.internal:4200");
            });
        }
    }
}
