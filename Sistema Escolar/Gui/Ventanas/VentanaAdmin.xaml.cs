using SistemaEscolar.Gui.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Ventanas
{
    public partial class VentanaAdmin : Window
    {
        private List<string> nombresSeccion = new List<string>();
        private Dictionary<string, object> secciones = new Dictionary<string, object>();

        public VentanaAdmin()
        {
            InitializeComponent();

            nombresSeccion.Add("Carreras");
            nombresSeccion.Add("Personal");
            nombresSeccion.Add("Alumnos");
            nombresSeccion.Add("Aulas");
            nombresSeccion.Add("Horarios");
            nombresSeccion.Add("Materias");

            secciones["Carreras"] = new ModeloSeccionCarreras();
            secciones["Personal"] = new ModeloSeccionPersonal();
            secciones["Alumnos"] = new ModeloSeccionAlumnos();
            secciones["Aulas"] = new ModeloSeccionAulas();
            secciones["Horarios"] = new ModeloSeccionHorarios();
            secciones["Materias"] = new ModeloSeccionMaterias();

            lvSecciones.ItemsSource = nombresSeccion;
            lvSecciones.MouseLeftButtonUp += (s, e) =>
            {
                string seccionSeleccionada = lvSecciones.SelectedItem.ToString();
                MostrarSeccion(seccionSeleccionada);
            };

            MostrarSeccion("Carreras");
        }

        private void MostrarSeccion(string seccion)
        {
            if (!secciones.ContainsKey(seccion))
                return;

            tbNombreSeccion.Text = seccion;
            DataContext = secciones[seccion];
        }
    }
}
