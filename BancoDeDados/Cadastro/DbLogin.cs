using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeDados.UtilDb;

namespace BancoDeDados.Cadastro
{
    public class DbLogin : ComandoSQL
    {
        public Login Gravar(Login pLogin)
        {

            pLogin.id = this.ProximoCodigo();
            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Login");
            comando.InsertSqlObj("id", $"{pLogin.id}");
            comando.InsertSqlObj("codigo_Empresa", $"{pLogin.empresa.codigo_Empresa}");
            comando.InsertSqlObj("usuario", $"'{pLogin.usuario}'");
            comando.InsertSqlObj("senha", $"'{pLogin.senha}'", true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pLogin;
            }
            else
            {
                return null;
            }
        }

        public Login Atualizar(Login pLogin)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Login");
            comando.UpdateSqlObj("codigo_Empresa", $"{pLogin.empresa.codigo_Empresa}");
            comando.UpdateSqlObj("usuario", $"'{pLogin.usuario}'");
            comando.UpdateSqlObj("senha", $"'{pLogin.senha}'", true);
            comando.strWhere = $" where id = {pLogin.id}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pLogin;
            }
            else
            {
                return null;
            }
        }

        private Login CarregarDado(Login pLogin, DataRow rd)
        {
            pLogin.id = Int32.Parse(rd["id"].ToString());
            pLogin.empresa = new Empresa();
            pLogin.empresa.codigo_Empresa = Int32.Parse(rd["codigo_Empresa"].ToString());
            pLogin.usuario = rd["usuario"].ToString();
            pLogin.senha = rd["senha"].ToString();

            return pLogin;
        }

        public List<Login> Listar(Login pLogin)
        {
            List<Login> lstLogins = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Login";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstLogins = new List<Login>();

                foreach (DataRow rd in dataTable.Rows)
                {
                    Login loginCarregar = new Login();

                    loginCarregar = this.CarregarDado(loginCarregar, rd);

                    lstLogins.Add(loginCarregar);
                }

                return lstLogins;
            }
        }

        public Login CarregarLogin(int pIdLogin)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Login";
            sql.CommandText += $" where id = {pIdLogin}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Login loginCarregar = new Login();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                loginCarregar = this.CarregarDado(loginCarregar, rd);

                return loginCarregar;
            }
        }

        public int Excluir(int pIdLogin)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Login");
            sql.Append($" where id = '{pIdLogin}'");


            if (ExecutarReader(sql.ToString()) == 1)
            {
                retorno = 1;
            }
            else
            {
                retorno = -1;
            }

            return retorno;
        }

        public int ProximoCodigo()
        {
            int codigoRetorno = 0;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select max(id) as maiorCodigo from Login";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                string UltimoCod = rd["maiorCodigo"].ToString();

                if (string.IsNullOrWhiteSpace(UltimoCod) == false)
                {
                    codigoRetorno = Int32.Parse(rd["maiorCodigo"].ToString());
                }
                codigoRetorno += 1;

                return codigoRetorno;
            }
        }

    }
}
