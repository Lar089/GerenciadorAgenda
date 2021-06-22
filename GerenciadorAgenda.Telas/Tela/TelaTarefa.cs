using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAgenda.Dominios.Dominio;
using GerenciadorAgenda.Telas.Mensagens;
using GerenciadorAgenda.Controlarodes.Controladores;

namespace GerenciadorAgenda.Telas.Tela
{
    class TelaTarefa : TelaMenu
    {
        private readonly Controlador<Tarefa> controladorTarefa;

        public TelaTarefa(Controlador<Tarefa> controladorTarefa) : base("Tarefa")
        {
            this.controladorTarefa = controladorTarefa;

            AdicionarOpcao(new TelaTarefaInserir(this));
            AdicionarOpcao(new TelaTarefaEditar(this));
            AdicionarOpcao(new TelaTarefaExcluir(this));
            AdicionarOpcao(new TelaTarefaVisualizar(this));
        }

        private bool VerificarDependenciasTarefa()
        {
            if (controladorTarefa.SelecionarTodosRegistros().Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                ImprimirMensagem("Nenhum Tarefa cadastrado, por favor cadastre alguma", TipoMensagem.ERRO);
                Pausar();
                return false;
            }
            return true;
        }

        public void VisualizarTarefas()
        {
            string template = "{0, -3} | {1, -20} | {2, -15} | {3, -15} | {4, -10} | {5, -10}";

            Console.WriteLine(template, "Id", "Titulo", "Data de Criação", "Data de Conclusão", "Percentual de Concluido", "Prioridade");
            Console.WriteLine();

            List<Tarefa> tarefas = controladorTarefa.SelecionarTodosRegistros();

            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhum Tarefa cadastrada");
            }

            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine(template, tarefa.Id, tarefa.Titulo,
                    tarefa.DataCriacao, tarefa.DataConclusao, tarefa.PercentualConcluido,
                    tarefa.Prioridade);
            }
        }

        #region Opções CRUD
        private class TelaTarefaInserir : TelaMenu
        {
            private TelaTarefa telaTarefa;
            Tarefa tarefa;

            public TelaTarefaInserir(TelaTarefa telaTarefa) : base("Inserir")
            {
                this.telaTarefa = telaTarefa;
            }

            public override TelaMenu Executar()
            {
                Console.Clear();
                
                Console.Write("Digite o Titulo da Tarefa: ");
                string titulo = Console.ReadLine();

                Console.Write("Digite o Percentual Concluido da Tarefa: ");
                int percentualConcluido = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite a Prioridade da Tarefa(Alta, Normal, Baixa): ");
                string prioridade = Console.ReadLine();

                Console.WriteLine();
                tarefa = new Tarefa(titulo, percentualConcluido, tarefa.DefinirPrioridade(prioridade));
                bool conseguiuInserir = telaTarefa.controladorTarefa.InserirRegistro(tarefa);

                if (conseguiuInserir)
                    ImprimirMensagem("Nova Tarefa criada com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao criar uma nova tarefa", TipoMensagem.ERRO);

                Pausar();
                return null;
            }
        }

        private class TelaTarefaEditar : TelaMenu
        {
            private TelaTarefa telaTarefa;

            public TelaTarefaEditar(TelaTarefa telaTarefa) : base("Editar")
            {
                this.telaTarefa = telaTarefa;
            }

            public override TelaMenu Executar()
            {
                if (!telaTarefa.VerificarDependenciasTarefa())
                    return null;

                Console.Clear();

                telaTarefa.VisualizarTarefas();
                Console.Write("\nDigite o id do Tarefa que você deseja editar: ");
                int id = LerInt();

                Console.Write("Digite o Titulo da Tarefa: ");
                string titulo = Console.ReadLine();

                Console.Write("Digite o Percentual Concluido da Tarefa: ");
                int percentualConcluido = Convert.ToInt32(Console.ReadLine());

                Console.Write("Digite a Prioridade da Tarefa:(Alta, Normal, Baixa) ");
                string prioridade = Console.ReadLine();

                Console.WriteLine();
                Tarefa tarefa = new Tarefa(titulo, percentualConcluido, DefinirPrioridade(prioridade));
                tarefa.Id = id;
                bool conseguiuEditar = telaTarefa.controladorTarefa.InserirRegistro(tarefa);
                
                if (conseguiuEditar)
                    ImprimirMensagem("Tarefa alterada com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao alterar a tarefa", TipoMensagem.ERRO);

                Pausar();
                return null;
            }

            private Prioridades DefinirPrioridade(string tipo)
            {
                switch (tipo)
                {
                    case "Alta":
                        return Prioridades.Alta;
                    case "Normal":
                        return Prioridades.Normal;
                    case "Baixa":
                        return Prioridades.Baixa;
                }
                return Prioridades.Normal;
            }
        }

        private class TelaTarefaExcluir : TelaMenu
        {
            private TelaTarefa telaTarefa;

            public TelaTarefaExcluir(TelaTarefa telaTarefa) : base("Excluir")
            {
                this.telaTarefa = telaTarefa;
            }

            public override TelaMenu Executar()
            {
                if (!telaTarefa.VerificarDependenciasTarefa())
                    return null;

                Console.Clear();
                telaTarefa.VisualizarTarefas();
                Console.Write("\nDigite o id do Tarefa que deseja excluir: ");
                int id = LerInt();
                bool conseguiuExcluir = telaTarefa.controladorTarefa.ExcluirRegistro(id);

                if (conseguiuExcluir)
                    ImprimirMensagem("Tarefa excluida com sucesso", TipoMensagem.SUCESSO);
                else
                    ImprimirMensagem("Erro ao excluir a tarefa", TipoMensagem.ERRO);


                Pausar();
                return null;
            }
        }

        private class TelaTarefaVisualizar : TelaMenu
        {
            private TelaTarefa telaTarefa;

            public TelaTarefaVisualizar(TelaTarefa telaTarefa) : base("Visualizar")
            {
                this.telaTarefa = telaTarefa;
            }

            public override TelaMenu Executar()
            {
                Console.Clear();
                telaTarefa.VisualizarTarefas();
                Pausar();

                return null;
            }
        }
        #endregion
    }
}
