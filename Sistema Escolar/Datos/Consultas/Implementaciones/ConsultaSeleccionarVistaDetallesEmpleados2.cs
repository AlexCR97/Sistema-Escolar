using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarVistaDetallesEmpleados2 : Consulta
    {
        public ConsultaSeleccionarVistaDetallesEmpleados2(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@Nombre"] = args[0].ToString(),
                ["@ApellidoPaterno"] = args[1].ToString(),
                ["@ApellidoMaterno"] = args[2].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "select * " +
                "from DetallesEmpleados2 " +
                "where " +
                "[Nombre] = @Nombre and " +
                "[Apellido paterno] = @ApellidoPaterno and " +
                "[Apellido materno] = @ApellidoMaterno";
        }
    }
}
