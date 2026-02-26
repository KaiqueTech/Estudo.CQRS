using Microsoft.Extensions.DependencyInjection;
using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Infra.Abstractions
{
    public class QueryDispatcher(IServiceProvider provider) : IQueryDispatcher
    {
        public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IQueryHandler<,>)
            .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = provider.GetRequiredService(handlerType);

            return await handler.Handle((dynamic)query, cancellationToken);
        }
    }
}
