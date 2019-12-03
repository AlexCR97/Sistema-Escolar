using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Materia
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int HorasTeoricas { get; set; }
        public int HorasPracticas { get; set; }
        public int Carrera { get; set; }
    }
}
