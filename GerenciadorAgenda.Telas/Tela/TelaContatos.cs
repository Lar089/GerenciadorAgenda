using GerenciadorAgenda.Telas.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAgenda.Dominios.Dominio;
using GerenciadorAgenda.Controlarodes.Controladores;

namespace GerenciadorAgenda.Telas.Tela
{
    class TelaContatos : TelaMenu
    {
        private readonly Controlador<Contatos> controladorContatos;

        public TelaContatos(Controlador<Contatos> controladorContatos) : base("Contatos")
        {
            this.controladorContatos = controladorContatos;

            AdicionarOpcao(new MenuContatosInserir(this));
            AdicionarOpcao(new MenuContatosEditar(this));
            AdicionarOpcao(new MenuContatosExcluir(this));
            AdicionarOpcao(new MenuContatosVisualizar(this));
        }

        private bool VerificarDependenciasContatos()
        {
            if (controladorContatos.SelecionarTodosRegistros().Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                ImprimirMensagem("Nenhum Contatos cadastrado, por favor cadastre alguma", TipoMensagem.ERRO);
                Pausar();
                return false;
            }
            return true;
        }

        public void VisualizarContatoss()
        {
            string template = "{0, -3} | {1, -20} | {2, -25} | {3, -10} | {4, -15} | {5, -15}";

            Console.WriteLine(template, "Id", "Nome", "Email", "Telefone", "Empresa", "Cargo da Pessoa");
            Console.WriteLine();

            List<Contatos> Contatoss = controladorContatos.SelecionarTodosRegistros();

            if (Contatoss.Count == 0)
            {
                Console.WriteLine("Nenhum Contatos cadastrada");
            }

            foreach (Contatos Contatos in Contatoss)
            {
                Console.WriteLine(template, Contatos.Id, Contatos.Nome,
                    Contatos.Email, Contatos.Telefone, Contatos.Empresa,
                    Contatos.Cargo);
            }
        }

        #region Opções CRUD
        private class MenuContatosInserir : TelaMenu
        {
            private TelaContatos menuContatos;

            public MenuContatosInserir(TelaContatos menuContatos) : base("Inserir")
            {
                this.menuContatos = menuContatos;
            }

            public override TelaMenu Executar()
            {
                Console.Clear();

                Console.Write("Digite o nome do Contato: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do Contato: ");
                string email = Console.ReadLine();

                Console.Write("Digite o telefone do Contato: ");
                string telefone = Console.ReadLine();

                Console.Write("Digite a empresa do Contato: ");
                string empresa = Console.ReadLine();

                Console.Write("Digite o cargo da pessoa do Contato: ");
                string cargoPessoa = Console.ReadLine();

                Contatos contato = new Contatos(nome, email, telefone, empresa, cargoPessoa);

                Console.WriteLine();
                bool conseguiuInserir = menuContatos.controladorContatos.InserirRegistro(contato);

                if (conseguiuInserir)
                    ImprimirMensagem("Novo Contato criada com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao criar um novo Contato", TipoMensagem.ERRO);

                Pausar();
                return null;
            }
        }

        private class MenuContatosEditar : TelaMenu
        {
            private TelaContatos menuContatos;

            public MenuContatosEditar(TelaContatos menuContatos) : base("Editar")
            {
                this.menuContatos = menuContatos;
            }

            public override TelaMenu Executar()
            {
                if (!menuContatos.VerificarDependenciasContatos())
                    return null;

                Console.Clear();

                menuContatos.VisualizarContatoss();
                Console.Write("\nDigite o id do Contatos que você deseja editar: ");
                int id = LerInt();

                Console.Write("Digite o nome do Contato: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do Contato: ");
                string email = Console.ReadLine();

                Console.Write("Digite o telefone do Contato: ");
                string telefone = Console.ReadLine();

                Console.Write("Digite a empresa do Contato: ");
                string empresa = Console.ReadLine();

                Console.Write("Digite o cargo da pessoa do Contato: ");
                string cargoPessoa = Console.ReadLine();
                Contatos contato = new Contatos(nome, email, telefone, empresa, cargoPessoa);
                contato.Id = id;
                bool conseguiuEditar = menuContatos.controladorContatos.EditarRegistro(contato);

                if (conseguiuEditar)
                    ImprimirMensagem("Tarefa alterada com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao alterar a tarefa", TipoMensagem.ERRO);

                Pausar();

                return null;
            }
        }

        private class MenuContatosExcluir : TelaMenu
        {
            private TelaContatos menuContatos;

            public MenuContatosExcluir(TelaContatos menuContatos) : base("Excluir")
            {
                this.menuContatos = menuContatos;
            }

            public override TelaMenu Executar()
            {
                if (!menuContatos.VerificarDependenciasContatos())
                    return null;

                Console.Clear();
                menuContatos.VisualizarContatoss();
                Console.Write("\nDigite o id do Contatos que deseja excluir: ");
                int id = LerInt();

                bool conseguiuExcluir = menuContatos.controladorContatos.ExcluirRegistro(id);

                if (conseguiuExcluir)
                    ImprimirMensagem("Tarefa excluida com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao excluir a tarefa", TipoMensagem.ERRO);

                Pausar();

                return null;
            }
        }

        private class MenuContatosVisualizar : TelaMenu
        {
            private TelaContatos menuContatos;

            public MenuContatosVisualizar(TelaContatos menuContatos) : base("Visualizar")
            {
                this.menuContatos = menuContatos;
            }

            public override TelaMenu Executar()
            {
                Console.Clear();
                menuContatos.VisualizarContatoss();
                Pausar();

                return null;
            }
        }
        #endregion
    }
}
