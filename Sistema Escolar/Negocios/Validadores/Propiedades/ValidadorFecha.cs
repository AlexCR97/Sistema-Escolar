using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorFecha : Validador<string>
    {
        public ValidadorFecha(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            
        }
    }
}
