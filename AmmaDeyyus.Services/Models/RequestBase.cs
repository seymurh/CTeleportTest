namespace AmmaDeyyus.Services.Models
{
    public abstract class RequestBase
    {
        public string ClientId { get; set; }

        public string BearerToken { get; set; }
    }
}