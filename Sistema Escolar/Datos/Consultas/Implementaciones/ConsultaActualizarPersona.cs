using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaActualizarPersona : Consulta
    {
        public ConsultaActualizarPersona(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@curpActual"] = args[0],
                ["@paterno"] = args[1],
                ["@materno"] = args[2],
                ["@nombres"] = args[3],
                ["@fecha_nac"] = args[4],
                ["@sexo"] = (args[5].ToString() == "Hombre") ? true : false,
                ["@curpNueva"] = args[6],
                ["@telefono"] = args[7],
                ["@nombreCalle"] = args[8],
                ["@numExt"] = int.Parse(args[9].ToString()),
                ["@numInt"] = int.Parse(args[10].ToString()),
                ["@cp"] = int.Parse(args[11].ToString()),
                ["@edoCivil"] = int.Parse(args[12].ToString()),
                ["@discapacidad"] = int.Parse(args[13].ToString()),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec ActualizarPersona @curpActual, @paterno, @materno, @nombres, @fecha_nac, @sexo, @curpNueva, @telefono, @nombreCalle, @numExt, @numInt, @cp, @edoCivil, @discapacidad";
        }
    }
}
