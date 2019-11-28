using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorVistaDetallesEmpleados2 : Presentador<VistaDetallesEmpleados2>
    {
        public override VistaDetallesEmpleados2 Procesar(DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows[0];

                return new VistaDetallesEmpleados2()
                {
                    IdEmpleado = int.Parse(row[0].ToString()),
                    Nombres = row[1].ToString(),
                    ApellidoPaterno = row[2].ToString(),
                    ApellidoMaterno = row[3].ToString(),
                    FechaNacimiento = row[4].ToString(),
                    Sexo = bool.Parse(row[5].ToString()),
                    Curp = row[6].ToString(),
                    Telefono = row[7].ToString(),
                    EstadoCivil = int.Parse(row[8].ToString()),
                    CodigoPostal = int.Parse(row[9].ToString()),
                    Calle = row[10].ToString(),
                    NumeroExterior = int.Parse(row[11].ToString()),
                    NumeroInterior = (row[12] == DBNull.Value) ? 0 : int.Parse(row[12].ToString()),
                    Localidad = row[13].ToString(),
                    Municipio = row[14].ToString(),
                    Estado = row[15].ToString(),
                    Puesto = row[16].ToString(),
                    IdProfesor = (row[17] == DBNull.Value) ? "" : row[17].ToString(),
                    TipoMiembro = (row[18] == DBNull.Value) ? 0 : int.Parse(row[18].ToString()),
                    Academia = (row[19] == DBNull.Value) ? "" : row[19].ToString(),
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
