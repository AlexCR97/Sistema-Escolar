using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorVistaDetallesAlumno : Presentador<VistaDetallesAlumno>
    {
        public override VistaDetallesAlumno Procesar(DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows[0];

                return new VistaDetallesAlumno()
                {
                    Matricula = row[0].ToString(),
                    Nombre = row[1].ToString(),
                    ApellidoPaterno = row[2].ToString(),
                    ApellidoMaterno = row[3].ToString(),
                    Carrera = row[4].ToString(),
                    Esepcialidad = row[5].ToString(),
                    FechaNacimiento = row[6].ToString(),
                    Sexo = bool.Parse(row[7].ToString()),
                    Curp = row[8].ToString(),
                    Telefono = row[9].ToString(),
                    EstadoCivil = int.Parse(row[10].ToString()),
                    CodigoPostal = int.Parse(row[11].ToString()),
                    Calle = row[12].ToString(),
                    NumeroExterior = int.Parse(row[13].ToString()),
                    NumeroInterior = int.Parse(row[14].ToString()),
                    Localidad = row[15].ToString(),
                    Municipio = row[16].ToString(),
                    Estado = row[17].ToString(),
                    IdTutor = row[18].ToString(),
                    NombreTutor = row[19].ToString(),
                    ApellidoPaternoTutor = row[20].ToString(),
                    ApellidoMaternoTutor = row[21].ToString(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
