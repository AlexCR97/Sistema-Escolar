using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Vistas
{
    public class VistaDetallesEmpleados2
    {
        public long IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public bool Sexo { get; set; }
        public string Curp { get; set; }
        public string Telefono { get; set; }
        public int EstadoCivil { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }
        public int NumeroExterior { get; set; }
        public int NumeroInterior { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Puesto { get; set; }
        public string IdProfesor { get; set; }
        public int TipoMiembro { get; set; }
        public string Academia { get; set; }
    }
}
