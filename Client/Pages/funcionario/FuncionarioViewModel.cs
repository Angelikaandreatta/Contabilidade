using System;

namespace Projeto_Contabilidade.Client.Pages.funcionario
{
    public class FuncionarioViewModel
    {

        #region Pessoal
        public string CodFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        #endregion

        #region Endereço
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string NomeCidade { get; set; }
        #endregion
    }
}
