using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaInsertarActividad : Consulta
    {
        public ConsultaInsertarActividad(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombre"] = args[0].ToString(),
                ["@descripcion"] = args[1].ToString(),
                ["@grupo"] = args[2].ToString(),
                ["@tema"] = int.Parse(args[3].ToString()),
                ["@ponderacion"] = int.Parse(args[4].ToString()),
                ["@fecha"] = DateTime.Parse(args[5].ToString()),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec InsertarActividad @nombre, @descripcion, @grupo, @tema, @ponderacion, @fecha";
        }
    }
}
