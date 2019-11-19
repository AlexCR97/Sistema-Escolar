using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Coordinardor
    {
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
        }
    }
}
