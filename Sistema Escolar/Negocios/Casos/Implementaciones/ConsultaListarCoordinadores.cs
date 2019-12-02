using System.Collections.Generic;
using SistemaEscolar.Datos.Consultas;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    public class ConsultaListarCoordinadores : Consulta
    {
        public ConsultaListarCoordinadores(params object[] args) : base(args)
        {
        }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        protected override string DefinirQuery()
        {
            throw new System.NotImplementedException();
        }
    }
}