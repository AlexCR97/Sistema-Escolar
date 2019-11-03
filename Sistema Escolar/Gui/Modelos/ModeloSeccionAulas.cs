using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Modelos
{
    public class ModeloSeccionAulas
    {
        private List<Aula> aulas = new List<Aula>();
        public List<Aula> Aulas
        {
            get { return aulas; }
            set { aulas = value; }
        }

        private List<Asignatura> asignaturas = new List<Asignatura>();
        public List<Asignatura> Asignaturas
        {
            get { return asignaturas; }
            set { asignaturas = value; }
        }

        public ModeloSeccionAulas()
        {
            for (int i = 1; i <= 20; i++)
            {
                Aulas.Add(new Aula()
                {
                    Edificio = i,
                    Planta = i,
                    Salon = i,
                    Capacidad = 40,
                });
            }

            for (int i = 1; i <= 20; i++)
            {
                Asignaturas.Add(new Asignatura()
                {
                    Materia = i.ToString(),
                    Profesor = i.ToString(),
                    Horario = i.ToString(),
                });
            }
        }
    }
}
