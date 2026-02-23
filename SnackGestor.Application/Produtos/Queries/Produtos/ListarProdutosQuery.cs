using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Produtos.DTOs;

namespace SnackGestor.Application.Produtos.Queries.Produtos
{
    public record ListarProdutosQuery() : IQuery<IEnumerable<ProdutoDto>>;
}
