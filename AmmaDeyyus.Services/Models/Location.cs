using Newtonsoft.Json;

namespace AmmaDeyyus.Services.Models
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}