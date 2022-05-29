using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.Contato
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            this.Cliente = new vmCliente();
        }

        public vmCliente Cliente;

        private string cod_Contato = "";
        public string Cod_Contato { get => cod_Contato; set => cod_Contato = value; }

        private string nome_Contato = "";
        public string Nome_Contato { get => nome_Contato; set => nome_Contato = value; }

        private string email = "";
        public string Email { get => email; set => email = value; }

        private string telefone = "";
        public string Telefone { get => telefone; set => telefone = value; }

        private string setor = "";
        public string Setor { get => setor; set => setor = value; }
    }

    public class vmCliente
    {
        public int Codigo_Cliente = 0;
    }

}
