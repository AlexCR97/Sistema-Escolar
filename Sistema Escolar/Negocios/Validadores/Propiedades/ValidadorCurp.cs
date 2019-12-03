using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorCurp : Validador<string>
    {
        public ValidadorCurp(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() => Propiedad.Length == 18, () => "La curp debe de tener 18 caracteres");
        }
    }
}
