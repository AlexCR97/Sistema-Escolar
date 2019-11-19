using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaCoordinadores : Presentador<List<Coordinardor>>
    {
        public override List<Coordinardor> Procesar(DataTable dataTable)
        {
            try
            {
                var coordinadores = new List<Coordinardor>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    coordinadores.Add(
                        new Coordinardor()
                        {
                            ApellidoPaterno = row[0].ToString(),
                            ApellidoMaterno = row[1].ToString(),
                            Nombre = row[2].ToString()
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
