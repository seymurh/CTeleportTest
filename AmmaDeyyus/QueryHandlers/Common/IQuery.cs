using System.Threading.Tasks;

namespace CTeleportTest.QueryHandlers.Common
{
    public interface IQuery<in TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}