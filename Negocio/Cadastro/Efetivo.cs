using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Efetivo
    {
        public int codigo_efetivo { get; set; }

        public Endereco endereco { get; set; }

        public Empresa empresa { get; set; }

        public Cargo cargo { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string email { get; set; }

        public DateTime? data_Nascimento { get; set; }

        public List<string> validarObjeto(Efetivo pEfetivo)
        {
            List<string> lstRetorno = new List<string>();

            if (pEfetivo.endereco == null && pEfetivo.endereco.codigo_Endereco <= 0)
            {
                lstRetorno.Add("Informe o endereço do efetivo");
            }
            if (pEfetivo.empresa == null && pEfetivo.endereco.codigo_Endereco <= 0)
            {
                lstRetorno.Add("Informe a empresa do efetivo");
            }
            if (pEfetivo.cargo == null && pEfetivo.cargo.codigo_Cargo <= 0)
            {
                lstRetorno.Add("Informe o cargo do efetivo");
            }
            if (string.IsNullOrWhiteSpace(pEfetivo.nome) == true)
            {
                lstRetorno.Add("Informe o nome do efetivo");
            }
            if(string.IsNullOrWhiteSpace(pEfetivo.cpf) == true)
            {
                lstRetorno.Add("Informe o cpf do efetivo");
            }
            if (string.IsNullOrWhiteSpace(pEfetivo.email) == true)
            {
                lstRetorno.Add("Informe o email do efetivo");
            }
            if (string.IsNullOrWhiteSpace(pEfetivo.data_Nascimento.ToString()) == true)
            {
                lstRetorno.Add("Informe a data de nascimento do efetivo");
            }

            return lstRetorno;
        }


    }
}
