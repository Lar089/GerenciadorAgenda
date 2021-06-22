using GerenciadorAgenda.Controlarodes.Controladores;
using GerenciadorAgenda.Dominios.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GerenciadorAgenda.Tests
{
    [TestClass]
    public class UnitTestTarefas
    {
        private ControladorTarefa controladorTarefa;

        Tarefa tarefa =
            new Tarefa("Tarefa de test", 20, Prioridades.Normal);

        public UnitTestTarefas()
        {
            controladorTarefa = new ControladorTarefa();
        }

        [TestMethod]
        public void TestInserir()
        {

            bool conseguiuInserir = controladorTarefa.InserirRegistro(tarefa);

            Assert.IsTrue(conseguiuInserir);
            Assert.IsTrue(tarefa.Id > 0);
        }

        [TestMethod]
        public void TestVisualizarTodos()
        {
            controladorTarefa.InserirRegistro(tarefa);

            List<Tarefa> tarefasRecuperadas = controladorTarefa.SelecionarTodosRegistros();

            Assert.IsTrue(tarefasRecuperadas.Count >= 1);
        }

        [TestMethod]
        public void TestVisualizarPorId()
        {
            controladorTarefa.InserirRegistro(tarefa);

            int id = tarefa.Id;

            Tarefa tarefaRecuperada = controladorTarefa.SelecionarRegistroPorId(id);

            Assert.AreEqual(tarefa.Id, tarefaRecuperada.Id);
            Assert.AreEqual(tarefa.Titulo, tarefaRecuperada.Titulo);
            Assert.AreEqual(tarefa.DataCriacao.ToString(), tarefaRecuperada.DataCriacao.ToString());
            Assert.AreEqual(tarefa.DataConclusao.ToString(), tarefaRecuperada.DataConclusao.ToString());
            Assert.AreEqual(tarefa.PercentualConcluido, tarefaRecuperada.PercentualConcluido);
            Assert.AreEqual(tarefa.Prioridade, tarefaRecuperada.Prioridade);
        }
    }
}
