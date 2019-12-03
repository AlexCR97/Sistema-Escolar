using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarVistaAlumno : Presentador<List<VistaAlumno>>
    {
        public override List<VistaAlumno> Procesar(DataTable dataTable)
        {
            try
            {
                var alumnos = new List<VistaAlumno>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    alumnos.Add(new VistaAlumno()
                    {
                        Matricula = row[0].ToString(),
                        ApellidoP = row[1].ToString(),
                        ApellidoM = row[2].ToString(),
                        Nombre = row[3].ToString(),
                        Carrera = row[4].ToString(),
                        Tutor = row[5].ToString(),
                    });
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
