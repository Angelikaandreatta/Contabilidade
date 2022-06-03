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
        private Endereco CarregarDado(Endereco pEndereco, DataRow rd)
        {
            pEndereco.codigo_Endereco = Int32.Parse(rd["codigo_Endereco"].ToString());
            pEndereco.rua = rd["rua"].ToString();
            pEndereco.numero = rd["numero"].ToString();
            pEndereco.bairro = rd["cidade"].ToString();
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
    }
}
