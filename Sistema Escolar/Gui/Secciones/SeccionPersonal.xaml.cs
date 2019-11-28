using SistemaEscolar.Gui.Dialogos;
using SistemaEscolar.Gui.Vistas;
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
    public partial class SeccionPersonal : UserControl
    {
        private Dictionary<VistaEmpleados, VistaDetallesEmpleados> Empleados = new Dictionary<VistaEmpleados, VistaDetallesEmpleados>();

        public SeccionPersonal()
        {
            InitializeComponent();

            bEditar.Click += (s, e) => EditarPersonal();

            bRegistrarPersonal.Click += (s, e) => RegistrarPersonal();

            dgEmpleados.MouseLeftButtonUp += (s, e) => LlenarDatosEmpleados();

            LlenarTablaEmpleados();
        }

        private void EditarPersonal()
        {
            VistaEmpleados empleadoSeleccionado = dgEmpleados.SelectedItem as VistaEmpleados;

            if (empleadoSeleccionado == null)
                return;

            string nombres = empleadoSeleccionado.Nombre;
            string apellidoPaterno = empleadoSeleccionado.ApellidoP;
            string apellidoMaterno = empleadoSeleccionado.ApellidoM;

            var dialogo = new DialogoRegistrarEmpleado(TipoOperacion.Editar, nombres, apellidoPaterno, apellidoMaterno);
            dialogo.ShowDialog();
        }

        private void RegistrarPersonal()
        {
            var dialogo = new Dialogos.DialogoRegistrarEmpleado(TipoOperacion.Registrar, null, null, null);
            dialogo.ShowDialog();

            if (dialogo.DialogResult == true)
                LlenarTablaEmpleados();
        }

        private void LlenarDatosEmpleados()
        {
            var vistaEmpleado = dgEmpleados.SelectedItem as VistaEmpleados;

            if (vistaEmpleado == null)
                return;

            if (!Empleados.ContainsKey(vistaEmpleado))
                return;

            VistaDetallesEmpleados empleado = Empleados[vistaEmpleado];

            tbIdProfesor.Text = empleado.IdProfesor ?? empleado.Puesto;
            tbNombre.Text = $"Nombre(s): {empleado.Nombre}";
            tbApellidoPaterno.Text = $"Apellido Paterno: {empleado.ApellidoPaterno}";
            tbApellidoMaterno.Text = $"Apellido Materno: {empleado.ApellidoMaterno}";
            tbFechaNac.Text = $"Fecha de nacimiento: {DateTime.Parse(empleado.FechaNacimiento).ToShortDateString()}";
            tbCurp.Text = $"CURP: {empleado.Curp}";

            tbCorreo.Text = "correo@ejemplo.com";
            tbTelefono.Text = empleado.Telefono;
            tbDireccion.Text = empleado.Direccion;

            tbAsignaturas.Text = 13.ToString();
            tbTutorados.Text = 63.ToString();
            tbHorario.Text = "7:00am - 3:15pm";
        }

        private void LlenarTablaEmpleados()
        {
            var cuVistas = new CasoUsoListarVistaEmpleados();
            List<VistaEmpleados> vistas = cuVistas.Ejecutar();

            var cuVistasDetalles = new CasoUsoListarVistaDetallesEmpleados();
            List<VistaDetallesEmpleados> vistasDetalles = cuVistasDetalles.Ejecutar();

            for (int i = 0; i < vistas.Count; i++)
            {
                var vistaEmpleado = vistas[i];
                var vistaDetalles = vistasDetalles[i];

                Empleados[vistaEmpleado] = vistaDetalles;
            }

            dgEmpleados.ItemsSource = vistas;
        }
    }
}
