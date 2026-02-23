using SnackGestor.Domain.Models;

namespace SnackGestor.Application.Abstractions.Persistence
{
    public interface IProdutoRepository
    {
        Task AddAsync(ProdutoModel produto);
        Task UpdateAsync(ProdutoModel produto);
        Task<ProdutoModel?> GetByIdAsync(Guid id);
        Task<List<ProdutoModel>> GetAllAsync();
    }
}
