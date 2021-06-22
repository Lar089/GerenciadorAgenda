using GerenciadorAgenda.Telas.Menu;
using GerenciadorAgenda.Telas.Tela;
using System;
using GerenciadorAgenda.Controlarodes.Controladores;

namespace GerenciadorAgenda.Telas
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();
            ControladorContatos controladorContatos = new ControladorContatos();
            TelaPrincipal principal = new TelaPrincipal(controladorTarefa, controladorContatos);

            ExecutarMenu(principal);
        }

        private static void ExecutarMenu(TelaMenu menu)
        {
            while (true)
            {
                TelaMenu proximoMenu = menu.Executar();

                if (proximoMenu is OpcaoVoltar || proximoMenu == null)
                    break;

                ExecutarMenu(proximoMenu);
            }
        }
    }
}
