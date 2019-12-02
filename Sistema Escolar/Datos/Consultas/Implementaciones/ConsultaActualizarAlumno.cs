using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarAlumno : Consulta
    {
        public ConsultaActualizarAlumno(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@curp"] = args[0].ToString(),
                ["@matricula"] = args[1].ToString(),
                ["@nombreCarrera"] = args[2].ToString(),
                ["@paternoTutor"] = args[3].ToString(),
                ["@maternoTutor"] = args[4].ToString(),
                ["@nombresTutor"] = args[5].ToString(),
                ["@nombreEspacialidad"] = args[6].ToString(),
                ["@estatus"] = int.Parse(args[7].ToString()),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarAlumno " +
                "@curp, " +
                "@matricula, " +
                "@nombreCarrera, " +
                "@paternoTutor, " +
                "@maternoTutor, " +
                "@nombresTutor, " +
                "@nombreEspacialidad, " +
                "@estatus";
        }
    }
}
