using Lamar;
using System;
using System.Threading.Tasks;

namespace CTeleportTest.QueryHandlers.Common
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IContainer contrainer;

        public QueryHandler(IContainer contrainer /*IServiceProvider provider*/)
        {
            //if (provider == null) throw new ArgumentNullException(nameof(provider));
            //this.serviceProvider = provider;
            this.contrainer = contrainer;
        }

        public async Task<TOutput> Handle<TInput, TOutput>(TInput input)
        {
            //IQuery<TInput, TOutput> queryHandlerInstance = (IQuery<TInput, TOutput>)serviceProvider.GetService(typeof(IQuery<TInput, TOutput>));
            IQuery<TInput, TOutput> queryHandlerInstance = contrainer.GetInstance<IQuery<TInput, TOutput>>();
            return await queryHandlerInstance.ExecuteAsync(input);
        }
    }
}