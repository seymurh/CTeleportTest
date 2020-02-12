using Newtonsoft.Json;

namespace AmmaDeyyus.Services.Models
{
    public class TokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}