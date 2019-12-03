using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaVistaMateriasConCarrera : Presentador<List<VistaMateriasConCarrera>>
    {
        public override List<VistaMateriasConCarrera> Procesar(DataTable dataTable)
        {
            try
            {
                var materias = new List<VistaMateriasConCarrera>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    materias.Add(new VistaMateriasConCarrera()
                    {
                        ClaveMaterias = row[0].ToString(),
                        NombreMateria = row[1].ToString(),
                        HorasTeoricas = int.Parse(row[2].ToString()),
                        HorasPracticas = int.Parse(row[3].ToString()),
                        Creditos = int.Parse(row[4].ToString()),
                        IdCarrera = int.Parse(row[5].ToString()),
                        Carrera = row[6].ToString(),
                    });
                }
                return materias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
