using SistemaEscolar.Datos.Consultas;
using SistemaEscolar.Entidades;
using SistemaEscolar.Negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Casos.Implementaciones
{
    class CasoUsoListarGrupos : CasoUsoLectura<List<Grupo>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarGrupos(args);
        }

        protected override Presentador<List<Grupo>> DefinirPresentador()
        {
            return new PresentadorListaGrupos();
        }
    }
}
