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
    public class DbCargo
    {
        private Cargo CarregarDado(Cargo pCargo, DataRow rd)
        {
            pCargo.codigo_Cargo = Int32.Parse(rd["codigo_Cargo"].ToString());
            pCargo.setor = rd["setor"].ToString();
            pCargo.nome = rd["nome"].ToString();

            return pCargo;
        }

        public Cargo CarregarCargo(int pCodCargo)
        {
            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Cargo";
            sql.CommandText += $" where codigo_Cargo = {pCodCargo}";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                Cargo cargoCarregar = new Cargo();

                DataTable dataTable = new DataTable();
                dataTable.Load(dt);
                DataRow rd = dataTable.Rows[0];

                cargoCarregar = this.CarregarDado(cargoCarregar, rd);

                return cargoCarregar;
            }
        }

        public List<Cargo> ListasrCargo()
        {

            List<Cargo> lstCargos = null;

            SqlCommand sql = new SqlCommand("", new ConexaoDB().Conectar());
            sql.CommandText = "select * from Cargo";

            using (SqlDataReader dt = sql.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dt);

                lstCargos = new List<Cargo>();

                foreach (DataRow rd in dataTable.Rows)
                {

                    Cargo cargoCarregar = new Cargo();

                    cargoCarregar = this.CarregarDado(cargoCarregar, rd);

                    lstCargos.Add(cargoCarregar);
                }

                return lstCargos;
            }
        }

    }
}
