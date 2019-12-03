using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorVistaDireccionPersona : Presentador<VistaDireccionPersona>
    {
        public override VistaDireccionPersona Procesar(DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows[0];

                return new VistaDireccionPersona()
                {
                    IdPersona = int.Parse(row[0].ToString()),
                    Nombre = row[1].ToString(),
                    ApellidoPaterno = row[2].ToString(),
                    ApellidoMaterno = row[3].ToString(),
                    Calle = row[4].ToString(),
                    NumeroExterior = int.Parse(row[5].ToString()),
                    NumeroInterior = (row[6] == DBNull.Value) ? -1 : int.Parse(row[6].ToString()),
                    Localidad = row[7].ToString(),
                    Municipio = row[8].ToString(),
                    Estado = row[9].ToString(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
