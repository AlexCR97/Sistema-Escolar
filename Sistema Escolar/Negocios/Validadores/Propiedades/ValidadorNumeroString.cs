using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Validadores.Propiedades
{
    public class ValidadorNumeroString : Validador<string>
    {
        public ValidadorNumeroString(string propiedad) : base(propiedad) { }

        protected override void DefinirValidaciones()
        {
            AgregarValidacion(() =>
            {
                try
                {
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine($"Propiedad: {Propiedad}");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("=========================================================");
                    Console.WriteLine("=========================================================");

                    if (String.IsNullOrWhiteSpace(Propiedad))
                        return false;

                    long.Parse(Propiedad);

                    return true;
                }
                catch
                {
                    return false;
                }
            }, () => "Formato incorrecto de numero: " + Propiedad);
        }
    }
}
