using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class Login
    {
        public string email { get; set; }

        public string senha { get; set; }

        public List<string> validarObjeto(Login pLogin)
        {
            List<string> lstRetorno = new List<string>();

            if (string.IsNullOrWhiteSpace(pLogin.email))
            {
                lstRetorno.Add("Informe o e-mail");
            }
            if (string.IsNullOrWhiteSpace(pLogin.senha))
            {
                lstRetorno.Add("Informe a senha");
            }

            return lstRetorno;
        }
    }
}