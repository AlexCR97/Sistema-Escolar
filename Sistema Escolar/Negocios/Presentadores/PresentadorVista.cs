using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public abstract class PresentadorVista<T, U>
    {
        public abstract T Procesar(U entidad);
    }
}
