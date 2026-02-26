using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.DTOs.Produtos;

namespace SnackGestor.Application.Queries.Produtos
{
    public record ListarProdutosQuery() : IQuery<IEnumerable<ProdutoDto>>;
}
