using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Modelos
{
    public class ModeloSeccionHorarios
    {
        private List<VistaHorario> horarios = new List<VistaHorario>();
        public List<VistaHorario> Horarios
        {
            get { return horarios; }
            set { horarios = value; }
        }

        public ModeloSeccionHorarios()
        {
            for (int i = 0; i < 20; i++)
                Horarios.Add(new VistaHorario()
                {
                    Hora = i.ToString(),
                });
        }
    }
}
