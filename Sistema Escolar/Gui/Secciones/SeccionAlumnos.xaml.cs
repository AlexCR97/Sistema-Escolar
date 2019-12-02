using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Dialogos;
using SistemaEscolar.Gui.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Secciones
{
    public partial class SeccionAlumnos : UserControl
    {
        private Dictionary<VistaAlumno, Alumno> Alumnos = new Dictionary<VistaAlumno, Alumno>();
        private List<VistaAlumno> ListaVistasAlumnos;
        private List<Alumno> ListaAlumnos;

        public SeccionAlumnos()
        {
            InitializeComponent();

            bEditarAlumno.Click += (s, e) => EditarAlumno();

            bRegistrarAlumno.Click += (s, e) => RegistrarAlumno();

            dgAlumnos.MouseLeftButtonUp += (s, e) => LlenarDatosAlumno();

            cbFiltroCarrera.SelectionChanged += (s, e) => FiltrarPorCarrera();
            cbFiltroEstatus.SelectionChanged += (s, e) => FiltrarPorEstatus();
            cbFiltroTutor.SelectionChanged += (s, e) => FiltrarPorTutor();
            tbFiltroMatricula.TextChanged += (s, e) => FiltarPorMatricula();
            tbFiltroApellidoP.TextChanged += (s, e) => FiltrarPorApellidoP();
            tbFiltroApellidoM.TextChanged += (s, e) => FiltrarPorApellidoM();

            LlenarTablaAlumnos();
            LlenarFiltros();
        }
        private void FiltarPorMatricula()
        {
            string matricula = tbFiltroMatricula.Text;

            if (String.IsNullOrWhiteSpace(matricula))
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos;
            }
            else
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos.FindAll(alumno => alumno.Matricula.Contains(matricula));
            }
        }

        private void FiltrarPorApellidoP()
        {
            string apellidoP = tbFiltroApellidoP.Text;

            if (String.IsNullOrWhiteSpace(apellidoP))
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos;
            }
            else
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos.FindAll(alumno => alumno.ApellidoP.Contains(apellidoP));
            }
        }

        private void FiltrarPorApellidoM()
        {
            string apellidoM = tbFiltroApellidoM.Text;

            if (String.IsNullOrWhiteSpace(apellidoM))
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos;
            }
            else
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos.FindAll(alumno => alumno.ApellidoM.Contains(apellidoM));
            }
        }

        private void FiltrarPorTutor()
        {
            string tutorSeleccionado = cbFiltroTutor.SelectedItem.ToString();

            if (tutorSeleccionado == "Todos  ")
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos;
            }
            else
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos.FindAll(alumno => alumno.Tutor == tutorSeleccionado);
            }
        }

        private void FiltrarPorEstatus()
        {

        }

        private void FiltrarPorCarrera()
        {
            string carreraSeleccionada = cbFiltroCarrera.SelectedItem.ToString();

            if (carreraSeleccionada == "Todos")
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos;
            }
            else
            {
                dgAlumnos.ItemsSource = ListaVistasAlumnos.FindAll(alumno => alumno.Carrera == carreraSeleccionada);
            }
        }

        private void EditarAlumno()
        {
            string matricula = (dgAlumnos.SelectedItem as VistaAlumno).Matricula;

            var validador = new ValidadorMatriculaAlumno(matricula);

            if (!validador.Validar())
            {
                MessageBox.Show(validador.UltimoError());
                return;
            }

            var dialogo = new DialogoRegistrarAlumno(TipoOperacion.Editar, matricula);

            try
            {
                dialogo.ShowDialog();
                LlenarTablaAlumnos();
            }
            catch {
                LlenarTablaAlumnos();
            }
        }

        private void RegistrarAlumno()
        {
            var dialogo = new DialogoRegistrarAlumno(TipoOperacion.Registrar, null);
            dialogo.ShowDialog();

            if (dialogo.DialogResult == true)
                LlenarTablaAlumnos();
        }

        private void LlenarTablaAlumnos()
        {
            var cuVistas = new CasoUsoListarVistaAlumnos();
            ListaVistasAlumnos = cuVistas.Ejecutar();

            var cuAlumnos = new CasoUsoListarAlumnos();
            ListaAlumnos = cuAlumnos.Ejecutar();

            for (int i = 0; i < ListaVistasAlumnos.Count; i++)
            {
                var vista = ListaVistasAlumnos[i];
                var alumno = ListaAlumnos[i];

                this.Alumnos[vista] = alumno;
            }

            dgAlumnos.ItemsSource = ListaVistasAlumnos;
        }

        private void LlenarDatosAlumno()
        {
            var vistaAlumno = dgAlumnos.SelectedItem as VistaAlumno;

            if (vistaAlumno == null)
                return;

            if (!Alumnos.ContainsKey(vistaAlumno))
                return;

            Alumno alumno = Alumnos[vistaAlumno];

            tbMatriculaCarrera.Text = $"{vistaAlumno.Matricula} | {vistaAlumno.Carrera}";
            tbNombre.Text = $"Nombre: {vistaAlumno.Nombre} {vistaAlumno.ApellidoP} {vistaAlumno.ApellidoM}";
            tbApellidoP.Text = $"Apellido paterno: {vistaAlumno.ApellidoP}";
            tbApellidoM.Text = $"Apellido materno: {vistaAlumno.ApellidoM}";
            tbFechaNac.Text = $"Fecha de nacimiento: {DateTime.Parse(alumno.FechaNacimiento).ToShortDateString()}";
            tbCurp.Text = $"CURP: {alumno.Curp}";

            tbTelefono.Text = alumno.Telefono;
            //tbDireccion.Text = alumno.Direccion;
            tbCorreo.Text = Util.Datos.CorreoDeAlumno(vistaAlumno);
        }

        private void LlenarFiltros()
        {
            var carreras = Util.ConsultasGlobales.Carreras();
            carreras.Insert(0, new Carrera() { Nombre = "Todos" });
            cbFiltroCarrera.ItemsSource = carreras;
            cbFiltroCarrera.SelectedIndex = 0;

            var estatus = Util.Datos.Estatus;
            estatus.Insert(0, "Todos");
            cbFiltroEstatus.ItemsSource = estatus;
            cbFiltroEstatus.SelectedIndex = 0;

            var tutores = Util.ConsultasGlobales.Tutores();
            tutores.Insert(0, new Tutor() { Nombre = "Todos", ApellidoPaterno = "", ApellidoMaterno = "" });
            cbFiltroTutor.ItemsSource = tutores;
            cbFiltroTutor.SelectedIndex = 0;
        }
    }
}
