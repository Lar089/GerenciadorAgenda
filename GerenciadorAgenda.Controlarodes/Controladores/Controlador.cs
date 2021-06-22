using GerenciadorAgenda.Controlarodes.Conectar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Controlarodes.Controladores
{
    public abstract class Controlador<T> where T: class
    {
        public abstract bool InserirRegistro(T registro);

        public abstract bool EditarRegistro(T registro);

        public abstract bool ExcluirRegistro(int id);

        public abstract List<T> SelecionarTodosRegistros();

        public abstract T SelecionarRegistroPorId(int id);
    }
}
