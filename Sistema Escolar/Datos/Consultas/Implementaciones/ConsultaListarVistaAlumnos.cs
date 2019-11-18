using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaListarVistaAlumnos : Consulta
    {
        public ConsultaListarVistaAlumnos(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>();
        }

        protected override string DefinirQuery()
        {
            return "select alumnos.matricula, personas.paterno, personas.materno, personas.nombres, carreras.nombre " +
                "from alumnos " +
                "inner join personas on alumnos.idPersona = personas.idPersona " +
                "inner join carreras on alumnos.idCarrera = carreras.idCarrera";
        }
    }
}
