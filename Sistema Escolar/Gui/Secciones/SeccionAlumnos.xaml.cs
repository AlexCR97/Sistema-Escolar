using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Dialogos;
using SistemaEscolar.Negocios.Casos.Implementaciones;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Secciones
{
    /// <summary>
    /// Interaction logic for SeccionAlumnos.xaml
    /// </summary>
    public partial class SeccionAlumnos : UserControl
    {
        public SeccionAlumnos()
        {
            InitializeComponent();

            bRegistrarAlumno.Click += (s, e) =>
            {
                RegistrarAlumno();
            };

            LlenarAlumnos();
        }

        private void RegistrarAlumno()
        {
            var dialogo = new DialogoRegistrarAlumno();
            dialogo.Show();
        }

        private void LlenarAlumnos()
        {
            var cu = new CasoUsoListarAlumnos();
            List<Alumno> alumnos = cu.Ejecutar();

            dgAlumnos.ItemsSource = alumnos;
        }
    }
}
