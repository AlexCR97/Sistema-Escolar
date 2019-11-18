using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Datos.Consultas.Implementaciones;
using SistemaEscolar.Negocios.Presentadores;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    public class CasoUsoListarEspecialidadesPorCarrera : CasoUsoLectura<List<string>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarEspecialidadesPorCarrera(args);
        }

        protected override Presentador<List<string>> DefinirPresentador()
        {
            return new PresentadorListarEspecialidadesPorCarrera();
        }
    }
}
