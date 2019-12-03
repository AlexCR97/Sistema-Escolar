using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListarVistaUbicacion : Presentador<List<VistaUbicacion>>
    {
        public override List<VistaUbicacion> Procesar(DataTable dataTable)
        {
            try
            {
                var ubicaciones = new List<VistaUbicacion>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    ubicaciones.Add(new VistaUbicacion()
                    {
                        IdCalle = Int32.Parse(row[0].ToString()),
                        NombreCalle = row[1].ToString(),
                        IdLocalidad = Int32.Parse(row[2].ToString()),
                        NombreLocalidad = row[3].ToString(),
                        TipoLocalidad = Int32.Parse(row[4].ToString()),
                        IdMunicipios = Int32.Parse(row[5].ToString()),
                        NombreMunicipio = row[6].ToString(),
                        NumeroMunicipio = Int32.Parse(row[7].ToString()),
                        IdEstado = Int32.Parse(row[8].ToString()),
                        NombreEstado = row[9].ToString(),
                    });
                }

                return ubicaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
