using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Aggregates.PedidoAggregate;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.PedidoId)
                .IsRequired();

            builder.Property(i => i.ProdutoId)
                .IsRequired();

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Preco)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(i => i.Quantidade)
                .IsRequired();

            builder.Ignore(i => i.Total);

            builder.HasIndex(i => i.PedidoId);
        }
    }
}
