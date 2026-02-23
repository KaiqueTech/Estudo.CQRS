using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Aggregates.PedidoAggregate;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Ignore(p => p.Total);
            builder.Ignore(p => p.TotalPago);
            builder.Ignore(p => p.Saldo);
            builder.Ignore(p => p.EstaPago);
            builder.Ignore(p => p.EstaCancelado);

            builder.Metadata
                .FindNavigation(nameof(Pedido.Itens))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Pedido.Pagamentos))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(p => p.Itens)
                .WithOne()
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Pagamentos)
                .WithOne()
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.Status);
        }
    }
}
