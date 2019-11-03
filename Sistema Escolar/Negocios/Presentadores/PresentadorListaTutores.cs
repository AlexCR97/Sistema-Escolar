using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaTutores : Presentador<List<Tutor>>
    {
        public override List<Tutor> Procesar(DataTable dataTable)
        {
            try
            {
                var carreras = new List<Tutor>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    carreras.Add(new Tutor()
                    {
                        ApellidoPaterno = row[0].ToString(),
                        ApellidoMaterno = row[1].ToString(),
                        Nombre = row[2].ToString(),
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
