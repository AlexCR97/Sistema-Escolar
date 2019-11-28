using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarVistaDetallesEmpleados : Presentador<List<VistaDetallesEmpleados>>
    {
        public override List<VistaDetallesEmpleados> Procesar(DataTable dataTable)
        {
            try
            {
                var empleados = new List<VistaDetallesEmpleados>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    empleados.Add(new VistaDetallesEmpleados()
                    {
                        Nombre = row[0].ToString(),
                        ApellidoPaterno = row[1].ToString(),
                        ApellidoMaterno = row[2].ToString(),
                        Puesto = row[3].ToString(),
                        IdProfesor = row[4].ToString(),
                        Academia = row[5].ToString(),
                        FechaNacimiento = row[6].ToString(),
                        Curp = row[7].ToString(),
                        Telefono = row[8].ToString(),
                        Direccion = row[9].ToString(),
                    });
                }

                return empleados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
