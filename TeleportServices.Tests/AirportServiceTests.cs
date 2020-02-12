using HttpServices;
using Xunit;
using Moq;
using TeleportServices.Models;
using System.Threading.Tasks;

namespace TeleportServices.Tests
{
    public class AirportServiceTests
    {
        [Fact]
        public async Task GetAirport_ValidIATACode_ReturnsAirport()
        {
            //arrange
            Mock<IHttpService> httpServiceMock = new Mock<IHttpService>();
            var settingsMock = new Mock<ITeleportServicesSettings>();
            string url = "https://example/";

            var getRequestResult = new AirportResponse
            {
                Location = new Location
                {
                    Latitude = 5,
                    Longitude = 5
                }
            };

            httpServiceMock.SetupSequence(x => x.GetRequestAsync<AirportResponse>(It.IsAny<string>())).ReturnsAsync<AirportResponse>(getRequestResult);
            settingsMock.SetupGet<string>(x => x.CTeleportAiportDataUrl).Returns(url);

            AirportService airportService = new AirportService(httpServiceMock.Object, settingsMock.Object);

            //act
            AirportResponse airportResponse = await airportService.GetAirport("AMS");

            //assert
            Assert.Same(airportResponse, getRequestResult);
        }

        [Fact]
        public async Task CalculateDistance_SameLocations_ReturnsZero()
        {
            //arrange
            Mock<IHttpService> httpServiceMock = new Mock<IHttpService>();
            var settingsMock = new Mock<ITeleportServicesSettings>();
            AirportService airportService = new AirportService(httpServiceMock.Object, settingsMock.Object);
            AirportResponse airportResponse = new AirportResponse { Location=new Location { Latitude = 1, Longitude = 1 } };
            AirportResponse airportResponse2 = new AirportResponse { Location = new Location { Latitude = 1, Longitude = 1 } };

            //act
            double result = airportService.CalculateDistance(airportResponse, airportResponse2);

            //assert
            Assert.Equal(0, result, 2);
        }
    }
}