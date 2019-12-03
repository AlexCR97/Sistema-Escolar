using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorCorreoElectronico : Validador<string>
    {
        public ValidadorCorreoElectronico(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() =>
            {
                string[] tokens = Propiedad.Split('@');
                
                if (!tokens[1].Contains('.'))
                {
                    return false;
                }

                return true;

            }, () => "El formato de correo electronico es: correo@direccion.com");
        }
    }
}
