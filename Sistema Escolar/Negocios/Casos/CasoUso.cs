using SistemaEscolar.Datos.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Casos
{
    public abstract class CasoUso<T>
    {
        protected Consulta consulta;

        public CasoUso() { }

        protected abstract Consulta DefinirConsulta(params object[] args);

        public abstract T Ejecutar(params object[] args);
    }
}
