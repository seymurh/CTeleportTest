using Newtonsoft.Json;

namespace AmmaDeyyus.Services.Models
{
    public class AirportResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}