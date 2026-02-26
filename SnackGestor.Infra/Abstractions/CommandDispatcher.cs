using Microsoft.Extensions.DependencyInjection;
using SnackGestor.Application.Abstractions.Messaging;
using System.Windows.Input;

namespace SnackGestor.Infra.Abstractions
{
    public class CommandDispatcher(IServiceProvider provider) : ICommandDispatcher
    {
        public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(ICommandHandler<,>)
            .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = provider.GetRequiredService(handlerType);

            return await handler.Handle((dynamic)command, cancellationToken);
        }
    }
}
