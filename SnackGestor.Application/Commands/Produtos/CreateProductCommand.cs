using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Commands.Produtos
{
    public record CreateProductCommand(string Nome,decimal Preco, Guid CategoriaId) : ICommand<Guid>;
}
