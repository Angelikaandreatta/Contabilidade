using BancoDeDados.Cadastro;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Cadastro
{
    public class ControleCargo
    {
        public async Task<List<Cargo>> Listar()
        {
            List<Cargo> lstCargoRetorno = null;

            try
            {
                DbCargo dbCargo = new DbCargo();
                lstCargoRetorno = dbCargo.ListarCargo();

                if (lstCargoRetorno != null && lstCargoRetorno.Count > 0)
                {
                    return lstCargoRetorno;
                }
                else
                {
                    return lstCargoRetorno;
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cargo> Carregar(int pCodCargo)
        {
            Cargo cargoRetrono = null;

            if (pCodCargo <= 0)
            {
                throw new InvalidOperationException("Informe o código do cargo para carrega-lo.");
            }

            try
            {
                DbCargo dbCargo = new DbCargo();
                cargoRetrono = dbCargo.CarregarCargo(pCodCargo);

                if (cargoRetrono != null)
                {
                    return cargoRetrono;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar cargo.");
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
