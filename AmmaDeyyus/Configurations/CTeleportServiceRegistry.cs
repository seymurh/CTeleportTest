using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTeleportTest.QueryHandlers;
using CTeleportTest.QueryHandlers.Common;
using HttpServices;
using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeleportServices;
using TeleportServices.Models;

namespace CTeleportTest.Configurations
{
    public class CTeleportServiceRegistry : ServiceRegistry
    {
        public CTeleportServiceRegistry()
        {
            this.AddTransient<IQueryHandler, QueryHandler>();
            this.AddTransient<IHttpService, HttpService>();
            this.AddTransient<ITeleportServicesSettings, TeleportServicesSettings>();
            this.AddTransient<IAirportService, AirportService>();
            this.Scan(s =>
            {
                s.AssemblyContainingType<AirportDistanceQueryHandler>();
                s.IncludeNamespace("CTeleportTest.QueryHandlers");
                s.IncludeNamespace("CTeleportTest.QueryHandlers.Common");
                s.ConnectImplementationsToTypesClosing(typeof(IQuery<,>));
                s.SingleImplementationsOfInterface();
            });
        }
    }
}