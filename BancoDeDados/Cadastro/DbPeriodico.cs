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
    public class DbPeriodico:ComandoSQL
    {
        public Periodico Gravar(Periodico pPeriodico)
        {
            pPeriodico.codigo_Periodico = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Periodico");
            comando.InsertSqlObj("codigo_Periodico ", $"{pPeriodico.codigo_Periodico}");
            comando.InsertSqlObj("codigo_Empresa", $"'{pPeriodico.empresa.codigo_Empresa}'");
            comando.InsertSqlObj("nome", $"'{pPeriodico.Nome}'");
            comando.InsertSqlObj("autor", $"'{pPeriodico.Autor}'");
            comando.InsertSqlObj("editora", $"'{pPeriodico.Editora}'");
            comando.InsertSqlObj("status", $"'{pPeriodico.Status.descStatusPeriodico}'",true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pPeriodico;
            }
            else
            {
                return null;
            }
        }

        public Periodico Atualizar(Periodico pPeriodico)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Periodico");
            comando.UpdateSqlObj("codigo_Empresa", $"'{pPeriodico.empresa.codigo_Empresa}'");
            comando.UpdateSqlObj("nome", $"'{pPeriodico.Nome}'");
            comando.UpdateSqlObj("autor", $"'{pPeriodico.Autor}'");
            comando.UpdateSqlObj("editora", $"'{pPeriodico.Editora}'");
            comando.UpdateSqlObj("status", $"'{pPeriodico.Status.descStatusPeriodico}'",true);
            comando.strWhere = $" where codigo_Periodico = {pPeriodico.codigo_Periodico}"; 


            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pPeriodico;
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
            sql.CommandText = "select max(codigo_Periodico) as maiorCodigo from Periodico";

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

        private Periodico CarregarDado(Periodico pPeriodico, DataRow rd)
        {
            pPeriodico.codigo_Periodico = Int32.Parse(rd["codigo_Periodico"].ToString());
            pPeriodico.empresa = new Empresa();
            pPeriodico.empresa.codigo_Empresa = Int32.Parse(rd["codigo_Empresa"].ToString());
            pPeriodico.Nome = rd["nome"].ToString();
            pPeriodico.Editora = rd["editora"].ToString();
            pPeriodico.Autor = rd["autor"].ToString();
            pPeriodico.Status = new StatusPeriodico().Carregar(rd["status"].ToString());

            return pPeriodico;
        }

        public List<Periodico> Listar(Periodico pPeriodico)
        {
            List<Periodico> lstPeriodicos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Periodico";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstPeriodicos = new List<Periodico>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Periodico periodicoCarregar = new Periodico();

                    periodicoCarregar = this.CarregarDado(periodicoCarregar, rd);

                    lstPeriodicos.Add(periodicoCarregar);
                }

                return lstPeriodicos;
            }
        }

        public Periodico CarregarPeriodico(int pCodPeriodico)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Periodico";
            sql.CommandText += $" where codigo_Periodico = {pCodPeriodico}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Periodico periodicoCarregar = new Periodico();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                periodicoCarregar = this.CarregarDado(periodicoCarregar, rd);

                return periodicoCarregar;
            }
        }

        public int Excluir(int pCodPeriodico)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Periodico");
            sql.Append($" where codigo_Periodico = {pCodPeriodico}");


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
    }
}
