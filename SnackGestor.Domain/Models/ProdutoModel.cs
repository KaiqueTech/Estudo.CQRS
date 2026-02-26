
using SnackGestor.Domain.Common;

namespace SnackGestor.Domain.Models
{
    public class ProdutoModel : BaseModel
    {
        public string Nome { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
        public Guid CategoriaId { get; private set; }

        protected ProdutoModel() { }

        public ProdutoModel(string name, decimal preco, Guid categoriaId) 
        {
            Nome = name;
            Preco = preco;
            Ativo = true;
            CategoriaId = categoriaId;
        }

        public static ProdutoModel CreateProduct(string nome, decimal preco, Guid categoriaId) 
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("name is required");
            if (preco <= 0)
                throw new ArgumentNullException("preco deve ser maior que 0");

            return new ProdutoModel(nome, preco, categoriaId);

        }

        public void Ativar()
        {
           Ativo = true;
           SetUpdatedAt();
        }

        public void Desativar()
        {
            Ativo = false;
            SetUpdatedAt();
        }

        public void UpdateProduct(string name, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name is required");
            if (preco <= 0)
                throw new ArgumentNullException("preco deve ser maior que 0");

            Nome = name;
            Preco = preco;

            SetUpdatedAt();
        }
    }
}
