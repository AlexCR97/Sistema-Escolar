using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaCarrerasEspecialidades
    {
        public int IdCarrera { get; set; }
        public string Carrera { get; set; }
        public int IdCoordinador { get; set; }
        public string NombreCoordinador { get; set; }
        public string ApellidoPaternoCoordinador { get; set; }
        public string ApellidoMaternoCoordinador { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
    }
}
