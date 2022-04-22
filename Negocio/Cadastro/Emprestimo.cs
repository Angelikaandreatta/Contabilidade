using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Emprestimo
    {
        public int cod_Emprestimo { get; set; }

        public int quantidade { get; set; }

        public int juros { get; set; }

        public DateTime? data_Emprestimo { get; set; }

        public DateTime? data_Devolucao { get; set; }

        public string cod_Periodico { get; set; }

        public List<string> validarObjeto(Emprestimo pEmprestimo)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pEmprestimo.cod_Emprestimo.ToString()))
            {
                lstRetorno.Add("Informe o código do empréstimo");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.quantidade.ToString()))
            {
                lstRetorno.Add("Informe a quantidade do empréstimo");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.juros.ToString()))
            {
                lstRetorno.Add("Informe a quantidade de juros");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.data_Emprestimo.ToString()))
            {
                lstRetorno.Add("Informe a data que foi realizado o empréstimo");
            }

            if (string.IsNullOrWhiteSpace(pEmprestimo.data_Devolucao.ToString()))
            {
                lstRetorno.Add("Informe a data que foi devolvido o empréstimo");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.cod_Periodico))
            {
                lstRetorno.Add("Informe o código do periódico");
            }

            return lstRetorno;
        }
    }
}
