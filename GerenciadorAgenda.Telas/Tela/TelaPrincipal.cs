using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAgenda.Controlarodes.Controladores;
using GerenciadorAgenda.Dominios.Dominio;

namespace GerenciadorAgenda.Telas.Tela
{
    class TelaPrincipal : TelaMenu
    {
        public TelaPrincipal(Controlador<Tarefa> controladorTarefa, Controlador<Contatos> controladorContatos) 
            : base("Agenda Eletronica")
        {
            TelaTarefa telaTarefa = new TelaTarefa(controladorTarefa);
            TelaContatos telaContatos = new TelaContatos(controladorContatos);;

            AdicionarOpcao(telaTarefa);
            AdicionarOpcao(telaContatos);
        }
    }
}
