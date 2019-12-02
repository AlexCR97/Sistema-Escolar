using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Grupo
    {
        public String ClaveGrupo { get; set; }
        public String NombreMateria { get; set; }
        public String ClaveProfesor { get; set; }
        public String Aula { get; set; }
        public Int32 Hora { get; set; }
        public Int32 Dia { get; set; }

        public override string ToString()
        {
            return Aula;
        }
    }
}
