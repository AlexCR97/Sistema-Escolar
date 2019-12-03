using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaVistaCoordinador : Presentador<List<VistaCoordinador>>
    {
        public override List<VistaCoordinador> Procesar(DataTable dataTable)
        {
            try
            {
                var coordinadores = new List<VistaCoordinador>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    coordinadores.Add(new VistaCoordinador()
                    {
                        IdPersona = int.Parse(row[0].ToString()),
                        IdEmpleado = int.Parse(row[1].ToString()),
                        Nombre = row[2].ToString(),
                        ApellidoPaterno = row[3].ToString(),
                        ApellidoMaterno = row[4].ToString(),
                    });
                }

                return coordinadores;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
