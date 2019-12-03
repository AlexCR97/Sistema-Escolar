using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorMateria : Presentador<Materia>
    {
        public override Materia Procesar(DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows[0];

                return new Materia()
                {
                    Codigo = row.Field<string>("codigo"),
                    Nombre = row.Field<string>("nombre"),
                    Creditos = row.Field<int>("creditos")
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
