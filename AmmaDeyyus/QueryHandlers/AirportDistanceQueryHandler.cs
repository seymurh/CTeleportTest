using AmmaDeyyus.QueryHandlers.Common;
using System;
using System.Threading.Tasks;
using TeleportServices;
using TeleportServices.Models;


namespace AmmaDeyyus.QueryHandlers
{
    public class AirportDistanceQueryHandler : IQuery<GetAirportDistanceRequest, double>
    {
        private readonly IAirportService airportService;

        public AirportDistanceQueryHandler(IAirportService airportService)
        {
            if(airportService == null) throw new ArgumentNullException(nameof(airportService));

            this.airportService = airportService;
        }

        public async Task<double> ExecuteAsync(GetAirportDistanceRequest input)
        {
            AirportResponse airport1 = await airportService.GetAirport(input.IATACode1);
            AirportResponse airport2 = await airportService.GetAirport(input.IATACode2);
            return airportService.CalculateDistance(airport1, airport2);
        }
    }
}