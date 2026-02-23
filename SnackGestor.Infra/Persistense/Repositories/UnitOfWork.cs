
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Domain.Abstractions;
using SnackGestor.Infra.Persistense.Data;

namespace SnackGestor.Infra.Persistense.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<bool> CommitAsync(CancellationToken cancellation)
        {
            return await context.SaveChangesAsync(cancellation) > 0;
        }
    }
}
