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
    public class CasoUsoListarCarreras : CasoUsoLectura<List<Carrera>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarCarreras(args);
        }

        protected override Presentador<List<Carrera>> DefinirPresentador()
        {
            return new PresentadorListarCarreras();
        }
    }
}
