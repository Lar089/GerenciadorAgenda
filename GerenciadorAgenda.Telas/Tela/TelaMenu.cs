using GerenciadorAgenda.Telas.Mensagens;
using GerenciadorAgenda.Telas.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela
{
    abstract class TelaMenu
    {
        private List<OpcaoMenu> opcoes = new List<OpcaoMenu>();
        private int opcaoAtual = 1;

        public string descricao;

        protected enum TipoMensagem
        {
            SUCESSO, ERRO
        }

        protected TelaMenu(string descricao)
        {
            this.descricao = descricao;
        }

        public virtual TelaMenu Executar()
        {
            Console.Clear();

            ImprimirMensagem(descricao, TipoMensagem.SUCESSO);
            Console.WriteLine();

            ListarOpcoes();

            Console.WriteLine();
            int opcao = LerOpcao();

            return EncontrarMenu(opcao);
        }

        protected void AdicionarOpcao(TelaMenu menu)
        {
            opcoes.Add(new OpcaoMenu(opcaoAtual, menu));
            opcaoAtual++;
        }

        protected void ImprimirMensagem(string msg, TipoMensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case TipoMensagem.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TipoMensagem.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(msg);
            Console.ResetColor();
        }

        protected void ImprimirMensagem(Mensagem mensagem)
        {
            TipoMensagem tipoMensagem = mensagem.Sucesso() ? TipoMensagem.SUCESSO : TipoMensagem.ERRO;
            ImprimirMensagem(mensagem.PegarMensagem(), tipoMensagem);
        }

        protected void Pausar()
        {
            Console.Write("\nDigite qualquer coisa para continuar: ");
            Console.ReadLine();
        }

        private void ListarOpcoes()
        {
            foreach (OpcaoMenu opcao in opcoes)
            {
                Console.WriteLine($"{opcao.N}. {opcao.Menu.descricao}");
            }
            Console.WriteLine($"{opcaoAtual}. Voltar");
        }

        private int LerOpcao()
        {
            Console.Write("Digita o que deseja fazer: ");
            while (true)
            {
                int opcao = LerInt();
                if (!OpcaoEhValida(opcao))
                {
                    ImprimirMensagem("Voce digitou uma opcao invalida!", TipoMensagem.ERRO);
                    continue;
                }

                return opcao;
            }
        }

        private TelaMenu EncontrarMenu(int op)
        {
            //opcao voltar
            if (op == opcaoAtual)
                return new OpcaoVoltar();

            foreach (OpcaoMenu opcao in opcoes)
            {
                if (opcao.N == op)
                    return opcao.Menu;
            }
            return null;
        }

        private bool OpcaoEhValida(int op)
        {
            //Opcao voltar
            if (op == opcaoAtual)
                return true;

            foreach (OpcaoMenu opcao in opcoes)
            {
                if (opcao.N == op)
                    return true;
            }

            return false;
        }

        protected int LerInt()
        {
            while (true)
            {
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    return n;
                }
                catch (Exception)
                {
                    ImprimirMensagem("Digite um numero!", TipoMensagem.ERRO);
                }
            }
        }

        protected DateTime LerData()
        {
            while (true)
            {
                try
                {
                    string dataStr = Console.ReadLine();
                    DateTime data = DateTime.Parse(dataStr);

                    return data;
                }
                catch (Exception)
                {
                    ImprimirMensagem("Digite uma data no formato dd/mm/aaaa", TipoMensagem.ERRO);
                    continue;
                }
            }
        }
    }
}
