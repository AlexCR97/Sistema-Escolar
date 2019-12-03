using SistemaEscolar.Entidades;
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
        private List<VistaEmpleados> ListaVistasEmpleados;
        private List<VistaDetallesEmpleados> ListaVistasDetallesEmpleados;

        public SeccionPersonal()
        {
            InitializeComponent();

            bEditar.Click += (s, e) => EditarPersonal();

            bRegistrarPersonal.Click += (s, e) => RegistrarPersonal();

            cbFiltroTipoEmpleado.SelectionChanged += (s, e) => FiltrarPorTipoEmpleado();
            tbFiltroNombre.TextChanged += (s, e) => FiltrarPorNombre();
            tbFiltroApellidoP.TextChanged += (s, e) => FiltrarPorApellidoP();
            tbFiltroApellidoM.TextChanged += (s, e) => FiltrarPorApellidoM();

            dgEmpleados.MouseLeftButtonUp += (s, e) => LlenarDatosEmpleados();

            LlenarFiltros();
            LlenarTablaEmpleados();
        }

        private void FiltrarPorNombre()
        {
            string nombre = tbFiltroNombre.Text;

            if (String.IsNullOrWhiteSpace(nombre))
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados;
            }
            else
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados.FindAll(empleado => empleado.Nombre.Contains(nombre));
            }
        }

        private void FiltrarPorApellidoP()
        {
            string apellidoP = tbFiltroApellidoP.Text;

            if (String.IsNullOrWhiteSpace(apellidoP))
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados;
            }
            else
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados.FindAll(empleado => empleado.ApellidoP.Contains(apellidoP));
            }
        }

        private void FiltrarPorApellidoM()
        {
            string apellidoM = tbFiltroApellidoM.Text;

            if (String.IsNullOrWhiteSpace(apellidoM))
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados;
            }
            else
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados.FindAll(empleado => empleado.ApellidoM.Contains(apellidoM));
            }
        }

        private void FiltrarPorTipoEmpleado()
        {
            string tipoEmpleado = cbFiltroTipoEmpleado.SelectedItem.ToString();

            if (tipoEmpleado == "Todos")
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados;
            }
            else
            {
                dgEmpleados.ItemsSource = ListaVistasEmpleados.FindAll(empleado => empleado.Puesto == tipoEmpleado);
            }
        }

        private void EditarPersonal()
        {
            var empleadoSeleccionado = dgEmpleados.SelectedItem as VistaEmpleados;

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

            tbCorreo.Text = Util.Datos.CorreoDeProfesor(empleado.Nombre.ToLower(), empleado.ApellidoPaterno.ToLower());
            tbTelefono.Text = empleado.Telefono;
            tbDireccion.Text = empleado.Direccion;

            tbAsignaturas.Text = 13.ToString();
            tbTutorados.Text = 63.ToString();
            tbHorario.Text = "7:00am - 3:15pm";
        }

        private void LlenarFiltros()
        {
            List<Empleos> empleos = Util.ConsultasGlobales.Empleos();
            empleos.Insert(0, new Empleos() { Puesto = "Todos" });

            cbFiltroTipoEmpleado.ItemsSource = empleos;
            cbFiltroTipoEmpleado.SelectedIndex = 0;
        }

        private void LlenarTablaEmpleados()
        {
            var cuVistas = new CasoUsoListarVistaEmpleados();
            ListaVistasEmpleados = cuVistas.Ejecutar();

            var cuVistasDetalles = new CasoUsoListarVistaDetallesEmpleados();
            ListaVistasDetallesEmpleados = cuVistasDetalles.Ejecutar();

            for (int i = 0; i < ListaVistasEmpleados.Count; i++)
            {
                var vistaEmpleado = ListaVistasEmpleados[i];
                var vistaDetalles = ListaVistasDetallesEmpleados[i];

                Empleados[vistaEmpleado] = vistaDetalles;
            }

            dgEmpleados.ItemsSource = ListaVistasEmpleados;
        }
    }
}
