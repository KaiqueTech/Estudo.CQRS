using SnackGestor.Domain.Models;

namespace SnackGestor.Application.Abstractions.Persistence
{
    public interface ICategoryRepository
    {
        Task AddAsync(CategoriaModel category);
        Task UpdateAsync(CategoriaModel category);
        Task<CategoriaModel?> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoriaModel>> GetAllAsync();

        Task<bool> ExistsByNameAsync(string name);
    }
}
