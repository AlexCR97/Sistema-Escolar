using SistemaEscolar.Entidades;
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
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoRegistrarAlumno.xaml
    /// </summary>
    public partial class DialogoRegistrarAlumno : Window
    {
        public DialogoRegistrarAlumno()
        {
            InitializeComponent();

            bRegistrar.Click += (s, e) =>
            {
                RegistrarPersona();
                RegistrarAlumno();
                Close();
            };

            LlenarCarreras();
            LlenarEspecialidades();
            LlenarTutores();
        }

        private void RegistrarPersona()
        {
            string apellidoP = tbApellidoPaterno.Text;
            string apellidoM = tbApellidoMaterno.Text;
            string nombres = tbNombre.Text;
            string fechaNac = "1997-11-13";
            bool sexo = false;
            string curp = tbCurp.Text;
            string telefono = tbTelefono.Text;
            string calle = "Cipres";
            int numExt = Convert.ToInt32(tbNumeroExterior.Text);
            int numInt = Convert.ToInt32(tbNumeroInterior.Text);
            int codigoPostal = Convert.ToInt32(tbCodigoPostal.Text);
            int edoCivil = 1;
            int discapacidad = 1;

            var cu = new CasoUsoAltaPersona();

            bool exito = cu.Ejecutar(apellidoP, apellidoM, nombres, fechaNac, sexo, curp, telefono, calle, numExt, numInt, codigoPostal, edoCivil, discapacidad);

            if (!exito)
            {
                MessageBox.Show("Error al registrar persona");
                return;
            }

            MessageBox.Show("Exito al registrar persona");
        }

        private void RegistrarAlumno()
        {
            var tutorSeleccionado = cbTutor.SelectedItem.ToString().Split(' ');

            string matricula = tbMatricula.Text;
            string carrera = cbCarrera.SelectedItem.ToString();
            //string tutorApellidoP = "Muñoz";
            //string tutorApellidoM = "Meza";
            //string tutorNombre = "Cristian";
            string tutorApellidoP = tutorSeleccionado[1];
            string tutorApellidoM = tutorSeleccionado[2];
            string tutorNombre = tutorSeleccionado[0];
            string especialidad = cbEspecialidad.SelectedItem.ToString();
            int estatus = 1;

            var cu = new CasoUsoRegistrarAlumno();

            bool exito = cu.Ejecutar(matricula, carrera, tutorApellidoP, tutorApellidoM, tutorNombre, especialidad, estatus);

            if (!exito)
            {
                MessageBox.Show("Error al registrar alumno");
                return;
            }

            MessageBox.Show("Exito al registrar alumno");
        }

        private void LlenarCarreras()
        {
            var cu = new CasoUsoListarCarreras();
            List<Carrera> carreras = cu.Ejecutar();
            var nombresCarreras = new List<string>();

            carreras.ForEach(carrera => nombresCarreras.Add(carrera.Nombre));

            cbCarrera.ItemsSource = nombresCarreras;
            cbCarrera.SelectedIndex = 0;
        }

        private void LlenarEspecialidades()
        {
            var cu = new CasoUsoListarEspecialidades();
            List<Especialidad> especialidades = cu.Ejecutar();
            var nombreEspecialidades = new List<string>();

            especialidades.ForEach(especialidad => nombreEspecialidades.Add(especialidad.Nombre));

            cbEspecialidad.ItemsSource = nombreEspecialidades;
            cbEspecialidad.SelectedIndex = 0;
        }

        private void LlenarTutores()
        {
            var cu = new CasoUsoListarTutores();
            List<Tutor> tutores = cu.Ejecutar();
            var nombresTutores = new List<string>();

            tutores.ForEach(tutor => nombresTutores.Add($"{tutor.Nombre} {tutor.ApellidoPaterno} {tutor.ApellidoMaterno}"));

            cbTutor.ItemsSource = nombresTutores;
            cbTutor.SelectedIndex = 0;
        }
    }
}
