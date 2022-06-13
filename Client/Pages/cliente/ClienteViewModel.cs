using Negocio.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Contabilidade.Client.Pages.cliente
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            this.Empresa = new Empresa();
            this.Endereco = new Endereco();
        }

        private string codigo_cliente = "";
        public string Codigo_Cliente { get => codigo_cliente; set => codigo_cliente = value; }

        public Empresa Empresa { get; set; } = null;

        public Endereco Endereco { get; set; } = null;

        private string razao_Social = "";
        public string Razao_Social { get => razao_Social; set => razao_Social = value; }

        private string cnpj = "";
        public string Cnpj { get => cnpj; set => cnpj = value; }

        private string qtd_Empregado = "";
        public string Qtd_Empregado { get => qtd_Empregado; set => qtd_Empregado = value; }
    }

    public class vmEmpresa
    {
        public int codigo_Empresa { get; set; }

        public string nome { get; set; }
    }
}

