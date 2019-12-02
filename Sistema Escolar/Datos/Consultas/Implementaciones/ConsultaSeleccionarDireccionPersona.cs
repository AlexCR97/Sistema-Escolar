using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarDireccionPersona : Consulta
    {
        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@IdPersona"] = args[0],
            };
        }

        protected override string DefinirQuery()
        {
            return "select * from DireccionesPersonas where [Id persona] = @IdPersona";
        }
    }
}
