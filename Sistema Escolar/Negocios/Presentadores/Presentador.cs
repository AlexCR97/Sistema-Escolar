using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public abstract class Presentador<T>
    {
        public abstract T Procesar(DataTable dataTable);
    }
}
