using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Datos.Consultas.Implementaciones;
using SistemaEscolar.Gui.Vistas;
using SistemaEscolar.Negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    public class CasoUsoListarVistaUbicaciones : CasoUsoLectura<List<VistaUbicacion>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistasUbicaciones(args);
        }

        protected override Presentador<List<VistaUbicacion>> DefinirPresentador()
        {
            return new PresentadorListarVistaUbicacion();
        }
    }
}
