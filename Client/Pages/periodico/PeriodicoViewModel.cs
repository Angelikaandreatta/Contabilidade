using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.periodico
{
    public class PeriodicoViewModel
    {
        public PeriodicoViewModel()
        {
            this.Status = new vmStatusPeriodico();
        }

        public string Codigo_Periodico { get; set; }
        public Empresa Empresa { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public vmStatusPeriodico Status { get; set; }
    }

    public class vmStatusPeriodico
    {
        public int codStatusPeriodico { get; set; }
        public string descStatusPeriodico { get; set; }
    }
}
