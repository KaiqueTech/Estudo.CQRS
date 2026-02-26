using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Commands.Produtos
{
    public record UpdateProductCommand(Guid Id, string Nome, decimal Preco, Guid CategoriaId) : ICommand<bool>;
}
