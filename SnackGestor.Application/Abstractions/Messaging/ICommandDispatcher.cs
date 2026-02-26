
namespace SnackGestor.Application.Abstractions.Messaging
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    }
}
