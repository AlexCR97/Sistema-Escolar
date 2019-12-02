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
    class CasoUsoListarMaterias : CasoUsoLectura<List<Materia>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarMaterias(args);
        }

        protected override Presentador<List<Materia>> DefinirPresentador()
        {
            return new PresentadorListaMaterias();
        }
    }
}
