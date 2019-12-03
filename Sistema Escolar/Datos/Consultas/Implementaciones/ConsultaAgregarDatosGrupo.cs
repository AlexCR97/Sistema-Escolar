using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaAgregarDatosGrupo : Consulta
    {
        public ConsultaAgregarDatosGrupo(params object[] args) : base(args)
        {
        }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var values = new Dictionary<string, object>();
            values["@claveGrupo"] = args[0].ToString();
            values["@aula"] = args[1].ToString();
            values["@hora"] = Int32.Parse(args[2].ToString());
            values["@dia"] = Int32.Parse(args[3].ToString());

            return values;
        }

        protected override string DefinirQuery()
        {
            return "exec InsertarDatosGrupo @claveGrupo, @aula, @hora, @dia";
        }
    }
}
