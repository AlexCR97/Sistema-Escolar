using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarEspecialidad : Consulta
    {
        public ConsultaActualizarEspecialidad(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombreActual"] = args[0].ToString(),
                ["@nombreNuevo"] = args[1].ToString(),
                ["@nombreCarrera"] = args[2].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarEspecialidad @nombreActual, @nombreNuevo, @nombreCarrera";
        }
    }
}
