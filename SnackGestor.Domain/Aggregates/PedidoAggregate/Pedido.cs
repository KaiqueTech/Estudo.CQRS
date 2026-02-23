using SnackGestor.Domain.Common;
using SnackGestor.Domain.Enuns;
using SnackGestor.Domain.Exceptions;

namespace SnackGestor.Domain.Aggregates.PedidoAggregate;

public class Pedido : BaseModel
{
    private readonly List<PedidoItem> _itens = new();
    private readonly List<PagamentoPedido> _pagamentos = new();

    public IReadOnlyCollection<PedidoItem> Itens => _itens;
    public IReadOnlyCollection<PagamentoPedido> Pagamentos => _pagamentos;

    public StatusPedidoEnum Status { get; private set; }

    public decimal Total => _itens.Sum(i => i.Total);
    public decimal TotalPago => _pagamentos.Sum(p => p.Valor);
    public decimal Saldo => Total - TotalPago;

    public bool EstaPago => Status == StatusPedidoEnum.Pago;
    public bool EstaCancelado => Status == StatusPedidoEnum.Cancelado;

    //protected Pedido() { }

    public Pedido() => Status = StatusPedidoEnum.Aberto;

    public void AdicionarItem(Guid produtoId, Guid id,string nome, decimal preco, int quantidade)
    {
        ValidarAlteracao();

        if (produtoId == Guid.Empty)
            throw new DomainException("Produto inválido");

        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome do produto obrigatório");

        if (preco < 0)
            throw new DomainException("Preço inválido");

        if (quantidade <= 0)
            throw new DomainException("Quantidade inválida");

        var existente = _itens.FirstOrDefault(i => i.ProdutoId == produtoId);

        if (existente != null)
            existente.AlterarQuantidade(existente.Quantidade + quantidade);
        else
            _itens.Add(new PedidoItem(produtoId, id,nome, preco, quantidade));
    }

    public void RemoverItem(Guid produtoId)
    {
        ValidarAlteracao();

        _itens.RemoveAll(i => i.ProdutoId == produtoId);
    }

    public void LimparItens()
    {
        ValidarAlteracao();
        _itens.Clear();
    }
    public void RegistrarPagamento(Guid id, Guid formaPagamentoId,decimal valor)
    {
        if (!_itens.Any())
            throw new DomainException("Pedido sem itens");

        if (EstaCancelado)
            throw new DomainException("Pedido cancelado");

        if (EstaPago)
            throw new DomainException("Pedido já está pago");

        if (formaPagamentoId == Guid.Empty)
            throw new DomainException("Forma de pagamento inválida");

        if (valor <= 0)
            throw new DomainException("Valor inválido");

        _pagamentos.Add(new PagamentoPedido(id,formaPagamentoId, valor));

        AtualizarStatusPagamento();
    }

    public void RemoverPagamentos()
    {
        if (EstaCancelado)
            throw new DomainException("Pedido cancelado");

        _pagamentos.Clear();
        AtualizarStatusPagamento();
    }

    private void AtualizarStatusPagamento()
    {
        if (Saldo <= 0)
            Status = StatusPedidoEnum.Pago;
        else if (TotalPago > 0)
            Status = StatusPedidoEnum.AguardandoPagamento;
        else
            Status = StatusPedidoEnum.Aberto;
    }
    public void Cancelar()
    {
        if (EstaPago)
            throw new DomainException("Pedido já pago não pode ser cancelado");

        Status = StatusPedidoEnum.Cancelado;
    }

    public void Reabrir()
    {
        if (!EstaCancelado)
            throw new DomainException("Somente pedidos cancelados podem ser reabertos");

        Status = StatusPedidoEnum.Aberto;
    }

    private void ValidarAlteracao()
    {
        if (Status != StatusPedidoEnum.Aberto)
            throw new DomainException("Pedido não pode ser alterado");
    }
}