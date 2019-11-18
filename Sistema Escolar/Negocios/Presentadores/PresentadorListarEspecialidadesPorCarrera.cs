using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarEspecialidadesPorCarrera : Presentador<List<string>>
    {
        public override List<string> Procesar(DataTable dataTable)
        {
            try
            {
                var especialidades = new List<string>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    especialidades.Add(row[0].ToString());
                }

                return especialidades;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
