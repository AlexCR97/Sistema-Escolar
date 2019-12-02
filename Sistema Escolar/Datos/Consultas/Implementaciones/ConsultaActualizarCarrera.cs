using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarCarrera : Consulta
    {
        public ConsultaActualizarCarrera(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombreActual"] = args[0].ToString(),
                ["@nombreNuevo"] = args[1].ToString(),
                ["@paterno"] = args[2].ToString(),
                ["@materno"] = args[3].ToString(),
                ["@nombres"] = args[4].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarCarrera @nombreActual, @nombreNuevo, @paterno, @materno, @nombres";
        }
    }
}
