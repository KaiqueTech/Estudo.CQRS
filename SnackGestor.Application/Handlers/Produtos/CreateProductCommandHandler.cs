using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Commands.Produtos;
using SnackGestor.Domain.Abstractions;
using SnackGestor.Domain.Models;

namespace SnackGestor.Application.Handlers.Produtos
{
    public class CreateProductCommandHandler(IProdutoRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var exists = await repo.ExistingProductName(command.Nome);
            if(exists)
                throw new InvalidOperationException("Produto já cadastrado.");

            var produto = ProdutoModel.CreateProduct
                (
                    command.Nome,
                    command.Preco,
                    command.CategoriaId
                );

            await repo.AddAsync(produto);

            await unitOfWork.CommitAsync(cancellationToken);

            return produto.Id;
        }
    }
}
