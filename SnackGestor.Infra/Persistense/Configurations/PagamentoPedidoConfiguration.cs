using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Aggregates.PedidoAggregate;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class PagamentoPedidoConfiguration : IEntityTypeConfiguration<PagamentoPedido>
    {
        public void Configure(EntityTypeBuilder<PagamentoPedido> builder)
        {
            builder.ToTable("PagamentosPedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PedidoId)
                .IsRequired();

            builder.Property(p => p.FormaPagamentoId)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.DataPagamento)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.HasIndex(p => p.PedidoId);
        }
    }
}
