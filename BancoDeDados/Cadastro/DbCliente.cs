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
            pCliente.codigo_Cliente = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Cliente");
            comando.InsertSqlObj("codigo_Cliente", $"{pCliente.codigo_Cliente}");
            //Empresa empresa = new Empresa();
            //comando.InsertSqlObj("codigo_Empresa", $"'{empresa.codigo_Empresa}'");// Revisar
            comando.InsertSqlObj("codigo_Empresa","1");// Revisar
            //Endereco endereco = new Endereco();
            //comando.InsertSqlObj("codigo_Endereco", $"'{endereco.codigo_Endereco}'");// Revisar
             comando.InsertSqlObj("codigo_Endereco", "1");// Revisar
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
            comando.UpdateSqlObj("codigo_Cliente", $"{pCliente.codigo_Cliente}");
            //empresa n atualiza
            Endereco endereco = new Endereco();
            comando.UpdateSqlObj("codigo_Endereco", $"'{endereco.codigo_Endereco}'");// Revisar
            comando.UpdateSqlObj("razao_Social", $"'{pCliente.razao_Social}'");
            comando.UpdateSqlObj("cnpj", $"'{pCliente.cnpj}'");
            comando.UpdateSqlObj("qtd_Empregado", $"'{pCliente.qtd_Empregado}'", true);
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
            //empresa
            //endereço
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

        public Cliente CarregarCliente(Cliente pCliente)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Cliente";
            sql.CommandText += $" where codigo_Cliente = '{pCliente.codigo_Cliente}'";

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
