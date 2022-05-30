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
        public int codigo_efetivo { get; set; }
        public Periodico periodico { get; set; }

        public DateTime? data_Emprestimo { get; set; }

        public DateTime? data_Devolucao { get; set; }


        public List<string> validarObjeto(Emprestimo pEmprestimo)
        {
            List<string> lstRetorno = new List<string>();

            if (pEmprestimo.codigo_efetivo <= 0)
            {
                lstRetorno.Add("Informe o codigo do efetivo");
            }
            if (pEmprestimo.periodico == null && pEmprestimo.periodico.codigo_Periodico <= 0)
            {
                lstRetorno.Add("Informe o código do periódico");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.data_Emprestimo.ToString()))
            {
                lstRetorno.Add("Informe a data que foi devolvido o empréstimo");
            }
            if (string.IsNullOrWhiteSpace(pEmprestimo.data_Devolucao.ToString()))
            {
                lstRetorno.Add("Informe a data que foi devolvido o empréstimo");
            }

            return lstRetorno;
        }
    }
}
