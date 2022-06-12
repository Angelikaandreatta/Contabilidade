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
    public class DbEndereco
    {
        public Endereco Gravar(Endereco pEndereco)
        {
            pEndereco.codigo_Endereco = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Endereco");
            comando.InsertSqlObj("codigo_Endereco", $"{pEndereco.codigo_Endereco}");
            comando.InsertSqlObj("rua", $"'{pEndereco.rua}'");
            comando.InsertSqlObj("numero", $"'{pEndereco.numero}'");
            comando.InsertSqlObj("bairro", $"'{pEndereco.bairro}'");
            comando.InsertSqlObj("cidade", $"'{pEndereco.cidade}'");
            comando.InsertSqlObj("uf", $"'{pEndereco.uf}'", true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pEndereco;
            }
            else
            {
                return null;
            }
        }

        public Endereco Atualizar(Endereco pEndereco)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Endereco");
            comando.UpdateSqlObj("rua", $"'{pEndereco.rua}'");
            comando.UpdateSqlObj("numero", $"'{pEndereco.numero}'");
            comando.UpdateSqlObj("bairro", $"'{pEndereco.bairro}'");
            comando.UpdateSqlObj("cidade", $"'{pEndereco.cidade}'");
            comando.UpdateSqlObj("uf", $"'{pEndereco.uf}'", true);
            comando.strWhere = $" where codigo_Endereco = {pEndereco.codigo_Endereco}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pEndereco;
            }
            else
            {
                return null;
            }
        }

        public List<Endereco> Listar(Endereco pEndereco)
        {
            List<Endereco> lstEnderecos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Endereco";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstEnderecos = new List<Endereco>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Endereco enderecoCarregar = new Endereco();

                    enderecoCarregar = this.CarregarDado(enderecoCarregar, rd);

                    lstEnderecos.Add(enderecoCarregar);
                }

                return lstEnderecos;
            }
        }

        private Endereco CarregarDado(Endereco pEndereco, DataRow rd)
        {
            pEndereco.codigo_Endereco = Int32.Parse(rd["codigo_Endereco"].ToString());
            pEndereco.rua = rd["rua"].ToString();
            pEndereco.numero = rd["numero"].ToString();
            pEndereco.bairro = rd["bairro"].ToString();
            pEndereco.cidade = rd["cidade"].ToString();
            pEndereco.uf = rd["uf"].ToString();

            return pEndereco;
        }

        public Endereco CarregarEndereco(int pCodEndereco)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Endereco";
            sql.CommandText += $" where codigo_Endereco = {pCodEndereco}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Endereco enderecoCarregar = new Endereco();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                enderecoCarregar = this.CarregarDado(enderecoCarregar, rd);

                return enderecoCarregar;
            }
        }

        public int ProximoCodigo()
        {
            int codigoRetorno = 0;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select max(codigo_Endereco) as maiorCodigo from Endereco";

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
