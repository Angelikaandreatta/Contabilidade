using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.cliente
{
    public class ClienteViewModel
    {
        private string cod_cliente = "";
        public string Cod_Cliente { get => cod_cliente; set => cod_cliente = value; }

        private string nome_cliente = "";
        public string Nome_Cliente { get => nome_cliente; set => nome_cliente = value; }

        private string cnpj = "";
        public string Cnpj { get => cnpj; set => cnpj = value; }

        private string ie = "";
        public string Ie { get => ie; set => ie = value; }

        private string email = "";
        public string Email { get => email; set => email = value; }

        private string rua = "";
        public string Rua { get => rua; set => rua = value; }

        private string numero = "";
        public string Numero { get => numero; set => numero = value; }

        private string bairro = "";
        public string Bairro { get => bairro; set => bairro = value; }

        private string cep = "";
        public string Cep { get => cep; set => cep = value; }

        private string uf = "";
        public string Uf { get => uf; set => uf = value; }

        private DateTime? data_Cadastro = null;
        public DateTime? Data_Cadastro { get => data_Cadastro; set => data_Cadastro = value; }

        public VmCidade vmCidade { get; set; } = null;
    }

    public class VmCidade
    {
        private string cod_Cidade = "";
        public string Cod_Cidade { get => cod_Cidade; set => cod_Cidade = value; }

        private string nome_Cidade = "";
        public string Nome_Cidade { get => nome_Cidade; set => nome_Cidade = value; }
    }
}

