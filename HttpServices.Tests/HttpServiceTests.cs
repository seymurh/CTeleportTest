using HttpServices.Tests.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HttpServices.Tests
{
    public class HttpServiceTests
    {
        [Fact]
        public async Task GetRequestAsync_UrlNull_Throws()
        {
            HttpService httpService = new HttpService();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await httpService.GetRequestAsync<AirportResponse>(null));
        }

        [Fact]
        public async Task WrongUrl_MakesHttpCall_Throws()
        {
            //arrange
            HttpService httpService = new HttpService();
            string url = "https://wrongUrl";

            //assert
           await Assert.ThrowsAsync<HttpRequestException>(async () => await httpService.GetRequestAsync<AirportResponse>(url));
        }

        [Fact]
        public async Task GetRequestAsync_ValidUrl_ReturnsData()
        {
            //arrange
            HttpService httpService = new HttpService();
            string url = "https://places-dev.cteleport.com/airports/AMS";

            //act
            AirportResponse result = await httpService.GetRequestAsync<AirportResponse>(url);

            //assert
            Assert.NotNull(result);
        }
    }
}