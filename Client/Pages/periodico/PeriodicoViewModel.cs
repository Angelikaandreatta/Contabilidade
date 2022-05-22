using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.periodico
{
    public class PeriodicoViewModel
    {
        private string codigo_Periodico = "";
        public string Codigo_Periodico { get => codigo_Periodico; set => codigo_Periodico = value; }

        private string nome = "";
        public string Nome { get => nome; set => nome = value; }

        private string descricao = "";
        public string Descricao { get => descricao; set => descricao = value; }

        private string categoria = "";
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
