using System;
using System.Threading.Tasks;

namespace AmmaDeyyus.QueryHandlers.Common
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IServiceProvider serviceProvider;

        public QueryHandler(IServiceProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            this.serviceProvider = provider;
        }

        public async Task<TOutput> Handle<TInput, TOutput>(TInput input)
        {
            IQuery<TInput, TOutput> queryHandlerInstance = (IQuery<TInput, TOutput>)serviceProvider.GetService(typeof(IQuery<TInput, TOutput>));
            return await queryHandlerInstance.ExecuteAsync(input);
        }
    }
}