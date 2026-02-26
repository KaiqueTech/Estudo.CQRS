using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Commands.Produtos;
using SnackGestor.Domain.Abstractions;

namespace SnackGestor.Application.Handlers.Produtos
{
    public class DeleteProductCommandHandler(IProdutoRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var produto = await repo.GetByIdAsync(command.Id);
            if (produto is null)
                throw new KeyNotFoundException("Produto não existe");

            await repo.DeleteProduct(produto);

            await unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
