namespace WebApi
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using WebApi.Entity;
    using Microsoft.AspNetCore.Http;
    using WebApi.Entity.Seed;
    using WebApi.Repository;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using Microsoft.Extensions.DependencyModel;
    using AutoMapper;
    using MongoSample.Repository;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSingleton(provider => Configuration);

            services.AddDbContext<BillingDbContext>();
            services.AddTransient<UnitSeed>();
            services.AddTransient(typeof(GenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient<ProductRepository>();
            services.AddTransient<DataAccess>();

            AddAutoMapper(services, DependencyContext.Default);

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();            
        }

        public static void AddAutoMapper(IServiceCollection services, DependencyContext dependencyContext)
        {
            AddAutoMapperClasses(services, dependencyContext.RuntimeLibraries.SelectMany(lib => lib.GetDefaultAssemblyNames(dependencyContext).Select(Assembly.Load)));
        }

        private static void AddAutoMapperClasses(IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            assembliesToScan = assembliesToScan as Assembly[] ?? assembliesToScan.ToArray();

            var allTypes = assembliesToScan.SelectMany(a => a.ExportedTypes).ToArray();

            var profiles =
            allTypes
                .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                .Where(t => !t.GetTypeInfo().IsAbstract);

            Mapper.Initialize(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, UnitSeed seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseCors("CorsPolicy");

            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" Welcome to Dotnet Core !!");
            });

            try
            {
                seeder.UnitSeedData().Wait();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
