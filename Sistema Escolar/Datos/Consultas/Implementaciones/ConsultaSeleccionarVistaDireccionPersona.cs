using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarVistaDireccionPersona : Consulta
    {
        public ConsultaSeleccionarVistaDireccionPersona(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var datos = new Dictionary<string, object>();

            datos["@idPersona"] = Convert.ToInt32(args[0]);

            return datos;
        }

        protected override string DefinirQuery()
        {
            return "select personas.cp, calles.nombre as 'calle', personas.numExt, personas.numInt, localidades.nombre as 'localidad " +
                "from personas " +
                "inner join calles on personas.idCalle = calles.idCalle " +
                "inner join localidades on calles.Localidad = localidades.idLocalidad " +
                "where personas.idPersona = @idPersona";
        }
    }
}
