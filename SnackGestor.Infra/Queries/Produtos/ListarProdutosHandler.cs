using Dapper;
using SnackGestor.Application.Abstractions.Data;
using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.DTOs.Produtos;
using SnackGestor.Application.Queries.Produtos;

namespace SnackGestor.Infra.Queries.Produtos;

public class ListarProdutosHandler(IDbConnectionFactory dbConnection) : IQueryHandler<ListarProdutosQuery, IEnumerable<ProdutoDto>>
{
    public async Task<IEnumerable<ProdutoDto>> Handle(ListarProdutosQuery query, CancellationToken cancellationToken)
    {
        using var connection = dbConnection.CreateConnection();

        var sql = """
                    SELECT
                    p.Id,
                    p.Name,
                    p.Ativo
                    FROM Produtos p
                """;

        var command = new CommandDefinition(sql, cancellationToken);

        return await connection.QueryAsync<ProdutoDto>(command);
    }
}
