using BancoDeDados.Cadastro;
using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Cadastro
{
    public class ControleEndereco
    {
        public async Task<Endereco> Gravar(Endereco pEndereco)
        {
            try
            {
                Endereco enderecoGravado = new Endereco();
                DbEndereco dbEndereco = new DbEndereco();

                enderecoGravado = dbEndereco.Gravar(pEndereco);

                if (enderecoGravado != null)
                {
                    enderecoGravado = new DbEndereco().CarregarEndereco(enderecoGravado.codigo_Endereco);
                    return enderecoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao gravar endereço no banco.");
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

        public async Task<Endereco> Atualizar(Endereco pEndereco)
        {

            try
            {
                Endereco enderecoGravado = new Endereco();
                DbEndereco dbEndereco = new DbEndereco();

                enderecoGravado = dbEndereco.Atualizar(pEndereco);

                if (enderecoGravado != null)
                {
                    enderecoGravado = new DbEndereco().CarregarEndereco(enderecoGravado.codigo_Endereco);
                    return enderecoGravado;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao atualizar o endereço no banco.");
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

        public async Task<List<Endereco>> Listar(Endereco pEndereco)
        {
            List<Endereco> lstEnderecoRetorno = null;

            try
            {
                DbEndereco dbEndereco = new DbEndereco();
                lstEnderecoRetorno = dbEndereco.Listar(pEndereco);

                if (lstEnderecoRetorno != null && lstEnderecoRetorno.Count > 0)
                {
                    return lstEnderecoRetorno;
                }
                else
                {
                    return lstEnderecoRetorno;
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

        public async Task<Endereco> Carregar(int pCodEndereco)
        {
            Endereco enderecoRetorno = null;

            if (pCodEndereco <= 0)
            {
                throw new InvalidOperationException("Informe o código do endereço para carrega-lo.");
            }

            try
            {
                DbEndereco dbEndereco = new DbEndereco();
                enderecoRetorno = dbEndereco.CarregarEndereco(pCodEndereco);

                if (enderecoRetorno != null)
                {
                    return enderecoRetorno;
                }
                else
                {
                    throw new InvalidOperationException("Erro ao carregar cliente.");
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
