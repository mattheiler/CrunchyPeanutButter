using System;
using System.Linq;
using System.Reflection;
using Amazon.EventBridge;
using CrispyBacon.Events.AwsEventBridge;
using CrunchyPeanutButter.Data;
using CrunchyPeanutButter.Data.Queries;
using CrunchyPeanutButter.Domain.Events;
using CrunchyPeanutButter.Domain.Stores;
using CrunchyPeanutButter.Queries.Bars;
using CrunchyPeanutButter.Queries.Foos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CrunchyPeanutButter.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CrunchyPeanutButterDbContext>(ef =>
                    ef.UseSqlServer(Configuration.GetConnectionString("CrunchyPeanutButter"), sql =>
                        sql.MigrationsAssembly("CrunchyPeanutButter.Data.Migrations")));

            services
                .AddScoped<ICrunchyPeanutButterUnitOfWork, CrunchyPeanutButterDbContextUnitOfWork>();

            services
                .AddAWSService<IAmazonEventBridge>();
            services
                .Configure<AwsEventBridgeDomainEventHandlerOptions>(Configuration.GetSection("DomainEvents"));

            services
                .AddMediatR(
                    Assembly.Load("CrispyBacon.Events.AwsEventBridge"),
                    Assembly.Load("CrunchyPeanutButter.Domain"));

            services
                .AddScoped<IBarQueries, BarQueries>()
                .AddScoped<IFooQueries, FooQueries>();

            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}