using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using GerenciadorAgenda.Controlarodes.Conectar;
using GerenciadorAgenda.Dominios.Dominio;

namespace GerenciadorAgenda.Controlarodes.Controladores
{
    public class ControladorTarefa : Controlador<Tarefa>
    {
        private Conexao conexao;
        Tarefa tarefavisualizar;

        public ControladorTarefa()
        {
            this.conexao = new Conexao();
        }

        public override bool InserirRegistro(Tarefa tarefa)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(SqlInsersao, conexao);

                comando.Parameters.AddWithValue("titulo", tarefa.Titulo);
                comando.Parameters.AddWithValue("dataCriacao", tarefa.DataCriacao);
                comando.Parameters.AddWithValue("dataConclusao", tarefa.DataConclusao);
                comando.Parameters.AddWithValue("percentualConcluido", tarefa.PercentualConcluido);
                comando.Parameters.AddWithValue("prioridade", tarefa.Prioridade);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool EditarRegistro(Tarefa tarefa)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(SqlEdicao, conexao);

                comando.Parameters.AddWithValue("titulo", tarefa.Titulo);
                comando.Parameters.AddWithValue("dataCriacao", tarefa.DataCriacao);
                comando.Parameters.AddWithValue("dataConclusao", tarefa.DataConclusao);
                comando.Parameters.AddWithValue("percentualConcluido", tarefa.PercentualConcluido);
                comando.Parameters.AddWithValue("prioridade", tarefa.Prioridade);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool ExcluirRegistro(int idExcluir)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(SqlExclusao, conexao);

                comando.Parameters.AddWithValue("id", idExcluir);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override Tarefa SelecionarRegistroPorId(int idPesquisa)
        {
            Tarefa tarefa = null;
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(SqlVisualizacaoPorId, conexao);

                comando.Parameters.AddWithValue("id", idPesquisa);

                SqlDataReader leitorTarefa = comando.ExecuteReader();

                int id = Convert.ToInt32(leitorTarefa["id"]);
                string titulo = Convert.ToString(leitorTarefa["titulo"]);
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefa["dataCriacao"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorTarefa["dataConclusao"]);
                int percentualConcluido = Convert.ToInt32(leitorTarefa["percentualConcluido"]);
                string prioridade = Convert.ToString(leitorTarefa["prioridade"]);

                tarefa = new Tarefa(titulo, percentualConcluido, tarefa.DefinirPrioridade(prioridade));
                tarefa.Id = id;

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao ? tarefa : null;
        }

        public override List<Tarefa> SelecionarTodosRegistros()
        {
            List<Tarefa> listaTarefa = new List<Tarefa>();
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(SqlVisualizacaoTodos, conexao);

                SqlDataReader leitorTarefa = comando.ExecuteReader();

                while (leitorTarefa.Read())
                {
                    int id = Convert.ToInt32(leitorTarefa["id"]);
                    string titulo = Convert.ToString(leitorTarefa["titulo"]);
                    DateTime dataCriacao = Convert.ToDateTime(leitorTarefa["dataCriacao"]);
                    DateTime dataConclusao = Convert.ToDateTime(leitorTarefa["dataConclusao"]);
                    int percentualConcluido = Convert.ToInt32(leitorTarefa["percentualConcluido"]);
                    string prioridade = Convert.ToString(leitorTarefa["prioridade"]);

                    Tarefa tarefa = new Tarefa(titulo,  percentualConcluido, tarefavisualizar.DefinirPrioridade(prioridade));
                    tarefa.Id = id;

                    listaTarefa.Add(tarefa);
                }

            });
            return (List<Tarefa>)listaTarefa.OrderBy(tarefa => tarefa.Prioridade);
        }

        private string SqlInsersao = @"INSERT INTO TBTarefa 
	                            (
		                            [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            ) 
	                            VALUES
	                            (
                                    @titulo, 
		                            @dataCriacao, 
		                            @dataConclusao,
		                            @percentualConcluido,
		                            @prioridade
	                            );";

        private string SqlEdicao = @"UPDATE TBTarefa
	                            SET	
		                            [titulo] = @titulo, 
		                            [dataCriacao] = @dataCriacao, 
		                            [dataConclusao] = @dataConclusao,
		                            [percentualConcluido] = @percentualConcluido,
		                            [prioridade] = @prioridade
	                            WHERE
	                                [id] = @id";

        private string SqlExclusao = @"DELETE FROM TBTarefa
	                            WHERE
	                                [id] = @id";

        private string SqlVisualizacaoPorId = @"SELECT  
                                    [id],
		                            [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            FROM
                                    TBTarefa
                                WHERE
                                    [id] = @id";

        private string SqlVisualizacaoTodos = @"SELECT
                                    [id],
                                    [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            FROM
                                    TBTarefa";
    }
}
