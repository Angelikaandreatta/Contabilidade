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
            con.ConnectionString = @"Server=LAPTOP-8SHQ4PFR;Database=bancoContabilidade;Trusted_Connection=True;";
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
