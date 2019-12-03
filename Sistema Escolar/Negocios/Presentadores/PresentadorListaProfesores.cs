using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaProfesores : Presentador<List<Profesor>>
    {
        public override List<Profesor> Procesar(DataTable dataTable)
        {
            try
            {
                var profesores = new List<Profesor>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    var profesor = new Profesor()
                    {
                        IdProfesor = row[0].ToString(),
                        Nombre = row[1].ToString(),
                        ApellidoPaterno = row[2].ToString(),
                        ApellidoMaterno = row[3].ToString()
                    };

                    profesores.Add(profesor);
                }

                    return profesores;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
