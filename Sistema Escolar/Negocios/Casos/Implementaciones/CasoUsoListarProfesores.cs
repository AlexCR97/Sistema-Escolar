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
    class CasoUsoListarProfesores : CasoUsoLectura<List<Profesor>>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaListarProfesores(args);
        }

        protected override Presentador<List<Profesor>> DefinirPresentador()
        {
            return new PresentadorListaProfesores();
        }
    }
}
