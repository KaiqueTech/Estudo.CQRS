namespace SnackGestor.Application.Produtos.DTOs
{
    public record ProdutoDto(Guid Id, string Name, decimal Preco, bool Ativo);
}
