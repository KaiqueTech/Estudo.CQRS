using System;
using System.Collections.Generic;
using System.Text;

namespace SnackGestor.Application.DTOs.Produtos
{
    public record CreateProdutoDto(string Nome, decimal Preco, Guid CategoriaId);
}
