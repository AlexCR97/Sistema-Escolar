using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaAcademias : Presentador<List<Academia>>
    {
        public override List<Academia> Procesar(DataTable dataTable)
        {
            try
            {
                var academias = new List<Academia>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    academias.Add(new Academia()
                    {
                        Id = Convert.ToInt16(row[0]),
                        Nombre = row[1].ToString(),
                    });
                }

                return academias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
