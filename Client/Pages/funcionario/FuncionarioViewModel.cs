using System;
using Negocio.Cadastro;

namespace Projeto_Contabilidade.Client.Pages.funcionario
{
    public class FuncionarioViewModel
    {

        #region Pessoal
        private string nome { get; set; }
        public string Nome { get => nome; set => nome = value; }
        private string cpf { get; set; }
        public string Cpf { get => cpf; set => cpf = value; }
        private string email { get; set; }
        public string Email { get => email; set => email = value; }
        private string data_nascimento { get; set; }
        public string Data_Nascimento { get => data_nascimento; set => data_nascimento = value; }
        #endregion

        #region Empresa
        public Empresa Empresa { get; set; } = null;
        
        #endregion

        #region Endereço
        public Endereco Endereco { get; set; } = null;
        #endregion

        public FuncionarioViewModel()
        {
            this.Empresa = new Empresa();
            this.Endereco = new Endereco();
        }
    }
}
