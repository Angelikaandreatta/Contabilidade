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
    public class DbCliente:ComandoSQL
    {
        public Cliente Gravar(Cliente pCliente)
        {
            pCliente.codigo_Cliente = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Cliente");
            comando.InsertSqlObj("codigo_Cliente", $"{pCliente.codigo_Cliente}");
            comando.InsertSqlObj("codigo_Empresa", "1");
            comando.InsertSqlObj("codigo_Endereco", "1");
            comando.InsertSqlObj("razao_Social", $"'{pCliente.razao_Social}'");
            comando.InsertSqlObj("cnpj", $"'{pCliente.cnpj}'");
            comando.InsertSqlObj("qtd_Empregado", $"'{pCliente.qtd_Empregado}'", true);

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
            comando.UpdateTabela("Cliente");
            comando.UpdateSqlObj("codigo_Empresa", $"{pCliente.empresa.codigo_Empresa}");
            comando.UpdateSqlObj("codigo_Endereco", $"{pCliente.endereco.codigo_Endereco}");
            comando.UpdateSqlObj("razao_Social", $"'{pCliente.razao_Social}'");
            comando.UpdateSqlObj("cnpj", $"'{pCliente.cnpj}'");
            comando.UpdateSqlObj("qtd_Empregado", $"{pCliente.qtd_Empregado}", true);
            comando.strWhere = $" where codigo_Cliente = {pCliente.codigo_Cliente}";

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
            sql.CommandText = "select max(codigo_Cliente) as maiorCodigo from Cliente";

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
            pCliente.codigo_Cliente = Int32.Parse(rd["codigo_Cliente"].ToString());
            pCliente.empresa = new Empresa();
            pCliente.empresa.codigo_Empresa = Int32.Parse(rd["codigo_Empresa"].ToString());
            pCliente.endereco = new Endereco();
            pCliente.endereco.codigo_Endereco = Int32.Parse(rd["codigo_Endereco"].ToString());
            pCliente.razao_Social = rd["razao_Social"].ToString();
            pCliente.cnpj = rd["cnpj"].ToString();
            pCliente.qtd_Empregado = rd["qtd_Empregado"].ToString();

            return pCliente;
        }

        public List<Cliente> Listar(Cliente pCliente)
        {
            List<Cliente> lstClientes = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Cliente";

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

        public Cliente CarregarCliente(string pCliente)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Cliente";
            sql.CommandText += $" where codigo_Cliente = '{pCliente}'";

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

        public int Excluir(int pCodCliente)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Cliente");
            sql.Append($" where codigo_Cliente = '{pCodCliente}'");


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
