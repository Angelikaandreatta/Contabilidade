using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Login
    {
        public int codigo_Login { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public string senha { get; set; }


        public List<string> validarObjeto(Login pLogin)
        {
            List<string> lstRetorno = new List<string>();


            if (string.IsNullOrWhiteSpace(pLogin.nome))
            {
                lstRetorno.Add("Informe o seu nome");
            }
            if (string.IsNullOrWhiteSpace(pLogin.email))
            {
                lstRetorno.Add("Informe o e-mail");
            }
            if (string.IsNullOrWhiteSpace(pLogin.cargo))
            {
                lstRetorno.Add("Informe seu cargo");
            }
            if (string.IsNullOrWhiteSpace(pLogin.senha))
            {
                lstRetorno.Add("Informe a senha");
            }

            return lstRetorno;
        }
    }
}