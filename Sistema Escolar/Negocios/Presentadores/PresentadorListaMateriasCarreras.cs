using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaMateriasCarreras : Presentador<Dictionary<String, VistaMateria>>
    {
        public override Dictionary<string, VistaMateria> Procesar(DataTable dataTable)
        {
            try
            {
                var materiasCarreras = new Dictionary<String, VistaMateria>();

                foreach (DataRow row in dataTable.Rows)
                {
                    var materia = new VistaMateria()
                    {
                        Codigo = row[0].ToString(),
                        Nombre = row[1].ToString(),
                        HorasTeoricas = Int32.Parse(row[2].ToString()),
                        HorasPracticas = Int32.Parse(row[3].ToString()),
                        Creditos = Int32.Parse(row[4].ToString()),
                        // 5 es el id.
                        Carrera = row[6].ToString()
                    };

                    materiasCarreras[materia.Codigo] = materia;
                }

                return materiasCarreras;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
