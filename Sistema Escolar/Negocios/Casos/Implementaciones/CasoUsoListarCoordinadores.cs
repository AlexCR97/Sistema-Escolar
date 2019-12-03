using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Datos.Consultas.Implementaciones;
using SistemaEscolar.Entidades;
using SistemaEscolar.Negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    class CasoUsoListarCoordinadores : CasoUsoLectura<List<Coordinardor>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarCoordinadores(args);
        }

        protected override Presentador<List<Coordinardor>> DefinirPresentador()
        {
            return new PresentadorListaCoordinadores();
        }
    }
}
