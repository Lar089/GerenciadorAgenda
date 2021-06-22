using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Dominios.Dominio
{
    public class Contatos
    {
        private int id;
        private string nome;
        private string email;
        private string telefone;
        private string empresa;
        private string cargo;

        public Contatos(string nome, string email, string telefone, string empresa, string cargo)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Empresa = empresa;
            this.Cargo = cargo;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Cargo { get => cargo; set => cargo = value; }

    }
}
