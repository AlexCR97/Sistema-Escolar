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
        private Dictionary<VistaAlumno, Alumno> alumnos = new Dictionary<VistaAlumno, Alumno>();

        public SeccionAlumnos()
        {
            InitializeComponent();

            bEditarAlumno.Click += (s, e) => EditarAlumno();

            bRegistrarAlumno.Click += (s, e) => RegistrarAlumno();

            dgAlumnos.MouseLeftButtonUp += (s, e) => LlenarDatosAlumno();

            LlenarTablaAlumnos();
            LlenarFiltros();
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
            dialogo.ShowDialog();
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
            List<VistaAlumno> vistas = cuVistas.Ejecutar();

            var cuAlumnos = new CasoUsoListarAlumnos();
            List<Alumno> alumnos = cuAlumnos.Ejecutar();

            for (int i = 0; i < vistas.Count; i++)
            {
                var vista = vistas[i];
                var alumno = alumnos[i];

                this.alumnos[vista] = alumno;
            }

            dgAlumnos.ItemsSource = vistas;
        }

        private void LlenarDatosAlumno()
        {
            var vistaAlumno = dgAlumnos.SelectedItem as VistaAlumno;

            if (vistaAlumno == null)
                return;

            if (!alumnos.ContainsKey(vistaAlumno))
                return;

            var alumno = alumnos[vistaAlumno];

            tbMatriculaCarrera.Text = $"{vistaAlumno.Matricula} | {vistaAlumno.Carrera}";
            tbNombre.Text = $"Nombre: {vistaAlumno.Nombre} {vistaAlumno.ApellidoP} {vistaAlumno.ApellidoM}";
            tbFechaNac.Text = $"{alumno.FechaNacimiento}";
            tbCurp.Text = $"{alumno.Curp}";

            tbTelefono.Text = alumno.Telefono;
            //tbDireccion.Text = alumno.Direccion;
            tbCorreo.Text = Util.Datos.CorreoDeAlumno(vistaAlumno);
        }

        private void LlenarFiltros()
        {
            var carreras = Util.ConsultasGlobales.Carreras();
            cbCarrera.ItemsSource = carreras;
            cbCarrera.SelectedIndex = 0;

            var estatus = Util.Datos.Estatus;
            cbEstatus.ItemsSource = estatus;
            cbEstatus.SelectedIndex = 0;

            var tutores = Util.ConsultasGlobales.Tutores();
            cbTutor.ItemsSource = tutores;
            cbTutor.SelectedIndex = 0;
        }
    }
}
