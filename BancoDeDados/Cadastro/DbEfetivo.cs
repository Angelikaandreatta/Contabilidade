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
    public class DbEfetivo:ComandoSQL
    {
        private Efetivo CarregarDado(Efetivo pEfetivo, DataRow rd)
        {
            pEfetivo.codigo_efetivo = Int32.Parse(rd["codigo_Efetivo"].ToString());
            pEfetivo.endereco = new Endereco();
            pEfetivo.endereco = new DbEndereco().CarregarEndereco(Int32.Parse(rd["codigo_Endereco"].ToString()));
            pEfetivo.empresa = new Empresa();
            pEfetivo.empresa = new DbEmpresa().CarregarEmpresa(Int32.Parse(rd["codigo_Empresa"].ToString()));
            pEfetivo.cargo = new Cargo();
            pEfetivo.cargo = new DbCargo().CarregarCargo(Int32.Parse(rd["codigo_Cargo"].ToString()));
            pEfetivo.nome = rd["nome"].ToString();
            pEfetivo.cpf = rd["cpf"].ToString();
            pEfetivo.email = rd["email"].ToString();
            pEfetivo.data_Nascimento = DateTime.Parse(rd["data_Nascimento"].ToString());

            return pEfetivo;
        }

        public Efetivo CarregarEfetivo(int pCodEfetivo)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Efetivo";
            sql.CommandText += $" where codigo_Efetivo = {pCodEfetivo}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Efetivo empresaCarregar = new Efetivo();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                empresaCarregar = this.CarregarDado(empresaCarregar, rd);

                return empresaCarregar;
            }
        }

        public Efetivo Gravar(Efetivo pEfetivo)
        {
            pEfetivo.codigo_efetivo = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Efetivo");
            comando.InsertSqlObj("codigo_Efetivo", $"{pEfetivo.codigo_efetivo}");
            comando.InsertSqlObj("codigo_Endereco", $"{pEfetivo.endereco.codigo_Endereco}");
            comando.InsertSqlObj("codigo_Empresa", $"{pEfetivo.empresa.codigo_Empresa}");
            comando.InsertSqlObj("codigo_Cargo", $"'{pEfetivo.cargo.codigo_Cargo}'");
            comando.InsertSqlObj("nome", $"'{pEfetivo.nome}'");
            comando.InsertSqlObj("cpf", $"'{pEfetivo.cpf}'");
            comando.InsertSqlObj("email", $"'{pEfetivo.email}'");
            comando.InsertSqlObj("data_Nascimento", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEfetivo.data_Nascimento.ToString()))}",true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pEfetivo;
            }
            else
            {
                return null;
            }
        }

        public Efetivo Atualizar(Efetivo pEfetivo)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Efetivo");
            comando.UpdateSqlObj("codigo_Endereco", $"{pEfetivo.endereco.codigo_Endereco}");
            comando.UpdateSqlObj("codigo_Empresa", $"{pEfetivo.empresa.codigo_Empresa}");
            comando.UpdateSqlObj("codigo_Cargo", $"'{pEfetivo.cargo.codigo_Cargo}'");
            comando.UpdateSqlObj("nome", $"'{pEfetivo.nome}'");
            comando.UpdateSqlObj("cpf", $"'{pEfetivo.cpf}'");
            comando.UpdateSqlObj("email", $"'{pEfetivo.email}'");
            comando.UpdateSqlObj("data_Nascimento", $"{new FormatarValores().FormatarDataParaSQL(DateTime.Parse(pEfetivo.data_Nascimento.ToString()))}", true);
            comando.strWhere = $" where codigo_Efetivo = {pEfetivo.codigo_efetivo}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pEfetivo;
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
            sql.CommandText = "select max(codigo_Efetivo) as maiorCodigo from Efetivo";

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

        public List<Efetivo> Listar()
        {
            List<Efetivo> lstEfetivo = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Efetivo";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstEfetivo = new List<Efetivo>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Efetivo efetivoCarregar = new Efetivo();

                    efetivoCarregar = this.CarregarDado(efetivoCarregar, rd);

                    lstEfetivo.Add(efetivoCarregar);
                }

                return lstEfetivo;
            }
        }

        public int Excluir(int pCodEfetivo)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Efetivo");
            sql.Append($" where codigo_Efetivo = {pCodEfetivo}");


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
