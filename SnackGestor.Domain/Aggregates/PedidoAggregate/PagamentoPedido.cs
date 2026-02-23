using SnackGestor.Domain.Common;
using SnackGestor.Domain.Enuns;
using SnackGestor.Domain.Exceptions;

namespace SnackGestor.Domain.Aggregates.PedidoAggregate;

public class PagamentoPedido : BaseModel
{
    public Guid PedidoId { get; private set; }
    public Guid FormaPagamentoId { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataPagamento { get; private set; }
    public StatusPagamentoEnum Status { get; private set; }

    protected PagamentoPedido() { }

    public PagamentoPedido(Guid pedidoId,Guid formaPagamentoId, decimal valor)
    {
        if (pedidoId == Guid.Empty)
            throw new DomainException("Pedido invalido");

        if (formaPagamentoId == Guid.Empty)
            throw new DomainException("Forma de pagamento inválida");

        if (valor <= 0)
            throw new DomainException("Valor inválido");

        FormaPagamentoId = formaPagamentoId;
        Valor = valor;
        DataPagamento = DateTime.UtcNow;
        Status = StatusPagamentoEnum.Pago;
    }

    public void Cancelar()
    {
        if (Status == StatusPagamentoEnum.Cancelado)
            throw new DomainException("Status atual não permite cancelamento");

        Status = StatusPagamentoEnum.Cancelado;
    }
}