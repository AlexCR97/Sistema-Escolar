using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarVistaEmpleados : Presentador<List<VistaEmpleados>>
    {
        public override List<VistaEmpleados> Procesar(DataTable dataTable)
        {
            try
            {
                var empleados = new List<VistaEmpleados>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    empleados.Add(new VistaEmpleados()
                    {
                        ApellidoP = row[0].ToString(),
                        ApellidoM = row[1].ToString(),
                        Nombre = row[2].ToString(),
                        Academia = row[3].ToString(),
                        Puesto = row[4].ToString(),
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
