using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.UtilDb
{
    public class FormatarValores
    {
        public string FormatarDataParaSQL(DateTime pData)
        {
            string dia = "";
            string Mes = "";
            string Ano = "";

            dia = pData.Day.ToString();
            Mes = pData.Month.ToString();
            Ano = pData.Year.ToString();

            return $"'{Mes}-{dia}-{Ano}'";
        }

    }
}
