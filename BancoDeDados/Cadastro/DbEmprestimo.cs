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
            pEmprestimo.cod_Emprestimo = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Emprestimo");
            comando.InsertSqlObj("codigo_Emprestimo", $"{pEmprestimo.cod_Emprestimo}");
            comando.InsertSqlObj("codigo_Efetivo", $"{pEmprestimo.efetivo.codigo_efetivo}");
            comando.InsertSqlObj("codigo_Periodico", $"'{pEmprestimo.periodico.codigo_Periodico}'");
            comando.InsertSqlObj("data_Emprestimo", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Now.Date)}");
            comando.InsertSqlObj("data_Devolucao", $"{new FormatarValores().FormatarDataParaSQL(pEmprestimo.data_Devolucao.Value)}", true);

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
            comando.UpdateTabela("Emprestimo");
            comando.UpdateSqlObj("codigo_Efetivo", $"{pEmprestimo.efetivo.codigo_efetivo}");
            comando.UpdateSqlObj("codigo_Periodico", $"'{pEmprestimo.periodico.codigo_Periodico}'");
            comando.UpdateSqlObj("data_Devolucao", $"{new FormatarValores().FormatarDataParaSQL(pEmprestimo.data_Devolucao.Value)}", true);
            comando.strWhere = $" where codigo_Emprestimo = {pEmprestimo.cod_Emprestimo}";

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
            sql.CommandText = "SELECT max(codigo_Emprestimo) as maiorCodigo FROM Emprestimo";

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

        private Emprestimo CarregarDado(Emprestimo pEmprestimo, DataRow rd)
        {
            pEmprestimo.cod_Emprestimo = Int32.Parse(rd["codigo_Emprestimo"].ToString());
            pEmprestimo.efetivo = new Efetivo();
            pEmprestimo.efetivo = new DbEfetivo().CarregarEfetivo(Int32.Parse(rd["codigo_Efetivo"].ToString()));
            pEmprestimo.periodico = new Periodico();
            pEmprestimo.periodico = new DbPeriodico().CarregarPeriodico(Int32.Parse(rd["codigo_Periodico"].ToString()));
            pEmprestimo.data_Emprestimo = DateTime.Parse(rd["data_Emprestimo"].ToString());
            pEmprestimo.data_Devolucao = DateTime.Parse(rd["data_Devolucao"].ToString());

            return pEmprestimo;
        }

        public List<Emprestimo> Listar(string pStatus, int pCodEmp)
        {
            List<Emprestimo> lstEmprestimos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "SELECT e.*, p.status, p.codigo_Empresa, emp.nome FROM Emprestimo as e";
            sql.CommandText += " inner join Periodico as P";
            sql.CommandText += " on e.codigo_Periodico = P.codigo_Periodico";
            sql.CommandText += " inner join empresa as emp";
            sql.CommandText += " on p.codigo_empresa = emp.codigo_empresa";
            sql.CommandText += $" where p.codigo_Empresa = {pCodEmp}";
            if (string.IsNullOrWhiteSpace(pStatus) == false)
            {
                sql.CommandText += $" and status = '{pStatus}'";
            }

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

        public Emprestimo CarregarEmprestimo(int pCodEmprestimo)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Emprestimo";
            sql.CommandText += $" where codigo_Emprestimo = '{pCodEmprestimo}'";

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
