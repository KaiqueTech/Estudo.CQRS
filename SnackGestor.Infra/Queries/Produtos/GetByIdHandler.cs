using Dapper;
using SnackGestor.Application.Abstractions.Data;
using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.DTOs.Produtos;
using SnackGestor.Application.Queries.Produtos;

namespace SnackGestor.Infra.Queries.Produtos
{
    public class GetByIdHandler(IDbConnectionFactory dbConnection) : IQueryHandler<GetByIdProductsQuery, ProdutoDto>
    {
        public async Task<ProdutoDto?> Handle(GetByIdProductsQuery query, CancellationToken cancellationToken = default)
        {
            using var connection = dbConnection.CreateConnection();

            const string sql = """
                                SELECT
                                    "Id",
                                    "Nome",
                                    "Preco",
                                    "Ativo",
                                    "CreatedAt",
                                    "UpdatedAt"
                                FROM "Produtos"
                                WHERE "Id" = @Id
                                """;

            var produto = await connection.QueryFirstOrDefaultAsync<ProdutoDto>(sql, new { query.Id });

            if (produto is null)
                throw new ArgumentNullException("Produto nulo aqui");

            return produto;
        }
    }
}
