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
    public class CasoUsoListarEspecialidades : CasoUsoLectura<List<Especialidad>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarEspecialidades(args);
        }

        protected override Presentador<List<Especialidad>> DefinirPresentador()
        {
            return new PresentadorListarEspecialidades();
        }
    }
}
