using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaAltaEmpleado : Consulta
    {
        public ConsultaAltaEmpleado(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var datos = new Dictionary<string, object>()
            {
                ["@idEmpleo"] = Convert.ToInt16(args[0].ToString()),
            };

            return datos;
        }

        protected override string DefinirQuery()
        {
            return "exec insertarEmpleado @idEmpleo";
        }
    }
}
