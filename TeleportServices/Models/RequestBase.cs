namespace TeleportServices.Models
{
    public abstract class RequestBase
    {
        public string ClientId { get; set; }

        public string BearerToken { get; set; }
    }
}