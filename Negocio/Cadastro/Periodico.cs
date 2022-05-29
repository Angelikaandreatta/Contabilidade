using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Periodico
    {
        public int codigo_Periodico { get; set; }
        public Empresa empresa { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Status { get; set; }
        public List<string> validarObjeto(Periodico pPeriodico)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pPeriodico.Nome))
            {
                lstRetorno.Add("Informe o nome do periódico");
            }
            if (string.IsNullOrWhiteSpace(pPeriodico.Editora))
            {
                lstRetorno.Add("Informe o nome da editora");
            }
            if (string.IsNullOrWhiteSpace(pPeriodico.Autor))
            {
                lstRetorno.Add("Informe o nome do autor");
            }
            if (pPeriodico.empresa.codigo_Empresa <= 0)
            {
                lstRetorno.Add("Informe a empresa do periodico");
            }

            return lstRetorno;
        }
    }
}
