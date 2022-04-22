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
    public class DbContato
    {
        public Contato Gravar(Contato pContato)
        {
            ComandoSQL comando = new ComandoSQL();
            comando.InsertTabela("tb_Contato");
            comando.InsertSqlObj("cod_Contato", $"{this.ProximoCodigo()}");
            comando.InsertSqlObj("nome_Contato", $"'{pContato.nome_Contato}'");
            comando.InsertSqlObj("CPF", $"'{pContato.CPF}'");
            comando.InsertSqlObj("celular", $"'{pContato.celular}'");
            comando.InsertSqlObj("email", $"'{pContato.email}'");

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
            comando.UpdateTabela("tb_Contato");
            comando.UpdateSqlObj("nome_Contato", $"'{pContato.nome_Contato}'");
            comando.UpdateSqlObj("CPF", $"'{pContato.CPF}'");
            comando.UpdateSqlObj("celular", $"'{pContato.celular}'");
            comando.UpdateSqlObj("email", $"'{pContato.email}'");

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
            sql.CommandText = "select max(cod_Contato) as maiorCodigo from tb_Contato";

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
            pContato.cod_Contato = Int32.Parse(rd["cod_Contato"].ToString());
            pContato.nome_Contato = rd["nome_Contato"].ToString();
            pContato.CPF = rd["CPF"].ToString();
            pContato.celular = rd["celular"].ToString();
            pContato.email = rd["email"].ToString();

            return pContato;
        }

        public List<Contato> Listar(Contato pContato)
        {
            List<Contato> lstContatos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Contato";

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

        public Contato CarregarContato(Contato pContato)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from tb_Contato";
            sql.CommandText += $" where cod_Contato = '{pContato.cod_Contato}'";

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
    }
}
