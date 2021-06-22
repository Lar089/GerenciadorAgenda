using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Controlarodes.Conectar
{
    class Conexao
    {
        private readonly string enderecoDBAgenda =
          @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBEmpresa;Integrated Security=True;Pooling=False";

        private SqlConnection conexaoComBanco;
        
        public Conexao()
        {
            conexaoComBanco = new SqlConnection(enderecoDBAgenda);
        }

        public void AbrirConexão(Action<SqlConnection> action)
        {
            conexaoComBanco.Open();

            action(conexaoComBanco);

            conexaoComBanco.Close();
        }


    }
}
