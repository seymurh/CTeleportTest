using Newtonsoft.Json;

namespace TeleportServices.Models
{
    public class AirportResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}