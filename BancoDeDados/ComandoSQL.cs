using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class ComandoSQL
    {
        private string Comando { get; set; }
        private string tabela { get; set; }
        private string campo { get; set; }
        private string value { get; set; }

        private string campoAtualizar { get; set; }
        public string strWhere { get; set; }

        SqlCommand cmd = new SqlCommand();

        public ComandoSQL()
        {
            cmd.Connection = new ConexaoDB().Conectar();
        }

        public void InsertTabela(string tabelaNome)
        {
            tabela = $"insert into {tabelaNome}";
        }

        public void UpdateTabela(string tabelaNome)
        {
            tabela = $"update {tabelaNome}";
        }

        public void InsertSqlObj(string tabelaCampo, string objetoValor, bool ultuimoCmapo = false)
        {
            if (ultuimoCmapo == false)
            {
                if (objetoValor != null)
                {
                    campo += $"{tabelaCampo}, ";
                    value += $"{objetoValor}, ";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campo += $"{tabelaCampo}, ";
                    value += $"null, ";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }
            }
            else if (ultuimoCmapo == true)
            {
                if (objetoValor != null)
                {
                    campo += $"{tabelaCampo}";
                    value += $"{objetoValor}";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campo += $"{tabelaCampo}";
                    value += $"null";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }

            }

        }

        public void UpdateSqlObj(string tabelaCampo, string objetoValor, bool ultuimoCmapo = false)
        {
            if (ultuimoCmapo == false)
            {
                if (objetoValor != null)
                {
                    campoAtualizar += $"{tabelaCampo} = {objetoValor},";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campoAtualizar += $"{tabelaCampo} = null;";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }
            }
            else if (ultuimoCmapo == true)
            {
                if (objetoValor != null)
                {
                    campoAtualizar += $"{tabelaCampo} = {objetoValor}";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"{objetoValor}");
                }
                else
                {
                    campoAtualizar += $"{tabelaCampo} = {objetoValor}";
                    cmd.Parameters.AddWithValue($"{tabelaCampo}", $"null");
                }

            }

        }

        public int ExecutarComandoInsertSql()
        {
            ConexaoDB db = new ConexaoDB();
            //cmd.Connection = db.Conectar();

            Comando = $"{tabela}({campo}) values ({value});";
            cmd.CommandText = Comando;
            SqlDataReader dataRow = cmd.ExecuteReader();
            //db.Desconectar();
            this.SqlClear();
            return dataRow.RecordsAffected;
        }

        public int ExecutarComandoUpdateSql()
        {
            ConexaoDB db = new ConexaoDB();
            //cmd.Connection = db.Conectar();

            Comando = $"{tabela} set {campoAtualizar} {strWhere} ";
            cmd.CommandText = Comando;
            SqlDataReader dataRow = cmd.ExecuteReader();
            //db.Desconectar();
            this.SqlClear();
            return dataRow.RecordsAffected;
        }

        public int ExecutarReader(string strComando)
        {
            ConexaoDB db = new ConexaoDB();
            
            cmd.CommandText = strComando;
            SqlDataReader dataRow = cmd.ExecuteReader();

            this.SqlClear();
            return dataRow.RecordsAffected;
        }

        public void SqlClear()
        {
            Comando = "";
            tabela = "";
            campo = "";
            value = "";
            strWhere = "";
        }
    }
}

