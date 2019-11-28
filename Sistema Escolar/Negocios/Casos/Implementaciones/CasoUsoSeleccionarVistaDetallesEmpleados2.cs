using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Datos.Consultas.Implementaciones;
using SistemaEscolar.Gui.Vistas;
using SistemaEscolar.Negocios.Presentadores;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    public class CasoUsoSeleccionarVistaDetallesEmpleados2 : CasoUsoLectura<VistaDetallesEmpleados2>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaSeleccionarVistaDetallesEmpleados2(args);
        }

        protected override Presentador<VistaDetallesEmpleados2> DefinirPresentador()
        {
            return new PresentadorVistaDetallesEmpleados2();
        }
    }
}
