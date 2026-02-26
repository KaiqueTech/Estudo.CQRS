using Microsoft.EntityFrameworkCore;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Domain.Models;
using SnackGestor.Infra.Persistense.Data;

namespace SnackGestor.Infra.Persistense.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task AddAsync(CategoriaModel category)
        {
            await context.Categorias.AddAsync(category);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var categoryName = await context.Categorias.FirstOrDefaultAsync(c => c.Name == name);
            return categoryName != null;
        }

        public async Task<IEnumerable<CategoriaModel>> GetAllAsync()
        {
            return await context.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel?> GetByIdAsync(Guid id)
        {
            var category = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task UpdateAsync(CategoriaModel category)
        {
             context.Categorias.Update(category);
        }
    }
}
