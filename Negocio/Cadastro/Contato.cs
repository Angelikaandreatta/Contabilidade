using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Contato
    {
        public Cliente Cliente { get; set; }

        public int cod_Contato { get; set; }

        public string nome_Contato { get; set; }

        public string setor { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        //Arrumar validações conforme o novo banco
        public List<string> validarObjeto(Contato pContato)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pContato.nome_Contato))
            {
                lstRetorno.Add("Informe o nome do contato");
            }
            if (string.IsNullOrWhiteSpace(pContato.telefone))
            {
                lstRetorno.Add("Informe o telefone do contato");
            }

            return lstRetorno;
        }
    }
}
