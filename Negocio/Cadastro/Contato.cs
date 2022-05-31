using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Contato
    {

        public int cod_Contato { get; set; }

        public Cliente cliente { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string setor { get; set; }


        public List<string> validarObjeto(Contato pContato)
        {
            List<string> lstRetorno = new List<string>();

            if (pContato.cliente == null && pContato.cliente.codigo_Cliente <= 0)
            {
                lstRetorno.Add("Informe o cliente.");
            }
            if (string.IsNullOrWhiteSpace(pContato.nome))
            {
                lstRetorno.Add("Informe o nome do contato.");
            }
            if (string.IsNullOrWhiteSpace(pContato.email))
            {
                lstRetorno.Add("Informe o enmail do contato.");
            }
            if (string.IsNullOrWhiteSpace(pContato.telefone))
            {
                lstRetorno.Add("Informe o telefone do contato.");
            }
            if (string.IsNullOrWhiteSpace(pContato.setor))
            {
                lstRetorno.Add("Informe o setor do contato.");
            }

            return lstRetorno;
        }
    }
}
