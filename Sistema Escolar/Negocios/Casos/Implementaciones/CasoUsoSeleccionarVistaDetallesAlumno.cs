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
    public class CasoUsoSeleccionarVistaDetallesAlumno : CasoUsoLectura<VistaDetallesAlumno>
    {
        public CasoUsoSeleccionarVistaDetallesAlumno() { }

        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaSeleccionarVistaDetallesAlumnos(args);
        }

        protected override Presentador<VistaDetallesAlumno> DefinirPresentador()
        {
            return new PresentadorVistaDetallesAlumno();
        }
    }
}
