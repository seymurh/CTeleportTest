using System;
using System.Threading.Tasks;
using TeleportServices.Models;
using HttpServices;
using GeoCoordinatePortable;

namespace TeleportServices
{
    public class AirportService : IAirportService
    {
        private readonly IHttpService httpService;
        private readonly ITeleportServicesSettings teleportServicesSettings;

        public AirportService(IHttpService httpService, ITeleportServicesSettings teleportServicesSettings)
        {
            this.httpService = httpService;
            this.teleportServicesSettings = teleportServicesSettings;
        }

        public async Task<AirportResponse> GetAirport(string IATACode)
        {
            string url = teleportServicesSettings.CTeleportAiportDataUrl;
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrWhiteSpace(IATACode)) throw new ArgumentNullException(nameof(IATACode));

            string airportUrl = $"{url}{IATACode}";
            return await httpService.GetRequestAsync<AirportResponse>(airportUrl);
        }

        /// <summary>
        /// Returns distance between airports in sea miles
        /// </summary>
        /// <param name="airport"></param>
        /// <param name="otherAirport"></param>
        /// <returns></returns>
        public double CalculateDistance(AirportResponse airport, AirportResponse otherAirport)
        {
            if (airport == null) throw new ArgumentNullException(nameof(airport));
            if (otherAirport == null) throw new ArgumentNullException(nameof(otherAirport));
            if (double.IsNaN(airport.Location.Latitude) || double.IsNaN(airport.Location.Longitude) || double.IsNaN(otherAirport.Location.Latitude) ||
                double.IsNaN(otherAirport.Location.Longitude))
            {
                throw new ArgumentException("Argument latitude or longitude is not a number");
            }

            GeoCoordinate geoCoordinate1 = new GeoCoordinate(airport.Location.Latitude, airport.Location.Longitude);
            GeoCoordinate geoCoordinate2 = new GeoCoordinate(otherAirport.Location.Latitude, otherAirport.Location.Longitude);

            double distanceInMeters = geoCoordinate1.GetDistanceTo(geoCoordinate2);

            return distanceInMeters / 1609.34D; // 1852; sea mile
        }
    }
}