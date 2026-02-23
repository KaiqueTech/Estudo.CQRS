using SnackGestor.Domain.Common;
using SnackGestor.Domain.Exceptions;

namespace SnackGestor.Domain.Aggregates.PedidoAggregate;

public class PedidoItem : BaseModel
{
    public Guid ProdutoId { get; private set; }
    public Guid PedidoId { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get; private set; }

    public decimal Total => Preco * Quantidade;

    protected PedidoItem() { }

    public PedidoItem(Guid produtoId, Guid pedidoItem,string nome, decimal preco, int quantidade)
    {
        if (produtoId == Guid.Empty)
            throw new DomainException("Produto inválido");

        if (PedidoId == Guid.Empty)
            throw new DomainException("Pedido inválido");

        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome obrigatório");

        if (preco < 0)
            throw new DomainException("Preço inválido");

        if (quantidade <= 0)
            throw new DomainException("Quantidade inválida");

        ProdutoId = produtoId;
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }


    public void AlterarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade inválida");

        Quantidade = quantidade;
    }

    public void AlterarPreco(decimal preco)
    {
        if (preco < 0)
            throw new DomainException("Preço inválido");

        Preco = preco;
    }
}