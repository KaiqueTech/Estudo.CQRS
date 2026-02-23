using SnackGestor.Domain.Common;
using System.Runtime.CompilerServices;

namespace SnackGestor.Domain.Models
{
    public class CategoriaModel : BaseModel
    {
        public string Name { get; private set; } = string.Empty;
        public bool Ativo { get; private set; } = true;
        
        public CategoriaModel(string name)
        {
            Name = name;
        }

        protected static CategoriaModel CreateCategory(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return new CategoriaModel(name);
        }

        public void UpdateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            SetUpdatedAt();
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
    }
}
