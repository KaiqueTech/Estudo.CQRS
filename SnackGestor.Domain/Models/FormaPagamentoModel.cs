using SnackGestor.Domain.Common;

namespace SnackGestor.Domain.Models
{
    public class FormaPagamentoModel : BaseModel
    {
        public string Name { get; private set; }
        public bool Ativa { get; private set; }

        protected FormaPagamentoModel() { }

        public FormaPagamentoModel(string nome)
        {
            Name = nome;
            Ativa = true;
        }

        public void Ativar() => Ativa = true;

        public void Desativar() => Ativa = false;
    }
}
