using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorTelefono : Validador<string>
    {
        public ValidadorTelefono(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() =>
            {
                try
                {
                    if (Propiedad.Length != 10)
                        return false;

                    long.Parse(Propiedad);

                    return true;
                }
                catch
                {
                    return false;
                }
            }, () => "El telefono debe de tener solamente 10 digitos");
        }
    }
}
