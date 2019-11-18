using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaDireccion
    {
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }
        public int NumeroExt { get; set; }
        public int NumeroInt { get; set; }
        public string Localidad { get; set; }

        public override string ToString()
        {
            return $"{Calle} #{NumeroExt}, {Localidad}";
        }
    }
}
