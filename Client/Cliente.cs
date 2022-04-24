using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Cliente
    {
        public int cod_Cliente { get; set; }

        public string nome_Cliente { get; set; }

        public string cnpj { get; set; }

        public string ie { get; set; }

        public string email { get; set; }

        public string rua { get; set; }

        public string numero { get; set; }

        public string bairro { get; set; }

        public string cep { get; set; }

        public string uf { get; set; }

        public DateTime? data_Cadastro { get; set; }

        public int cod_Cidade { get; set; }

        public string nome_Cidade { get; set; }

        public int cod_Contato { get; set; }

        public List<string> validarObjeto(Cliente pCliente)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pCliente.nome_Cliente))
            {
                lstRetorno.Add("Informe o nome do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.cnpj))
            {
                lstRetorno.Add("Informe o cnpj do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.ie))
            {
                lstRetorno.Add("Informe a ie do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.email))
            {
                lstRetorno.Add("Informe o email do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.rua))
            {
                lstRetorno.Add("Informe a rua do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.numero))
            {
                lstRetorno.Add("Informe o numero do local");
            }
            if (string.IsNullOrWhiteSpace(pCliente.bairro))
            {
                lstRetorno.Add("Informe o bairro do local");
            }
            if (string.IsNullOrWhiteSpace(pCliente.cep))
            {
                lstRetorno.Add("Informe o cep do local");
            }
            if (string.IsNullOrWhiteSpace(pCliente.uf))
            {
                lstRetorno.Add("Informe a uf do cliente");
            }
            if (pCliente.cod_Cidade < 0)
            {
                lstRetorno.Add("Informe o codigo da cidade do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.nome_Cidade))
            {
                lstRetorno.Add("Informe a cidade do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.cod_Contato.ToString()))
            {
                lstRetorno.Add("Informe o código do contrato");
            }

            return lstRetorno;
        }
    }
}
