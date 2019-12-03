using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorStringNoVacio : Validador<string>
    {
        public ValidadorStringNoVacio(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() => !String.IsNullOrWhiteSpace(Propiedad), () => "El valor no puede ser vacio");
        }
    }
}
