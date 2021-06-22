using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Dominios.Dominio
{
    public class Tarefa
    {
        private int id;
        private string titulo;
        private DateTime dataCriacao;
        private DateTime ? dataConclusao;
        private int percentualConcluido;
        private Prioridades prioridade;

        public Tarefa(string titulo, int percentualConcluido, Prioridades prioridade)
        {
            this.Titulo = titulo;
            this.DataCriacao = DateTime.Now;
            this.PercentualConcluido = DefinirPercentualConcluido(percentualConcluido);
            this.Prioridade = prioridade;
        }

        public Tarefa(int id, int percentualConcluido)
        {
            this.Id = id;
            this.PercentualConcluido = DefinirPercentualConcluido(percentualConcluido);
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public int PercentualConcluido { get => percentualConcluido; set => percentualConcluido = value; }
        public Prioridades Prioridade { get => prioridade; set => prioridade = value; }
        public DateTime? DataConclusao { get => DataConclusao; set => dataConclusao = value;}

        public int DefinirPercentualConcluido(int percentual)
        {
            if (percentual == 100)
                DataConclusao = DateTime.Now;
            return percentual;
        }


        public Prioridades DefinirPrioridade(string tipo)
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
}
