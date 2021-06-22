using GerenciadorAgenda.Controlarodes.Controladores;
using GerenciadorAgenda.Dominios.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Tests
{
    [TestClass]
    class UnitTestContatos
    {
        public class UnitTestTarefas
        {
            private ControladorContatos controladorContatos;

            Contatos contato =
                new Contatos("Carol", "carol@gmail.com", "999887766", 
                    "ndd", "bolsista");

            public UnitTestTarefas()
            {
                controladorContatos = new ControladorContatos();
            }

            [TestMethod]
            public void TestInserir()
            {

                bool conseguiuInserir = controladorContatos.InserirRegistro(contato);

                Assert.IsTrue(conseguiuInserir);
                Assert.IsTrue(contato.Id > 0);
            }

            [TestMethod]
            public void TestVisualizarTodos()
            {
                controladorContatos.InserirRegistro(contato);

                List<Contatos> listaContatos = 
                    controladorContatos.SelecionarTodosRegistros();

                Assert.IsTrue(listaContatos.Count >= 1);
            }

            [TestMethod]
            public void TestVisualizarPorId()
            {
                controladorContatos.InserirRegistro(contato);
                int id = contato.Id;

                Contatos contatosPesquisa = 
                    controladorContatos.SelecionarRegistroPorId(id);

                Assert.AreEqual(contato.Id, contatosPesquisa.Id);
                Assert.AreEqual(contato.Nome, contatosPesquisa.Nome);
                Assert.AreEqual(contato.Email, contatosPesquisa.Email);
                Assert.AreEqual(contato.Telefone, contatosPesquisa.Telefone);
                Assert.AreEqual(contato.Empresa, contatosPesquisa.Empresa);
                Assert.AreEqual(contato.Cargo, contatosPesquisa.Cargo);
            }
        }
    }
}
