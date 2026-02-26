namespace SnackGestor.Application.DTOs.Produtos
{
    public record ProdutoDto(Guid Id, string Nome, decimal Preco, bool Ativo, DateTime CreatedAt, DateTime UpdatedAt);
}
