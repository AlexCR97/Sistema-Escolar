using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaListarEspecialidadesPorCarrera : Consulta
    {
        public ConsultaListarEspecialidadesPorCarrera(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            string carrera = args[0].ToString();

            var datos = new Dictionary<string, object>();
            datos["@carrera"] = carrera;

            return datos;
        }

        protected override string DefinirQuery()
        {
            return "exec SeleccionarEspecialidad @carrera";
        }
    }
}
