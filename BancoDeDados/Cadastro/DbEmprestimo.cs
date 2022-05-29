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
    public class DbEmprestimo
    {
        public Emprestimo Gravar(Emprestimo pEmprestimo)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("tb_Emprestimo");
            comando.InsertSqlObj("cod_Emprestimo", $"{this.ProximoCodigo()}");
            comando.InsertSqlObj("quantidade", $"'{pEmprestimo.quantidade}'");
            comando.InsertSqlObj("juros", $"'{pEmprestimo.juros}'");
            comando.InsertSqlObj("data_Emprestimo", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Now.Date)}");
            comando.InsertSqlObj("data_Devolucao", $"{pEmprestimo.data_Devolucao}");
            comando.InsertSqlObj("cod_Periodico", $"'{pEmprestimo.cod_Periodico}'");

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pEmprestimo;
            }
            else
            {
                return null;
            }
        }

        public Emprestimo Atualizar(Emprestimo pEmprestimo)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("tb_Emprestimo");
            comando.UpdateSqlObj("quantidade", $"'{pEmprestimo.quantidade}'");
            comando.UpdateSqlObj("juros", $"'{pEmprestimo.juros}'");
            comando.UpdateSqlObj("data_Emprestimo", $"{DateTime.Now.Date}");
            comando.UpdateSqlObj("data_Devolucao", $"{DateTime.Now.Date}");
            comando.UpdateSqlObj("cod_Periodico", $"'{pEmprestimo.cod_Periodico}'");

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pEmprestimo;
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
            sql.CommandText = "select max(cod_Emprestimo) as maiorCodigo from tb_Emprestimo";

            using (SqlDataReader dt = sql.ExecuteReader())
            {

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                codigoRetorno = Int32.Parse(rd["maiorCodigo"].ToString());
                codigoRetorno += 1;

                return codigoRetorno;
            }
        }

        private Emprestimo CarregarDado(Emprestimo pEmprestimo, DataRow rd)
        {
            pEmprestimo.cod_Emprestimo = Int32.Parse(rd["cod_Emprestimo"].ToString());
            pEmprestimo.quantidade = Int32.Parse(rd["quantidade"].ToString());
            pEmprestimo.juros = Int32.Parse(rd["juros"].ToString());
            pEmprestimo.cod_Periodico = rd["cod_Periodico"].ToString();

            return pEmprestimo;
        }

        public List<Emprestimo> Listar(Emprestimo pEmprestimo)
        {
            List<Emprestimo> lstEmprestimos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Emprestimo";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstEmprestimos = new List<Emprestimo>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Emprestimo emprestimoCarregar = new Emprestimo();

                    emprestimoCarregar = this.CarregarDado(emprestimoCarregar, rd);

                    lstEmprestimos.Add(emprestimoCarregar);
                }

                return lstEmprestimos;
            }
        }

        public Emprestimo CarregarEmprestimo(Emprestimo pEmprestimo)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Emprestimo";
            sql.CommandText += $" where cod_Emprestimo = '{pEmprestimo.cod_Emprestimo}'";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Emprestimo emprestimoCarregar = new Emprestimo();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                emprestimoCarregar = this.CarregarDado(emprestimoCarregar, rd);

                return emprestimoCarregar;
            }
        }
    }
}
