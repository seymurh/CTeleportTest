using AmmaDeyyus.Services.Models;
using System;
using System.Threading.Tasks;
//using HttpServices;



namespace AmmaDeyyus.Services
{
    public class AirportService
    {
        //private readonly IHttpService httpService;

        public AirportService()
        {

        }

        public async Task<AirportResponse> GetAirport(string url, string IATACode)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrWhiteSpace(IATACode)) throw new ArgumentNullException(nameof(IATACode));

            string airportUrl = $"{url}{IATACode}";
            return null; //await httpService.GetRequest<AirportResponse>(airportUrl);
        }

        /// <summary>
        /// Returns distance between airports in sea miles
        /// </summary>
        /// <param name="airport"></param>
        /// <param name="otherAirport"></param>
        /// <returns></returns>
        public double GetDistance(AirportResponse airport, AirportResponse otherAirport)
        { 
            if (double.IsNaN(airport.Location.Latitude) || double.IsNaN(airport.Location.Longitude) || double.IsNaN(otherAirport.Location.Latitude) ||
                double.IsNaN(otherAirport.Location.Longitude))
            {
                throw new ArgumentException("Argument latitude or longitude is not a number");
            }

            var d1 = airport.Location.Latitude * (Math.PI / 180.0);
            var num1 = airport.Location.Longitude * (Math.PI / 180.0);
            var d2 = otherAirport.Location.Latitude * (Math.PI / 180.0);
            var num2 = otherAirport.Location.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1852;
        }
    }
}