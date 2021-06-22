using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Mensagens
{
    class GeradorDeMensagem
    {
        public class MensagemValidacaoClasse : Mensagem
        {
            public MensagemValidacaoClasse(string mensagem)
            {
                sucesso = false;

                this.mensagemErro = mensagem;
            }
        }

        public class MensagemInserir : Mensagem
        {
            public MensagemInserir(bool sucesso, string nome)
            {
                this.sucesso = sucesso;

                this.mensagemSucesso = $"{nome} inserido com sucesso";
                this.mensagemErro = "Não tem mais espaço para adicionar";
            }
        }

        public class MensagemEditar : Mensagem
        {
            public MensagemEditar(bool sucesso, string nome)
            {
                this.sucesso = sucesso;

                this.mensagemSucesso = $"{nome} editado com sucesso";
                this.mensagemErro = $"Posicao de {nome} não encontrado";
            }
        }

        public class MensagemExcluir : Mensagem
        {
            public MensagemExcluir(bool sucesso, string nome)
            {
                this.sucesso = sucesso;

                this.mensagemSucesso = $"{nome} excluido com sucesso";
                this.mensagemErro = $"Posicao de {nome} não encontrado";
            }
        }

        public class MensagemPersonalizada : Mensagem
        {
            public MensagemPersonalizada(bool sucesso, string mensagem)
            {
                this.sucesso = sucesso;

                if (sucesso)
                {
                    this.mensagemSucesso = mensagem;
                }
                else
                {
                    this.mensagemErro = mensagem;
                }
            }
        }
    }
}
