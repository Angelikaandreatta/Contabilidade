using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.Contato
{
    public class ContatoViewModel
    {
        private string cod_Contato ="";
        public string Cod_Contato { get => cod_Contato; set=> cod_Contato = value; }

        private string nome_Contato = "";
        public string Nome_Contato { get=> nome_Contato; set=> nome_Contato = value; }

        private string cpf = "";
        public string CPF { get=> cpf; set => cpf = value; }

        private string celular = "";
        public string Celular { get => celular; set=> celular = value; }

        private string email = "";
        public string Email { get => email; set => email = value; }
    }
}
