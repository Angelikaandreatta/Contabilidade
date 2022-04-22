using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Periodico
    {
        public int cod_Periodico { get; set; }

        public string nome_Periodico { get; set; }

        public string editora { get; set; }

        public string autor { get; set; }

        public string exemplar { get; set; }

        public List<string> validarObjeto(Periodico pPeriodico)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pPeriodico.nome_Periodico))
            {
                lstRetorno.Add("Informe o nome do periódico");
            }
            if (string.IsNullOrWhiteSpace(pPeriodico.editora))
            {
                lstRetorno.Add("Informe o nome da editora");
            }
            if (string.IsNullOrWhiteSpace(pPeriodico.autor))
            {
                lstRetorno.Add("Informe o nome do autor");
            }
            if (string.IsNullOrWhiteSpace(pPeriodico.exemplar))
            {
                lstRetorno.Add("Informe o exemplar");
            }

            return lstRetorno;
        }
    }
}
