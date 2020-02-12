using System.Threading.Tasks;

namespace CTeleportTest.QueryHandlers.Common
{
    public interface IQueryHandler
    {
        /// <summary>
        /// Handles the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<TOutput> Handle<TInput, TOutput>(TInput input);
    }
}