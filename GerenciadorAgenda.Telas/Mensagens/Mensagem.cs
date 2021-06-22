using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Mensagens
{
    abstract class Mensagem
    {
        protected bool sucesso;

        protected string mensagemSucesso;
        protected string mensagemErro;

        public bool Sucesso()
        {
            return sucesso;
        }

        public string PegarMensagem()
        {
            if (sucesso)
                return mensagemSucesso;
            else
                return mensagemErro;
        }
    }
}
