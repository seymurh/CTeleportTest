using System.Threading.Tasks;

namespace AmmaDeyyus.QueryHandlers.Common
{
    public interface IQuery<in TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}