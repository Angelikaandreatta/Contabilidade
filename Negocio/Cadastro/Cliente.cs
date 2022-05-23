using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Cliente
    {
        public int codigo_Cliente { get; set; }

        public Empresa empresa { get; set; }

        public Endereco endereco { get; set; }

        public string razao_Social { get; set; }

        public string cnpj { get; set; }

        public string qtd_Empregado { get; set; }

        public List<string> validarObjeto(Cliente pCliente)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pCliente.razao_Social))
            {
                lstRetorno.Add("Informe a razão Social do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.cnpj))
            {
                lstRetorno.Add("Informe o cnpj do cliente");
            }
            if (string.IsNullOrWhiteSpace(pCliente.qtd_Empregado))
            {
                lstRetorno.Add("Informe a quantidade de empregados.");
            }
            if(pCliente.empresa == null || pCliente.empresa.codigo_Empresa <= 0)
            {
                lstRetorno.Add("Selecione a empresa do cliente.");
            }
            if(pCliente.endereco == null || pCliente.endereco.codigo_Endereco <= 0)
            {
                lstRetorno.Add("Informe o endereço do Cliente");
            }

            return lstRetorno;
        }
    }
}
