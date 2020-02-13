using System;
using Xunit;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using CTeleportTest.QueryHandlers;
using CTeleportTest.QueryHandlers.Common;
using TeleportServices.Models;
using FluentAssertions;
using TeleportServices;
using HttpServices;
using CTeleportTest.Configurations;
using Moq;
using Microsoft.Extensions.Configuration;

namespace CTeleportTest.Tests
{
    public class LamarTests
    {
        [Fact]
        public void CTeleportServiceRegistry_GetInstance_ReturnsImplementations()
        {
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.SetupGet(p => p["CTeleportAirportDataService"]).Returns("test");
            IContainer container = new Container(_ => {
                _.For<IConfiguration>().Use(configurationMock.Object);
                _.IncludeRegistry<CTeleportServiceRegistry>();
            });
            
            var c = container.GetInstance<IConfiguration>();
            var settingValue = c["CTeleportAirportDataService"];
            var t = container.GetInstance<ITeleportServicesSettings>();
            var url = t.CTeleportAiportDataUrl;
            var h = container.GetInstance<IHttpService>();
            var k = container.GetInstance<IAirportService>();
            var query = container.GetInstance<IQuery<GetAirportDistanceRequest, double>>();
            query.Should().BeOfType<AirportDistanceQueryHandler>();
        }
    }
}