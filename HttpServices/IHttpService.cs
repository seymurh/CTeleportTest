using System.Threading.Tasks;

namespace HttpServices
{
    public interface IHttpService
    {
        Task<T> GetRequestAsync<T>(string url) where T:class;
    }
}