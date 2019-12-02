using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaDireccionPersona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Calle { get; set; }
        public int NumeroExterior { get; set; }
        public int NumeroInterior { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }

        public string DireccionCompleta
        {
            get => $"{Calle} #{NumeroExterior}, {Localidad}, {Municipio}, {Estado}";
        }
    }
}
