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
    public class CasoUsoListarVistaAlumnos : CasoUsoLectura<List<VistaAlumno>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistaAlumnos(args);
        }

        protected override Presentador<List<VistaAlumno>> DefinirPresentador()
        {
            return new PresentadorListarVistaAlumno();
        }
    }
}
