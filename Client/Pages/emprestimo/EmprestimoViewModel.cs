using Negocio.Cadastro;
using System;

namespace Projeto_Contabilidade.Client.Pages.emprestimo
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel()
        {
            this.Efetivo = new Efetivo();
            this.Periodico = new Periodico();
        }

        public string codigo_Emprestimo { get; set; } = "";

        public Efetivo Efetivo { get; set; } = null;

        public Periodico Periodico { get; set; } = null;

        public DateTime? data_Emprestimo { get; set; } = null;

        public DateTime? data_Devolucao { get; set; } = null;
    }
}
