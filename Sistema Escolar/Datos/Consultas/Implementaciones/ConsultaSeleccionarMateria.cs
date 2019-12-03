using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarMateria : Consulta
    {
        public ConsultaSeleccionarMateria(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return null;
        }

        protected override string DefinirQuery()
        {
            return "";
        }
    }
}
