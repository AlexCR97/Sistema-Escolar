using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class Carrera
    {
        public string UrlImagen { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Coordinador { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Carrera {");
            sb.Append("UrlImagen: ").Append(UrlImagen).Append(", ");
            sb.Append("Codigo: ").Append(Codigo).Append(", ");
            sb.Append("Nombre: ").Append(Nombre).Append(", ");
            sb.Append("Especialidad: ").Append(Especialidad).Append(", ");
            sb.Append("Coordinador: ").Append(Coordinador).Append(" }");

            return sb.ToString();
        }
    }
}
