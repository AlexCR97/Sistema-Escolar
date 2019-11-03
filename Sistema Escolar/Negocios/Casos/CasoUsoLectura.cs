using SistemaEscolar.Negocios.Presentadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Casos
{
    public abstract class CasoUsoLectura<T> : CasoUso<T>
    {
        protected abstract Presentador<T> DefinirPresentador();

        public override T Ejecutar(params object[] args)
        {
            consulta = DefinirConsulta(args);
            DataTable dataTable = consulta.EjecutarSelect();
            Presentador<T> presentador = DefinirPresentador();
            return presentador.Procesar(dataTable);
        }
    }
}
