using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Profesor
    {
        public String IdProfesor { get; set; }
        public String Nombre { get; set; }
        public string ApellidoPaterno { get; internal set; }
        public string ApellidoMaterno { get; internal set; }
    }
}
