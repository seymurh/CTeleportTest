using Microsoft.Extensions.Configuration;
using TeleportServices;

namespace CTeleportTest.Configurations
{
    public class TeleportServicesSettings : ITeleportServicesSettings
    {
        public TeleportServicesSettings(IConfiguration configuration)
        {
            CTeleportAiportDataUrl = configuration["CTeleportAirportDataService"];
        }

        public string CTeleportAiportDataUrl { get; set; }
    }
}