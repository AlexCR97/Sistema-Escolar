using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Datos.Consultas.Implementaciones;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    public class CasoUsoActualizarCarrera : CasoUsoEscritura
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaActualizarCarrera(args);
        }
    }
}
