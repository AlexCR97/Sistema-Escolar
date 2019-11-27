using SistemaEscolar.Entidades;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using SistemaEscolar.Negocios.Validadores.Propiedades;
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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class VentanaLogin : Window
    {
        public VentanaLogin()
        {
            InitializeComponent();

            bAdmin.MouseLeftButtonUp += (s, e) => tbIniciaSesionComo.Text = "Inicia sesión como 'Administrador'";
            bProfesor.MouseLeftButtonUp += (s, e) => tbIniciaSesionComo.Text = "Inicia sesión como 'Profesor'";
            bAlumno.MouseLeftButtonUp += (s, e) => tbIniciaSesionComo.Text = "Inicia sesión como 'Alumno'";

            bIngresar.Click += (sender, e) =>
            {
                //ValidarAdmin();
                IniciarSesion();
            };
        }

        private void ValidarAdmin()
        {
            string matricula = tbMatricula.Text;
            string contrasena = tbContrasena.Text;

            var cu = new CasoUsoSeleccionarAdmin();
            Administrador admin = cu.Ejecutar(matricula, contrasena);

            if (admin == null)
            {
                MessageBox.Show("Las credenciales son incorrectas!", "Error de inicio de sesion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            IniciarSesion();
        }

        private void IniciarSesion()
        {
            var ventanaAdmin = new VentanaAdmin();
            ventanaAdmin.Show();

            this.Close();
        }
    }
}
