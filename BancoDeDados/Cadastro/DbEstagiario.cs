using BancoDeDados.UtilDb;
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
    public class DbEstagiario:ComandoSQL
    {
        private Estagiario CarregarDado(Estagiario pEstagiario, DataRow rd)
        {
            pEstagiario.codigo_Estagiario = Int32.Parse(rd["codigo_Estagiario"].ToString());
            pEstagiario.endereco = new Endereco();
            pEstagiario.endereco = new DbEndereco().CarregarEndereco(Int32.Parse(rd["codigo_Endereco"].ToString()));
            pEstagiario.efetivo = new Efetivo();
            pEstagiario.efetivo = new DbEfetivo().CarregarEfetivo(Int32.Parse(rd["codigo_Efetivo"].ToString()));
            pEstagiario.empresa = new Empresa();
            pEstagiario.empresa = new DbEmpresa().CarregarEmpresa(Int32.Parse(rd["codigo_Empresa"].ToString()));
            pEstagiario.nome = rd["nome"].ToString();
            pEstagiario.email = rd["cpf"].ToString();
            pEstagiario.email = rd["email"].ToString();
            pEstagiario.data_Nascimento = DateTime.Parse(rd["data_Nascimento"].ToString());
            pEstagiario.nome_curso = rd["nome_Curso"].ToString();
            pEstagiario.data_Inicio_Curso = DateTime.Parse(rd["data_Inicio_Curso"].ToString());

            return pEstagiario;
        }

        public Estagiario CarregarEstagiario(int pCodEstagiario)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Estagiario";
            sql.CommandText += $" where codigo_Estagiario = {pCodEstagiario}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Estagiario estagiarioCarregar = new Estagiario();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                estagiarioCarregar = this.CarregarDado(estagiarioCarregar, rd);

                return estagiarioCarregar;
            }
        }

        public Estagiario Gravar(Estagiario pEstagiario)
        {
            pEstagiario.codigo_Estagiario = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Estagiario");
            comando.InsertSqlObj("codigo_Estagiario", $"{pEstagiario.codigo_Estagiario}");
            comando.InsertSqlObj("codigo_Efetivo", $"{pEstagiario.efetivo.codigo_efetivo}");
            comando.InsertSqlObj("codigo_Endereco", $"{pEstagiario.endereco.codigo_Endereco}");
            comando.InsertSqlObj("codigo_Empresa", $"{pEstagiario.empresa.codigo_Empresa}");
            comando.InsertSqlObj("nome", $"'{pEstagiario.nome}'");
            comando.InsertSqlObj("cpf", $"'{pEstagiario.cpf}'");
            comando.InsertSqlObj("email", $"'{pEstagiario.email}'");
            comando.InsertSqlObj("data_Nascimento", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEstagiario.data_Nascimento.ToString()))}");
            comando.InsertSqlObj("nome_curso", $"'{pEstagiario.nome_curso}'");
            comando.InsertSqlObj("data_Inicio_Curso", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEstagiario.data_Inicio_Curso.ToString()))}", true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pEstagiario;
            }
            else
            {
                return null;
            }
        }

        public Estagiario Atualizar(Estagiario pEstagiario)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Estagiario");
            comando.UpdateSqlObj("codigo_Efetivo", $"{pEstagiario.efetivo.codigo_efetivo}");
            comando.UpdateSqlObj("codigo_Endereco", $"{pEstagiario.endereco.codigo_Endereco}");
            comando.UpdateSqlObj("codigo_Empresa", $"{pEstagiario.empresa.codigo_Empresa}");
            comando.UpdateSqlObj("nome", $"'{pEstagiario.nome}'");
            comando.UpdateSqlObj("cpf", $"'{pEstagiario.cpf}'");
            comando.UpdateSqlObj("email", $"'{pEstagiario.email}'");
            comando.UpdateSqlObj("data_Nascimento", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEstagiario.data_Nascimento.ToString()))}");
            comando.UpdateSqlObj("nome_Curso", $"'{pEstagiario.nome_curso}'");
            comando.UpdateSqlObj("data_Inicio_Curso", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEstagiario.data_Inicio_Curso.ToString()))}", true);
            comando.strWhere = $" where codigo_Estagiario = {pEstagiario.codigo_Estagiario}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pEstagiario;
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
            sql.CommandText = "select max(codigo_Estagiario) as maiorCodigo from Estagiario";

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

        public List<Estagiario> Listar()
        {
            List<Estagiario> lstEstagiario = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Estagiario";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstEstagiario = new List<Estagiario>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Estagiario estagiarioCarrager = new Estagiario();

                    estagiarioCarrager = this.CarregarDado(estagiarioCarrager, rd);

                    lstEstagiario.Add(estagiarioCarrager);
                }

                return lstEstagiario;
            }
        }

        public int Excluir(int pCodEstagiario)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Efetivo");
            sql.Append($" where codigo_Estagiario = {pCodEstagiario}");


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
