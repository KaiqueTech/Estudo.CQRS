using Microsoft.EntityFrameworkCore;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Domain.Models;
using SnackGestor.Infra.Persistense.Data;

namespace SnackGestor.Infra.Persistense.Repositories
{
    public class ProdutoRepository(AppDbContext context) : IProdutoRepository
    {
        public async Task AddAsync(ProdutoModel produto)
        {
            await context.Produtos.AddAsync(produto);
        }

        public async Task<List<ProdutoModel>> GetAllAsync()
        {
            return await context.Produtos
                .ToListAsync();
        }

        public async Task<ProdutoModel?> GetByIdAsync(Guid id)
        {
            var product = await context.Produtos.FirstOrDefaultAsync(pr => pr.Id == id);

            return product;
        }

        public async Task UpdateAsync(ProdutoModel produto)
        {
            context.Produtos.Update(produto);
        }
    }
}
