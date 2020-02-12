using Microsoft.Extensions.DependencyInjection;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Lamar;
using CTeleportTest.QueryHandlers;
using HttpServices;
using TeleportServices;
using CTeleportTest.Configurations;
using CTeleportTest.QueryHandlers.Common;
using TeleportServices.Models;

namespace CTeleportTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    ServiceRegistry serviceRegistry = null;
                    webBuilder.ConfigureServices(services =>
                    {
                        serviceRegistry = new ServiceRegistry(services);
                        serviceRegistry.AddControllers();
                        serviceRegistry.AddSwaggerDocument();
                        serviceRegistry.AddTransient<IHttpService, HttpService>();
                        serviceRegistry.AddTransient<IAirportService, AirportService>();
                        serviceRegistry.AddTransient<ITeleportServicesSettings, TeleportServicesSettings>();
                        serviceRegistry.AddSingleton<IQueryHandler, QueryHandler>();
                        serviceRegistry.AddTransient<IQuery<GetAirportDistanceRequest, double>, AirportDistanceQueryHandler>();

                        serviceRegistry.Scan(s =>
                        {
                            s.ConnectImplementationsToTypesClosing(typeof(IQuery<,>));
                            s.TheCallingAssembly();
                            s.SingleImplementationsOfInterface();
                            s.WithDefaultConventions();
                        });

                        serviceRegistry.AddAuthorization();
                        services.AddLamar(serviceRegistry);
                    });

                    webBuilder.UseLamar(serviceRegistry);
                    webBuilder.UseStartup<Startup>();
                });
    }
}