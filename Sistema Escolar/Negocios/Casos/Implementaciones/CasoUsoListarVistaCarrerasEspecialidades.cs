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
    public class CasoUsoListarVistaCarrerasEspecialidades : CasoUsoLectura<List<VistaCarrerasEspecialidades>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistaCarrerasEspecialidades(args);
        }

        protected override Presentador<List<VistaCarrerasEspecialidades>> DefinirPresentador()
        {
            return new PresentadorListaVistaCarrerasEspecialidades();
        }
    }
}
