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
            pLogin.codigo_Login = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Tb_Login");
            comando.InsertSqlObj("codigo_Login", $"{pLogin.codigo_Login}");
            comando.InsertSqlObj("nome", $"{pLogin.nome}");
            comando.InsertSqlObj("email", $"{pLogin.email}");
            comando.InsertSqlObj("cargo", $"{pLogin.cargo}");
            comando.InsertSqlObj("senha", $"{pLogin.senha}");

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
            comando.UpdateTabela("Tb_Login");
            comando.UpdateSqlObj("nome", $"'{pLogin.nome}'");
            comando.UpdateSqlObj("email", $"'{pLogin.email}'");
            comando.UpdateSqlObj("cargo", $"'{pLogin.cargo}'");
            comando.UpdateSqlObj("senha", $"'{pLogin.senha}'");
            comando.strWhere = $" where codigo_Login = {pLogin.codigo_Login}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pLogin;
            }
            else
            {
                return null;
            }
        }

        public int ProximoCodigo()
        {
            int codigoRetorno = 0;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select max(codigo_Login) as maiorCodigo from tb_Login";

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

        private Login CarregarDado(Login pLogin, DataRow rd)
        {
            pLogin.codigo_Login = Int32.Parse(rd["codigo_Login"].ToString());
            pLogin.nome = rd["nome"].ToString();
            pLogin.email = rd["email"].ToString();
            pLogin.cargo = rd["cargo"].ToString();

            return pLogin;
        }

        public List<Login> Listar(Login pLogin)
        {
            List<Login> lstLogins = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select codigo_Login, email, nome, cargo  from Tb_Login";

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

        public Login CarregarLogin(int pCodLogin)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select  codigo_Login, email, nome, cargo from Tb_Login";
            sql.CommandText += $" where codigo_Login = '{pCodLogin}'";

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

        public int Excluir(int pCodLogin)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Tb_Login");
            sql.Append($" where codigo_Login = '{pCodLogin}'");


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

        public bool Logar(Login pLogin)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = $"select DISTINCT  email, senha from tb_Login where codigo_Login = '{pLogin.codigo_Login}'";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rde = dataTable.Rows[0];
                DataRow rds = dataTable.Rows[1];

                string email = rde["email"].ToString();
                string senha = rds["senha"].ToString();

                if (email == pLogin.email && senha == pLogin.senha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
