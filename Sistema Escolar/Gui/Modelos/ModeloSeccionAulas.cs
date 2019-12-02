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
            
        }
    }
}
