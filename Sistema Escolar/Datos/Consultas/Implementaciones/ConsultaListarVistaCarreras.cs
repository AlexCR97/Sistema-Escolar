using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaListarVistaCarreras : Consulta
    {
        public ConsultaListarVistaCarreras(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>();
        }

        protected override string DefinirQuery()
        {
            return "select carreras.nombre, especialidades.nombre, " +
                "personas.nombres from carreras inner join especialidades " +
                "on carreras.idCarrera = especialidades.carrera inner join " +
                "personas on carreras.coordinador = personas.idPersona";
        }
    }
}
