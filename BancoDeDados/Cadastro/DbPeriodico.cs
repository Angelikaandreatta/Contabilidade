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
    public class DbPeriodico
    {
        public Periodico Gravar(Periodico pPeriodico)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("tb_Periodico");
            comando.InsertSqlObj("cod_Periodico ", $"{this.ProximoCodigo()}");
            comando.InsertSqlObj("nome_Periodico", $"'{pPeriodico.nome_Periodico}'");
            comando.InsertSqlObj("editora", $"'{pPeriodico.editora}'");
            comando.InsertSqlObj("autor", $"'{pPeriodico.autor}'");
            comando.InsertSqlObj("exemplar", $"'{pPeriodico.exemplar}'");

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
            comando.UpdateTabela("tb_Periodico");
            comando.UpdateSqlObj("nome_Periodico", $"'{pPeriodico.nome_Periodico}'");
            comando.UpdateSqlObj("editora", $"'{pPeriodico.editora}'");
            comando.UpdateSqlObj("autor", $"'{pPeriodico.autor}'");
            comando.UpdateSqlObj("exemplar", $"'{pPeriodico.exemplar}'");
            

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
            sql.CommandText = "select max(cod_Periodico) as maiorCodigo from tb_Periodico";

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

        private Periodico CarregarDado(Periodico pPeriodico, DataRow rd)
        {
            pPeriodico.cod_Periodico = Int32.Parse(rd["cod_Periodico"].ToString());
            pPeriodico.nome_Periodico = rd["nome_Periodico"].ToString();
            pPeriodico.editora = rd["editora"].ToString();
            pPeriodico.autor = rd["autor"].ToString();
            pPeriodico.exemplar = rd["exemplar"].ToString();

            return pPeriodico;
        }

        public List<Periodico> Listar(Periodico pPeriodico)
        {
            List<Periodico> lstPeriodicos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Periodico";

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

        public Periodico CarregarPeriodico(Periodico pPeriodico)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Periodico";
            sql.CommandText += $" where cod_Periodico = '{pPeriodico.cod_Periodico}'";

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
    }
}
