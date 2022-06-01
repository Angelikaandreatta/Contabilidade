using Negocio.Cadastro;

namespace Projeto_Contabilidade.Client.Pages.funcionario
{
    public class EfetivoViewModel : FuncionarioViewModel
    {
        private string codigo_efetivo { get; set; }
        public string Codigo_Efetivo { get => codigo_efetivo; set => codigo_efetivo = value; }
        public Cargo Cargo { get; set; } = null;
        public EfetivoViewModel() : base()
        {
            this.Cargo = new Cargo();
        }
    }
}
