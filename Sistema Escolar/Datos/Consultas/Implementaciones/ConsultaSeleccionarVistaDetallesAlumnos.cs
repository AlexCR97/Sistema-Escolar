using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarVistaDetallesAlumnos : Consulta
    {
        public ConsultaSeleccionarVistaDetallesAlumnos(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@matricula"] = args[0].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "select * from DetallesAlumnos2 where Matricula = @matricula";
        }
    }
}
