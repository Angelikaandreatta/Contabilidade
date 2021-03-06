using System;
using Negocio.Cadastro;
namespace Projeto_Contabilidade.Client.Pages.funcionario
{
    public class EstagiarioViewModel : FuncionarioViewModel
    {
        private string codigo_estagiario { get; set; }
        public string Codigo_Estagiario { get => codigo_estagiario; set => codigo_estagiario = value; }
        private string nome_curso { get; set; }
        public string Nome_Curso { get => nome_curso; set => nome_curso = value; }
        private DateTime? data_inicio_curso { get; set; }
        public DateTime? Data_Inicio_Curso { get => data_inicio_curso; set => data_inicio_curso = value; }
        public Efetivo Efetivo { get; set; } = null;

        public EstagiarioViewModel()
        {
            this.Efetivo = new Efetivo();
        }
    }
}
