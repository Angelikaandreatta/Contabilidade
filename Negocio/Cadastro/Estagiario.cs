using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Estagiario
    {
        public int codigo_Estagiario { get; set; }

        public Endereco endereco { get; set; }

        public Efetivo efetivo { get; set; }

        public Empresa empresa { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string email { get; set; }

        public DateTime? data_Nascimento { get; set; }

        public string nome_curso { get; set; }

        public DateTime? data_Inicio_Curso { get; set; }

        public List<string> validarObjeto(Estagiario pEstagiario)
        {
            List<string> lstRetorno = new List<string>();

            if (pEstagiario.endereco == null && pEstagiario.endereco.codigo_Endereco <= 0)
            {
                lstRetorno.Add("Informe o endereço do estagiario");
            }
            if (pEstagiario.efetivo == null && pEstagiario.efetivo.codigo_efetivo <= 0)
            {
                lstRetorno.Add("Informe se o estagiario é efetivo");
            }
            if (pEstagiario.empresa == null && pEstagiario.endereco.codigo_Endereco <= 0)
            {
                lstRetorno.Add("Informe a empresa do estagiario");
            }
            if (string.IsNullOrWhiteSpace(pEstagiario.nome) == true)
            {
                lstRetorno.Add("Informe o nome do efetivo");
            }
            if (string.IsNullOrWhiteSpace(pEstagiario.cpf) == true)
            {
                lstRetorno.Add("Informe o nome do efetivo");
            }
            if (string.IsNullOrWhiteSpace(pEstagiario.email) == true)
            {
                lstRetorno.Add("Informe o email do estagiario");
            }
            if (string.IsNullOrWhiteSpace(pEstagiario.nome_curso) == true)
            {
                lstRetorno.Add("Informe a data de nascimento do efetivo");
            }
            if (string.IsNullOrWhiteSpace(data_Inicio_Curso.ToString()) == true)
            {
                lstRetorno.Add("Informe a data de inicio do curso do estagiario");
            }

            return lstRetorno;
        }
    }
}

