using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Abstractions.Persistence;
using SnackGestor.Application.Produtos.Commands;
using SnackGestor.Domain.Abstractions;
using SnackGestor.Domain.Models;

namespace SnackGestor.Application.Produtos.Handlers
{
    public class CreateProductCommandHandler(IProdutoRepository repo, IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
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
