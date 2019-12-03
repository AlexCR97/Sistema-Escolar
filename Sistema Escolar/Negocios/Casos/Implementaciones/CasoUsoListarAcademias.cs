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
    public class CasoUsoListarAcademias : CasoUsoLectura<List<Academia>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarAcademias(args);
        }

        protected override Presentador<List<Academia>> DefinirPresentador()
        {
            return new PresentadorListaAcademias();
        }
    }
}
