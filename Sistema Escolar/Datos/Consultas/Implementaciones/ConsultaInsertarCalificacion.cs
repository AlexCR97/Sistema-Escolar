using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaInsertarCalificacion : Consulta
    {
        public ConsultaInsertarCalificacion(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@grupo"] = args[0].ToString(),
                ["@matricula"] = args[1].ToString(),
                ["@tema"] = args[2].ToString(),
                ["@calificacion"] = args[3].ToString(),
                ["@tipoEval"] = args[4].ToString(),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec InsertarCalificacion @grupo, @matricula, @tema, @calificacion, @tipoEval";
        }
    }
}
