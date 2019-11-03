using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaAltaPersona : Consulta
    {
        public ConsultaAltaPersona(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var values = new Dictionary<string, object>();

            values["@paterno"] = args[0].ToString();
            values["@materno"] = args[1].ToString();
            values["@nombres"] = args[2].ToString();
            values["@fecha_nac"] = DateTime.Parse(args[3].ToString());
            values["@sexo"] = Convert.ToBoolean(args[4]);
            values["@curp"] = args[5].ToString();
            values["@telefono"] = args[6].ToString();
            values["@nombreCalle"] = args[7].ToString();
            values["@numExt"] = args[8].ToString();
            values["@numInt"] = args[9].ToString();
            values["@cp"] = args[10].ToString();
            values["@edoCivil"] = Convert.ToInt16(args[11]);
            values["@discapacidad"] = Convert.ToInt16(args[12]);

            return values;
        }

        protected override string DefinirQuery()
        {
            return "exec IngresarPersona @paterno, @materno, @nombres, @fecha_nac, @sexo, @curp, @telefono, @nombreCalle, @numExt, @numInt, @cp, @edoCivil, @discapacidad";
        }
    }
}
