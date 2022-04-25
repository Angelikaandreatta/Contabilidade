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
    public class DbCliente
    {
        public Cliente Gravar(Cliente pCliente)
        {
            pCliente.cod_Cliente = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("tb_Cliente");
            comando.InsertSqlObj("cod_Cliente", $"{pCliente.cod_Cliente}");
            comando.InsertSqlObj("nome_Cliente", $"'{pCliente.nome_Cliente}'");
            comando.InsertSqlObj("cnpj", $"'{pCliente.cnpj}'");
            comando.InsertSqlObj("ie", $"'{pCliente.ie}'");
            comando.InsertSqlObj("email", $"'{pCliente.email}'");
            comando.InsertSqlObj("rua", $"'{pCliente.rua}'");
            comando.InsertSqlObj("numero", $"'{pCliente.numero}'");
            comando.InsertSqlObj("bairro", $"'{pCliente.bairro}'");
            comando.InsertSqlObj("cep", $"'{pCliente.cep}'");
            comando.InsertSqlObj("uf", $"'{pCliente.uf}'");
            comando.InsertSqlObj("data_Cadastro", $"{ new FormatarValores().FormatarDataParaSQL(DateTime.Now.Date)}");
            comando.InsertSqlObj("cod_Cidade", $"{1}");
            comando.InsertSqlObj("nome_Cidade", $"'{pCliente.nome_Cidade}'");
            comando.InsertSqlObj("cod_Contato", $"{1}", true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pCliente;
            }
            else
            {
                return null;
            }
        }

        public Cliente Atualizar(Cliente pCliente)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("tb_Cliente");
            comando.UpdateSqlObj("nome_Cliente", $"'{pCliente.nome_Cliente}'");
            comando.UpdateSqlObj("cnpj", $"'{pCliente.cnpj}'");
            comando.UpdateSqlObj("ie", $"'{pCliente.ie}'");
            comando.UpdateSqlObj("email", $"'{pCliente.email}'");
            comando.UpdateSqlObj("rua", $"'{pCliente.rua}'");
            comando.UpdateSqlObj("numero", $"'{pCliente.numero}'");
            comando.UpdateSqlObj("bairro", $"'{pCliente.bairro}'");
            comando.UpdateSqlObj("cep", $"'{pCliente.cep}'");
            comando.UpdateSqlObj("uf", $"'{pCliente.uf}'");
            comando.UpdateSqlObj("data_Cadastro", $"{ new FormatarValores().FormatarDataParaSQL(DateTime.Now.Date)}");
            comando.UpdateSqlObj("cod_Cidade", $"{1}");
            comando.UpdateSqlObj("nome_Cidade", $"'{pCliente.nome_Cidade}'");
            comando.UpdateSqlObj("cod_Contato", $"{1}", true);
            comando.strWhere = $" where cod_Cliente = {pCliente.cod_Cliente}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pCliente;
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
            sql.CommandText = "select max(cod_Cliente) as maiorCodigo from tb_Cliente";

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

        private Cliente CarregarDado(Cliente pCliente, DataRow rd)
        {
            pCliente.cod_Cliente = Int32.Parse(rd["cod_Cliente"].ToString());
            pCliente.nome_Cliente = rd["nome_Cliente"].ToString();
            pCliente.cnpj = rd["cnpj"].ToString();
            pCliente.ie = rd["ie"].ToString();
            pCliente.email = rd["email"].ToString();
            pCliente.rua = rd["rua"].ToString();
            pCliente.numero = rd["numero"].ToString();
            pCliente.bairro = rd["bairro"].ToString();
            pCliente.uf = rd["uf"].ToString();
            //pCliente.data_Cadastro = DateTime.Parse(rd["data_Cadastro"].ToString());
            pCliente.cod_Cidade = Int32.Parse(rd["cod_Cidade"].ToString());
            pCliente.nome_Cidade = rd["nome_Cidade"].ToString();
            pCliente.cod_Contato = Int32.Parse(rd["cod_Contato"].ToString());

            return pCliente;
        }

        public List<Cliente> Listar(Cliente pCliente)
        {
            List<Cliente> lstClientes = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Cliente";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstClientes = new List<Cliente>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Cliente clienteCarregar = new Cliente();

                    clienteCarregar = this.CarregarDado(clienteCarregar, rd);

                    lstClientes.Add(clienteCarregar);
                }

                return lstClientes;
            }
        }

        public Cliente CarregarCliente(Cliente pCliente)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Cliente";
            sql.CommandText += $" where cod_Cliente = '{pCliente.cod_Cliente}'";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Cliente clienteCarregar = new Cliente();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                clienteCarregar = this.CarregarDado(clienteCarregar, rd);

                return clienteCarregar;
            }

        }
    }
}
