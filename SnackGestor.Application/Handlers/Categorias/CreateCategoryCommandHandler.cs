using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Commands.Categorias;
using SnackGestor.Domain.Abstractions;
using SnackGestor.Domain.Models;

namespace SnackGestor.Application.Handlers.Categorias
{
    public class CreateCategoryCommandHandler(ICategoryRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<CreateCategoryCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var exists = await repo.ExistsByNameAsync(command.Name);

            if (exists)
                throw new InvalidOperationException("Categoria já cadastrada.");

            var category = CategoriaModel.CreateCategory(command.Name);

            await repo.AddAsync(category);

            await unitOfWork.CommitAsync(cancellationToken);

            return category.Id;
        }
    }
}
