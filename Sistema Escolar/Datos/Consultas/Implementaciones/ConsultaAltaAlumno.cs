using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaAltaAlumno : Consulta
    {
        public ConsultaAltaAlumno(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var values = new Dictionary<string, object>
            {
                ["@matricula"] = args[0].ToString(),
                ["@nombreCarrera"] = args[1].ToString(),
                ["@paternoTutor"] = args[2].ToString(),
                ["@maternoTutor"] = args[3].ToString(),
                ["@nombresTutor"] = args[4].ToString(),
                ["@nombreEspacialidad"] = args[5].ToString(),
                ["@estatus"] = args[6].ToString()
            };

            return values;
        }

        protected override string DefinirQuery()
        {
            return "exec IngresarAlumno @matricula, @nombreCarrera, @paternoTutor, @maternoTutor, @nombresTutor, @nombreEspacialidad, @estatus";
        }
    }
}
