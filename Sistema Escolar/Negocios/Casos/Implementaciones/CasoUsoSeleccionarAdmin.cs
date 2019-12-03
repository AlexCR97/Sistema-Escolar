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
    public class CasoUsoSeleccionarAdmin : CasoUsoLectura<Administrador>
    {
        protected override Consulta DefinirConsulta(params object[] args)
        {
            return new ConsultaSeleccionarAdmin(args);
        }

        protected override Presentador<Administrador> DefinirPresentador()
        {
            return new PresentadorAdministrador();
        }
    }
}
