using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Alumno : Persona
    {
        public string Matricula { get; set; }
        public int IdCarrera { get; set; }
        public string Tutor { get; set; }
        public int IdEspecialidad { get; set; }
        public int Estatus { get; set; }
    }
}
