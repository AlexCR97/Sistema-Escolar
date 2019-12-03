using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEscolar.Datos.Consultas;

namespace SistemaEscolar.Negocios.Casos
{
    public abstract class CasoUsoEscritura : CasoUso<bool>
    {
        public override bool Ejecutar(params object[] args)
        {
            consulta = DefinirConsulta(args);
            return consulta.EjecutarQuery();
        }
    }
}
