using Microsoft.EntityFrameworkCore;
using SnackGestor.Domain.Aggregates.PedidoAggregate;
using SnackGestor.Domain.Models;

namespace SnackGestor.Infra.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> ItemPedidos { get; set; }
        public DbSet<PagamentoPedido> PagamentoPedidos { get; set; }
        public DbSet<FormaPagamentoModel> FormaPagamentos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
