using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Models;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.HasIndex(p => p.Nome);

            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.UpdatedAt);
        }
    }
}
