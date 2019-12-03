using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaMaterias : Presentador<List<Materia>>
    {
        public override List<Materia> Procesar(DataTable dataTable)
        {
            try
            {
                var materias = new List<Materia>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    materias.Add(new Materia()
                    {
                        Codigo = row[0].ToString(),
                        Nombre = row[1].ToString(),
                        Creditos = Int32.Parse(row[2].ToString()),
                        HorasTeoricas = Int32.Parse(row[3].ToString()),
                        HorasPracticas = Int32.Parse(row[4].ToString()),
                        Carrera = Int32.Parse(row[5].ToString())
                    });
                }

                return materias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
