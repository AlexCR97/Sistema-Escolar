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
    public class CasoUsoListarVistaMateriasConCarrera : CasoUsoLectura<List<VistaMateriasConCarrera>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarVistasMateriasConCarrera(args);
        }

        protected override Presentador<List<VistaMateriasConCarrera>> DefinirPresentador()
        {
            return new PresentadorListaVistaMateriasConCarrera();
        }
    }
}
