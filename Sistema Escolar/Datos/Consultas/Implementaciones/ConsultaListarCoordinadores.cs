using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaListarCoordinadores : Consulta
    {
        public ConsultaListarCoordinadores(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>();
        }

        protected override string DefinirQuery()
        {
            return "select personas.nombres, personas.paterno, " +
                "personas.materno from personas inner join empleados on " +
                "empleados.idPersona = personas.idPersona inner join empleos " +
                "on empleos.idEmpleo = empleados.idEmpleo where empleos.puesto " +
                "= 'Coordinador'; ";
        }
    }
}
