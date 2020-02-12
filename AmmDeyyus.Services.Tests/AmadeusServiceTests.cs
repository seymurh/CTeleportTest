using AmmaDeyyus.Services;
using AmmaDeyyus.Services.Models;
using System.Threading.Tasks;
using Xunit;

namespace AmmDeyyus.Services.Tests
{
    public class AmadeusServiceTests
    {
        [Fact]
        public async Task GetLocation()
        {
            string url = "https://places-dev.cteleport.com/airports/";
            string IATACode = "GYD";
            AirportService airportService = new AirportService();
            AirportResponse airportResponse = await airportService.GetAirport(url,IATACode);

            Assert.Equal(50.05039D, airportResponse.Location.Longitude, 10);
        }
    }
}