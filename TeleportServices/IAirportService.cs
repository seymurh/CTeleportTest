using System.Threading.Tasks;
using TeleportServices.Models;

namespace TeleportServices
{
    public interface IAirportService
    {
        Task<AirportResponse> GetAirport(string IATACode);

        double CalculateDistance(AirportResponse airport, AirportResponse otherAirport);
    }
}