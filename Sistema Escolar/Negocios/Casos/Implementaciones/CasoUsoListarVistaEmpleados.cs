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
    public class CasoUsoListarVistaEmpleados : CasoUsoLectura<List<VistaEmpleados>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistaEmpleados(args);
        }

        protected override Presentador<List<VistaEmpleados>> DefinirPresentador()
        {
            return new PresentadorListarVistaEmpleados();
        }
    }
}
