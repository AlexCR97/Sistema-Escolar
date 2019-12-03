using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaRegistrarMateria : Consulta
    {
        public ConsultaRegistrarMateria(params object[] args) : base(args)
        {
        }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            var values = new Dictionary<string, object>()
            {
                ["@claveMateria"] = args[0].ToString(),
                ["@nombre"] = args[1].ToString(),
                ["@h_teoricas"] = Int32.Parse(args[2].ToString()),
                ["@h_practicas"] = Int32.Parse(args[3].ToString()),
                ["@creditos"] = Int32.Parse(args[4].ToString()),
                ["@nombre_carrera"] = args[5].ToString()
            };
            return values;
        }

        protected override string DefinirQuery()
        {
            return "exec insertarMaterias @claveMateria, @nombre, @h_teoricas, @h_practicas, @creditos, @nombre_carrera";
        }
    }
}
