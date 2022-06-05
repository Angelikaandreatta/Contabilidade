using Negocio.Cadastro;
using System;

namespace Projeto_Contabilidade.Client.Pages.emprestimo
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel()
        {
            this.Efetivo = new vmEfetivo();
            this.Periodico = new vmPeriodico();
        }

        public string codigo_Emprestimo { get; set; } = "";

        public vmEfetivo Efetivo;

        public vmPeriodico Periodico;

        public DateTime? data_Emprestimo { get; set; } = null;

        public DateTime? data_Devolucao { get; set; } = null;
    }

    public class vmEfetivo
    {
        public int codigo_Efetivo { get; set; } = 0;

        public string nome { get; set; } = "";
    }

    public class vmPeriodico
    {
        public int codigo_Periodico { get; set; } = 0;

        public string nome { get; set; } = "";
    }
}
