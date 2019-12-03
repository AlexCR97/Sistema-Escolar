using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Empleos
    {
        public int Id { get; set; }
        public string Puesto { get; set; }

        public override string ToString()
        {
            return Puesto;
        }
    }
}
