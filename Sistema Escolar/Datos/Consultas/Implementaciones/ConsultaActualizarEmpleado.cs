using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarEmpleado : Consulta
    {
        public ConsultaActualizarEmpleado(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@curp"] = args[0].ToString(),
                ["@puesto"] = args[1].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarEmpleado @curp, @puesto";
        }
    }
}
