using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnackGestor.Domain.Models;

namespace SnackGestor.Infra.Persistense.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);
        }
    }
}
