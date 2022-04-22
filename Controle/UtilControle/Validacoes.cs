using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.UtilControle
{
    public class Validacoes
    {
        public List<string> strMensagemLista = new List<string>();
        public string strMensagem = "";

        public InvalidOperationException RetornarMensagem()
        {
            try
            {
                foreach (string mensagem in strMensagemLista)
                {
                    this.strMensagem += "," + mensagem;
                }

                if (string.IsNullOrWhiteSpace(strMensagem) == false)
                {
                    throw new InvalidOperationException(this.strMensagem);
                }
                else
                {
                    return null;
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
