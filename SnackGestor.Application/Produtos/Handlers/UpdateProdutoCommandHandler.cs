using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Produtos.Commands;
using SnackGestor.Domain.Abstractions;
using System.Net;

namespace SnackGestor.Application.Produtos.Handlers
{
    public class UpdateProdutoCommandHandler(IProdutoRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await repo.GetByIdAsync(command.Id);

            if (product == null)
                throw new InvalidOperationException($"Product not found");

            if (string.IsNullOrWhiteSpace(command.Nome))
                throw new InvalidOperationException("Name is required");

            if (command.Preco <= 0)
                throw new InvalidOperationException("The price must be greater than 0.");

            if (command.CategoriaId == Guid.Empty)
                throw new InvalidOperationException("Category is required");

            await repo.UpdateAsync(product);

            return await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
