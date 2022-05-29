using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.periodico
{
    public class PeriodicoViewModel
    {
        public string Codigo_Periodico { get; set; }
        public Empresa Empresa { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Status { get; set; }
    }
}
