using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Models;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamentoModel>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoModel> builder)
        {
            builder.ToTable("FormasPagamento");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(f => f.Ativa)
                .IsRequired();

            builder.Property(f => f.CreatedAt).IsRequired();
            builder.Property(f => f.UpdatedAt);
        }
    }
}
