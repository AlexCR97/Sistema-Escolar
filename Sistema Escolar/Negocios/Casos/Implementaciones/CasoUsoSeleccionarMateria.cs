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
    public class CasoUsoSeleccionarMateria : CasoUsoLectura<Materia>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            throw new NotImplementedException();
        }

        protected override Presentador<Materia> DefinirPresentador()
        {
            throw new NotImplementedException();
        }
    }
}
