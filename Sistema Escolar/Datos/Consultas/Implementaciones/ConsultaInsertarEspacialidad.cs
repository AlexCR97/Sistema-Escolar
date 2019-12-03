using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaInsertarEspacialidad : Consulta
    {
        public ConsultaInsertarEspacialidad(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombre"] = args[0].ToString(),
                ["@nombreCarrera"] = args[1].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec InsertarEspacialidad @nombre, @nombreCarrera";
        }
    }
}
