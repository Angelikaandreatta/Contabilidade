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
    public class DbContato:ComandoSQL
    {
        public Contato Gravar(Contato pContato)
        {
            pContato.cod_Contato = this.ProximoCodigo();

            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("Contato");
            comando.InsertSqlObj("codigo_Contato", $"{pContato.cod_Contato}");
            comando.InsertSqlObj("codigo_Cliente", $"{pContato.cliente.codigo_Cliente}");
            comando.InsertSqlObj("nome", $"'{pContato.nome}'");
            comando.InsertSqlObj("email", $"'{pContato.email}'");
            comando.InsertSqlObj("telefone", $"'{pContato.telefone}'");
            comando.InsertSqlObj("setor", $"'{pContato.setor}'",true);

            if (comando.ExecutarComandoInsertSql() > 0)
            {
                return pContato;
            }
            else
            {
                return null;
            }
        }

        public Contato Atualizar(Contato pContato)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.UpdateTabela("Contato");
            comando.UpdateSqlObj("codigo_Cliente", $"{pContato.cliente.codigo_Cliente}");
            comando.UpdateSqlObj("nome", $"'{pContato.nome}'");
            comando.UpdateSqlObj("email", $"'{pContato.email}'");
            comando.UpdateSqlObj("telefone", $"'{pContato.telefone}'");
            comando.UpdateSqlObj("setor", $"'{pContato.setor}'", true);
            comando.strWhere = $" where codigo_Contato = {pContato.cod_Contato}";

            if (comando.ExecutarComandoUpdateSql() > 0)
            {
                return pContato;
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
            sql.CommandText = "select max(codigo_Contato) as maiorCodigo from Contato";

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

        private Contato CarregarDado(Contato pContato, DataRow rd)
        {
            pContato.cod_Contato = Int32.Parse(rd["codigo_Contato"].ToString());
            pContato.cliente = new Cliente();
            pContato.cliente.codigo_Cliente = Int32.Parse(rd["codigo_Cliente"].ToString());
            pContato.nome = rd["nome"].ToString();
            pContato.email = rd["email"].ToString();
            pContato.telefone = rd["telefone"].ToString();
            pContato.setor = rd["setor"].ToString();

            return pContato;
        }

        public List<Contato> Listar(Contato pContato)
        {
            List<Contato> lstContatos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Contato";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstContatos = new List<Contato>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Contato contatoCarregar = new Contato();

                    contatoCarregar = this.CarregarDado(contatoCarregar, rd);

                    lstContatos.Add(contatoCarregar);
                }

                return lstContatos;
            }
        }

        public Contato CarregarContato(int pCodContato)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Contato";
            sql.CommandText += $" where codigo_Contato = '{pCodContato}'";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Contato contatoCarregar = new Contato();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                contatoCarregar = this.CarregarDado(contatoCarregar, rd);

                return contatoCarregar;
            }

        }

        public int Excluir(int pCodContato)
        {
            int retorno = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Contato");
            sql.Append($" where codigo_Contato = {pCodContato}");


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
