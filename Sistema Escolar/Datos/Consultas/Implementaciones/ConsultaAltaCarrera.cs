using System.Collections.Generic;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    class ConsultaAltaCarrera : Consulta
    {
        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            return new Dictionary<string, object>()
            {
                ["@nombreCarrera"] = args[0].ToString(),
                ["@nombre"] = args[1].ToString(),
                ["@paterno"] = args[2].ToString(),
                ["@materno"] = args[3].ToString()
            };
        }

        protected override string DefinirQuery()
        {
            return "exec insertarCarrera @nombreCarrera, @paterno, @materno, @nombre;";
        }
    }
}