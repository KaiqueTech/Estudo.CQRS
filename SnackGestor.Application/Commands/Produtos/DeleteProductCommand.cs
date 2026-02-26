using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Commands.Produtos
{
    public record DeleteProductCommand(Guid Id) : ICommand<bool>;
}
