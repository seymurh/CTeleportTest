using Newtonsoft.Json;

namespace TeleportServices.Models
{
    public class TokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}