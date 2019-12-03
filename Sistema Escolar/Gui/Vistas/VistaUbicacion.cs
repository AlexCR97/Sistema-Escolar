using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaUbicacion
    {
        public int IdCalle { get; set; }
        public string NombreCalle { get; set; }
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public int TipoLocalidad { get; set; }
        public int IdMunicipios { get; set; }
        public string NombreMunicipio { get; set; }
        public int NumeroMunicipio { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
    }
}
