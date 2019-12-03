using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaEmpleos : Presentador<List<Empleos>>
    {
        public override List<Empleos> Procesar(DataTable dataTable)
        {
            try
            {
                var emplos = new List<Empleos>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    emplos.Add(new Empleos()
                    {
                        Id = Convert.ToInt16(row[0]),
                        Puesto = row[1].ToString(),
                    });
                }

                return emplos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
