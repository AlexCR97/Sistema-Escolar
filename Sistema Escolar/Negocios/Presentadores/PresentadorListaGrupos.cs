using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    class PresentadorListaGrupos : Presentador<List<Grupo>>
    {
        public override List<Grupo> Procesar(DataTable dataTable)
        {
            try
            {
                var grupos = new List<Grupo>();

                foreach (DataRow row in dataTable.Rows)
                {
                    grupos.Add(new Grupo()
                    {
                        ClaveGrupo = row[0].ToString(),
                        NombreMateria = row[1].ToString(),
                        Aula = row[2].ToString(),
                        ClaveProfesor = row[3].ToString(),
                        Hora = Int32.Parse(row[4].ToString()),
                        Dia = Int32.Parse(row[5].ToString())
                    });
                }



                return grupos;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
