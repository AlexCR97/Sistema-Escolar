using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaAltaProfesores : Consulta
    {
        public ConsultaAltaProfesores(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@idProfesor"] = args[0].ToString(),
                ["@idAcademia"] = Convert.ToInt16(args[1]),
                ["@tipoMemb"] = Convert.ToInt16(args[2]),
            };
        }

        protected override string DefinirQuery()
        {
            return "exec insertarProfesor @idProfesor, @idAcademia, @tipoMemb";
        }
    }
}
