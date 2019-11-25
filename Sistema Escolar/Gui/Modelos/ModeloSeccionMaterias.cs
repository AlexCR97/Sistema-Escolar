using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Modelos
{
    public class ModeloSeccionMaterias
    {
        private List<VistaMateria> materias = new List<VistaMateria>();
        public List<VistaMateria> Materias
        {
            get { return materias; }
            set { materias = value; }
        }

        public ModeloSeccionMaterias()
        {
            for (int i = 1; i <= 20; i++)
            {
                Materias.Add(new VistaMateria()
                {
                    Codigo = i.ToString(),
                    Nombre = i.ToString(),
                    Creditos = i,
                });
            }
        }
    }
}
