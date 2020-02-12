using Newtonsoft.Json;

namespace HttpServices.Tests.Models
{
    public class AirportResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}