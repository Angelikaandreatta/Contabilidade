using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Cadastro
{
    public class DbEmpresa
    {
        private Empresa CarregarDado(Empresa pEmpresa, DataRow rd)
        {
            pEmpresa.codigo_Empresa = Int32.Parse(rd["codigo_Empresa"].ToString());
            pEmpresa.nome = rd["nome"].ToString();

            return pEmpresa;
        }

        public Empresa CarregarEmpresa(int pCodEmpresa)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Empresa";
            sql.CommandText += $" where codigo_Empresa = {pCodEmpresa}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Empresa empresaCarregar = new Empresa();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                empresaCarregar = this.CarregarDado(empresaCarregar, rd);

                return empresaCarregar;
            }
        }
    }
}
