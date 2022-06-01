using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Cargo
    {
        public int codigo_Cargo { get; set; }
        public string nome { get; set; }
        public string setor { get; set; }

        public List<string> validarObjeto(Cargo pCargo)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrEmpty(pCargo.nome) == true)
            {
                lstRetorno.Add("Informe o nome do cargo");
            }
            if (string.IsNullOrEmpty(pCargo.nome) == true)
            {
                lstRetorno.Add("Informe o nome do setor");
            }

            return lstRetorno;
        }
    }
}
