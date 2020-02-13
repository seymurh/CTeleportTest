using Microsoft.Extensions.DependencyInjection;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Lamar;
using CTeleportTest.Configurations;
using Microsoft.AspNetCore;

namespace CTeleportTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder2(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            ServiceRegistry serviceRegistry = null;
        //            webBuilder.ConfigureServices(services =>
        //            {
        //                serviceRegistry = new ServiceRegistry(services);
        //                serviceRegistry.AddControllers();
        //                serviceRegistry.AddSwaggerDocument();
        //                serviceRegistry.IncludeRegistry<CTeleportServiceRegistry>();
        //                serviceRegistry.AddAuthorization();
        //                services.AddLamar(serviceRegistry);
        //            });

        //            webBuilder.UseLamar(serviceRegistry);
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHostBuilder CreateHostBuilder2(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseLamar()
            .UseStartup<Startup>();
    }
}