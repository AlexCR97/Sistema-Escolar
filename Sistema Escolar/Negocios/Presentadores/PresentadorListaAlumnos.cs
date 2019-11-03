using SistemaEscolar.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Negocios.Presentadores
{
    public class PresentadorListaAlumnos : Presentador<List<Alumno>>
    {
        public override List<Alumno> Procesar(DataTable dataTable)
        {
            try
            {
                var alumnos = new List<Alumno>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    alumnos.Add(new Alumno()
                    {
                        IdPersona = Convert.ToInt32(row[0]),
                        ApellidoPaterno = row[1].ToString(),
                        ApellidoMaterno = row[2].ToString(),
                        Nombres = row[3].ToString(),
                        FechaNacimiento = row[4].ToString(),
                        Sexo = Convert.ToBoolean(row[5]),
                        Curp = row[6].ToString(),
                        Telefono = row[7].ToString(),
                        IdCalle = Convert.ToInt32(row[8]),
                        NumeroExterior = Convert.ToInt32(row[9]),
                        //NumeroInterior = Convert.ToInt32(row[10]),
                        CodigoPostal = Convert.ToInt32(row[11]),
                        EstadoCivil = Convert.ToInt32(row[12]),
                        Discapacidad = Convert.ToInt32(row[13]),
                        Matricula = row[14].ToString(),
                        IdCarrera = Convert.ToInt32(row[16]),
                        Tutor = row[17].ToString(),
                        IdEspecialidad = Convert.ToInt32(row[18].ToString()),
                        Estatus = Convert.ToInt32(row[19].ToString()),
                    });
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
