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
            AgregarValidacion(() =>
            {
                try
                {
                    string[] tokens = Propiedad.Split('-');
                    
                    Int32.Parse(tokens[0]);
                    Int32.Parse(tokens[1]);
                    Int32.Parse(tokens[2]);

                    return true;
                }
                catch
                {
                    return false;
                }
            }, () => "La fecha debe de tener el siguiente formato: AAAA-DD-MM");
        }
    }
}
