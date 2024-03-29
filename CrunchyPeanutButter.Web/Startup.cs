using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using CrunchyPeanutButter.Core.Abstractions;
using CrunchyPeanutButter.Core.Behaviors;
using CrunchyPeanutButter.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
            services.AddAutoMapper(Assembly.Load("CrunchyPeanutButter.Core"), Assembly.Load("CrunchyPeanutButter.Infrastructure"), Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.Load("CrunchyPeanutButter.Core"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            AssemblyScanner.FindValidatorsInAssembly(Assembly.Load("CrunchyPeanutButter.Core")).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            services
                .AddDbContext<CrunchyPeanutButterDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CrunchyPeanutButter")))
                .AddTransient<ICrunchyPeanutButterDbContext, CrunchyPeanutButterDbContext>(provider => provider.GetService<CrunchyPeanutButterDbContext>());

            services
                .AddAuthentication()
                .AddJwtBearer();

            services
                .AddControllers();

            services
                .AddSpaStaticFiles(configuration => configuration.RootPath = "App/dist");

            services
                .AddSwaggerGen(options =>
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CrunchyPeanutButterDbContext db)
        {
            db.Database.Migrate();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature?.Error is ValidationException e)
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        // TODO in 5.0, use WriteAsJsonAsync

                        await context.Response.WriteAsync(JsonSerializer.Serialize(e.Errors.Select(error => error.ErrorMessage).ToList()));
                    }
                });
            });

            // For development, Chrome requires secure cookies w/ http, so let's make it lax.
            if (env.IsDevelopment())
                app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            else
                app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet(".authority", async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.OK;
                    context.Response.ContentType = MediaTypeNames.Text.Plain;

                    await context.Response.WriteAsync(Configuration.GetValue<string>("Authority"));
                });
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "./App";

                if (env.IsDevelopment())
                    spa.UseProxyToSpaDevelopmentServer("http://crunchypeanutbutter.webapp:4200");
            });
        }
    }
}