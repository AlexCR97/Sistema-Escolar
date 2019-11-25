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
        private List<VistaAula> aulas = new List<VistaAula>();
        public List<VistaAula> Aulas
        {
            get { return aulas; }
            set { aulas = value; }
        }

        private List<VistaAsignatura> asignaturas = new List<VistaAsignatura>();
        public List<VistaAsignatura> Asignaturas
        {
            get { return asignaturas; }
            set { asignaturas = value; }
        }

        public ModeloSeccionAulas()
        {
            for (int i = 1; i <= 20; i++)
            {
                Aulas.Add(new VistaAula()
                {
                    Edificio = i,
                    Planta = i,
                    Salon = i,
                    Capacidad = 40,
                });
            }

            for (int i = 1; i <= 20; i++)
            {
                Asignaturas.Add(new VistaAsignatura()
                {
                    Materia = i.ToString(),
                    Profesor = i.ToString(),
                    Horario = i.ToString(),
                });
            }
        }
    }
}
