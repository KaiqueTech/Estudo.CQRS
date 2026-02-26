using SnackGestor.Application.Abstractions.Messaging;

namespace SnackGestor.Application.Commands.Categorias
{
    public record CreateCategoryCommand(string Name) : ICommand<Guid>;
}
