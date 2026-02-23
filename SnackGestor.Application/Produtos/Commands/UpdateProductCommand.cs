using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Produtos.Commands
{
    public record UpdateProductCommand(Guid Id, string Nome, decimal Preco, Guid CategoriaId) : ICommand<bool>;
}
