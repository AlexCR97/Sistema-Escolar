using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaVistaCarrerasEspecialidades : Presentador<List<VistaCarrerasEspecialidades>>
    {
        public override List<VistaCarrerasEspecialidades> Procesar(DataTable dataTable)
        {
            try
            {
                var vistas = new List<VistaCarrerasEspecialidades>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    vistas.Add(new VistaCarrerasEspecialidades()
                    {
                        IdCarrera = int.Parse(row[0].ToString()),
                        Carrera = row[1].ToString(),
                        IdCoordinador = int.Parse(row[2].ToString()),
                        NombreCoordinador = row[3].ToString(),
                        ApellidoPaternoCoordinador = row[4].ToString(),
                        ApellidoMaternoCoordinador = row[5].ToString(),
                        IdEspecialidad = int.Parse(row[6].ToString()),
                        Especialidad = row[7].ToString(),
                    });
                }

                return vistas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
