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
    class CasoUsoListarMateriasCarreras : CasoUsoLectura<Dictionary<String, VistaMateria>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarMateriasCarreras(args);
        }

        protected override Presentador<Dictionary<string, VistaMateria>> DefinirPresentador()
        {
            return new PresentadorListaMateriasCarreras();
        }
    }
}
