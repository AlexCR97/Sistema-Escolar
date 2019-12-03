using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaInsertarCarrera : Consulta
    {
        public ConsultaInsertarCarrera(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombreCarrera"] = args[0].ToString(),
                ["@paterno"] = args[1].ToString(),
                ["@materno"] = args[2].ToString(),
                ["@nombre"] = args[3].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec insertarCarrera @nombreCarrera, @paterno, @materno, @nombre";
        }
    }
}
