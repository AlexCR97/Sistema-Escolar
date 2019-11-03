using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarCarreras : Presentador<List<Carrera>>
    {
        public override List<Carrera> Procesar(DataTable dataTable)
        {
            try
            {
                var carreras = new List<Carrera>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    carreras.Add(new Carrera()
                    {
                        IdCarrera = Convert.ToInt16(row[0]),
                        Nombre = row[1].ToString(),
                        Coordinador = Convert.ToInt16(row[2]),
                    });
                }

                return carreras;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
