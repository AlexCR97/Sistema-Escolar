using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaVistaCarreras : Presentador<List<VistaCarrera>>
    {
        public override List<VistaCarrera> Procesar(DataTable dataTable)
        {
            try
            {
                var carreras = new List<VistaCarrera>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    carreras.Add(
                        new VistaCarrera()
                        {
                            Nombre = row[0].ToString(),
                            Especialidad = row[1].ToString(),
                            Coordinador = row[2].ToString(),
                            UrlImagen = row[3].ToString()
                        });
                }

                return carreras;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
