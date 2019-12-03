using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarProfesor : Consulta
    {
        public ConsultaActualizarProfesor(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@idProfesor"] = args[0].ToString(),
                ["@idProfesorNuevo"] = args[1].ToString(),
                ["@nombreAcademia"] = args[2].ToString(),
                ["@tipoMemb"] = int.Parse(args[3].ToString()),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarProfesor @idProfesor, @idProfesorNuevo, @nombreAcademia, @tipoMemb";
        }
    }
}
