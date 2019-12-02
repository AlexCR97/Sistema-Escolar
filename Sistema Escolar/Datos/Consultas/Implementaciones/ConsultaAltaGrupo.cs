using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaAltaGrupo : Consulta
    {
        public ConsultaAltaGrupo(params object[] args) : base(args)
        {
        }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var values = new Dictionary<string, object>();
            values["@claveGrupo"] = args[0].ToString();
            values["@claveMateria"] = args[1].ToString();
            values["@aula"] = args[2].ToString();
            values["@claveProfesor"] = args[3].ToString();
            values["@hora"] = Int32.Parse(args[4].ToString());
            values["@dia"] = Int32.Parse(args[5].ToString());

            return values;
        }

        protected override string DefinirQuery()
        {
            return "exec IngresarGrupo @claveGrupo, @claveMateria, @aula, @claveProfesor, @hora, @dia";
        }
    }
}
