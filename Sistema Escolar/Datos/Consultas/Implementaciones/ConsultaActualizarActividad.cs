using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarActividad : Consulta
    {
        public ConsultaActualizarActividad(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombreActual"] = args[0].ToString(),
                ["@nombreNuevo"] = args[1].ToString(),
                ["@descripcion"] = args[2].ToString(),
                ["@grupo"] = args[3].ToString(),
                ["@tema"] = int.Parse(args[4].ToString()),
                ["@ponderacion"] = int.Parse(args[5].ToString()),
                ["@fecha"] = DateTime.Parse(args[6].ToString()),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarActividad @nombreActual, @nombreNuevo, @descripcion, @grupo, @tema, @ponderacion, @fecha";
        }
    }
}
