using Newtonsoft.Json;

namespace HttpServices.Tests.Models
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}