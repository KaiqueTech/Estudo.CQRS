using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Produtos.Commands
{
    public record CreateProductCommand(string Nome,decimal Preco, Guid CategoriaId) : ICommand<Guid>;
}
