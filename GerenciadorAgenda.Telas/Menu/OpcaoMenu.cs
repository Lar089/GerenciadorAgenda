using GerenciadorAgenda.Telas.Tela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Menu
{
    class OpcaoMenu
    {
        private int n;
        private TelaMenu menu;

        public OpcaoMenu(int n, TelaMenu menu)
        {
            this.n = n;
            this.menu = menu;
        }

        public int N { get => n; set => n = value; }
        public TelaMenu Menu { get => menu; set => menu = value; }
    }
}
