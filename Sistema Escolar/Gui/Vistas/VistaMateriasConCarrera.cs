using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaMateriasConCarrera
    {
        public string ClaveMaterias { get; set; }
        public string NombreMateria { get; set; }
        public int HorasTeoricas { get; set; }
        public int HorasPracticas { get; set; }
        public int Creditos { get; set; }
        public int IdCarrera { get; set; }
        public string Carrera { get; set; }
    }
}
