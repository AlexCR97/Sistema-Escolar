using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorAdministrador : Presentador<Administrador>
    {
        public override Administrador Procesar(DataTable dataTable)
        {
            try
            {
                DataRow row = dataTable.Rows[0];

                return new Administrador()
                {
                    Matricula = row.Field<string>("matricula"),
                    Contrasena = row.Field<string>("contrasena"),
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
