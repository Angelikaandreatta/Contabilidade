using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Empresa
    {
        public int codigo_Empresa { get; set; }
        public string nome { get; set; }

        //fazer validações

        public List<string> validarObjeto(Empresa pEmpresa)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrEmpty(pEmpresa.nome) == true)
            {
                lstRetorno.Add("Informe o nome da empresa");
            }

            return lstRetorno;
        }

    }
}
