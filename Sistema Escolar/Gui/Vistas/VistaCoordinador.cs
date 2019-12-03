using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaCoordinador
    {
        public int IdPersona { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
        }
    }
}
