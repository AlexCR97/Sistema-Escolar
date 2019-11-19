using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaListarVistaEmpleados : Consulta
    {
        public ConsultaListarVistaEmpleados(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>();
        }

        protected override string DefinirQuery()
        {
            return "select personas.paterno, personas.materno, personas.nombres, academias.nombre, empleos.puesto " +
                "from personas " +
                "inner join empleados on empleados.idPersona = personas.idPersona " +
                "inner join empleos on empleos.idEmpleo = empleados.idEmpleo " +
                "inner join profesores on profesores.idEmpleado = empleados.idEmpleado " +
                "inner join academias on academias.idAcademia = profesores.idAcademia";
        }
    }
}
