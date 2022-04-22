using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    class Contato
    {
        public int cod_Contato { get; set; }

        public string nome_Contato { get; set; }

        public string CPF { get; set; }

        public string celular { get; set; }

        public string email { get; set; }

        public List<string> validarObjeto(Contato pContato)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pContato.cod_Contato.ToString()))
            {
                lstRetorno.Add("Informe o código do contato");
            }
            if (string.IsNullOrWhiteSpace(pContato.nome_Contato))
            {
                lstRetorno.Add("Informe o nome do contato");
            }
            if (string.IsNullOrWhiteSpace(pContato.CPF))
            {
                lstRetorno.Add("Informe o CPF do contato");
            }
            if (string.IsNullOrWhiteSpace(pContato.celular))
            {
                lstRetorno.Add("Informe o celular do contato");
            }
            if (string.IsNullOrWhiteSpace(pContato.email))
            {
                lstRetorno.Add("Informe o E-mail do contato");
            }

            return lstRetorno;
        }
    }
}
