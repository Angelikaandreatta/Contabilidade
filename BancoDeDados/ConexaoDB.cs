using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class ConexaoDB
    {
        SqlConnection con = new SqlConnection();

        public ConexaoDB()
        {
            con.ConnectionString = @"Server=tcp:uni-projects.database.windows.net,1433;Initial Catalog=Banco_contabilidade;Persist Security Info=False;User ID=banco_admin;Password=Contabilidade2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
