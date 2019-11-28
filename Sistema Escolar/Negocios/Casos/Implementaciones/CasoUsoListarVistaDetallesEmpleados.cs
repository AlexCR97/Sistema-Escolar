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
    public class CasoUsoListarVistaDetallesEmpleados : CasoUsoLectura<List<VistaDetallesEmpleados>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistaDetallesEmpleados(args);
        }

        protected override Presentador<List<VistaDetallesEmpleados>> DefinirPresentador()
        {
            return new PresentadorListarVistaDetallesEmpleados();
        }
    }
}
