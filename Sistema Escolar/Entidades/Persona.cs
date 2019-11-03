using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Entidades
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public bool Sexo { get; set; }
        public string Curp { get; set; }
        public string Telefono { get; set; }
        public int IdCalle { get; set; }
        public int NumeroExterior { get; set; }
        public int NumeroInterior { get; set; }
        public int CodigoPostal { get; set; }
        public int EstadoCivil { get; set; }
        public int Discapacidad { get; set; }
    }
}
