using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Util;
using SistemaEscolar.Gui.Vistas;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using SistemaEscolar.Negocios.Validadores;
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

namespace SistemaEscolar.Gui.Dialogos
{
    public partial class DialogoRegistrarAlumno : Window
    {
        private int cantidadAlumnosRegistrados;

        public TipoOperacion TipoOperacion { get; set; }

        public DialogoRegistrarAlumno(TipoOperacion tipoOperacion, string matricula)
        {
            InitializeComponent();

            TipoOperacion = tipoOperacion;

            // llenar datos
            if (TipoOperacion == TipoOperacion.Editar)
            {
                if (matricula != null)
                {
                    LlenarDatosDetallesAlumno(matricula);
                }
            }

            cantidadAlumnosRegistrados = ObtenerCantidadAlumnosRegistrados();

            tbNombre.TextChanged += (s, e) => { GenerarCurp(); };
            tbApellidoMaterno.TextChanged += (s, e) => { GenerarCurp(); GenerarCorreo(); };
            tbApellidoPaterno.TextChanged += (s, e) => { GenerarCurp(); GenerarCorreo(); };

            cbFechaAnio.SelectionChanged += (s, e) => GenerarCurp();
            cbFechaDia.SelectionChanged += (s, e) => GenerarCurp();
            cbFechaMes.SelectionChanged += (s, e) =>
            {
                cbFechaDia.ItemsSource = Util.Datos.DiasDeMes(cbFechaMes.SelectedItem.ToString());
                GenerarCurp();
            };

            cbCarrera.SelectionChanged += (s, e) =>
            {
                string carrera = cbCarrera.SelectedItem.ToString();
                LlenarEspecialidadesPorCarrera(carrera);
            };

            bRegistrar.Click += (s, e) =>
            {
                switch (TipoOperacion)
                {
                    case TipoOperacion.Registrar:
                    {
                        if (!ValidarDatosPersona())
                            return;

                        if (!ValidarDatosAlumno())
                            return;

                        if (!RegistrarPersona())
                            return;

                        if (!RegistrarAlumno())
                            return;

                        break;
                    }

                    case TipoOperacion.Editar:
                    {
                        if (!ValidarDatosPersona())
                            return;

                        if (!ValidarDatosAlumno())
                            return;



                        break;
                    }
                }

                Close();
            };

            LlenarFecha();
            LlenarCarreras();
            LlenarEspecialidadesPorCarrera(cbCarrera.SelectedItem.ToString());
            LlenarEstadosCiviles();
            LlenarDireccion();
            LlenarMatricula();
            LlenarTutores();
        }

        private void GenerarCorreo()
        {
            string apellidoP = tbApellidoPaterno.Text;

            if (String.IsNullOrWhiteSpace(apellidoP))
                return;

            string apellidoM = tbApellidoMaterno.Text;

            if (String.IsNullOrWhiteSpace(apellidoM))
                return;

            var hoy = DateTime.Now;

            string matricula =  $"{apellidoP.ToLower()}.{apellidoM.ToLower()}.{hoy.Year.ToString().Substring(2, 2)}{cantidadAlumnosRegistrados.ToString().PadLeft(3, '0')}@itsmante.edu.mx";

            tbCorreoInstitucional.Text = matricula;
        }

        private void GenerarCurp()
        {
            return;

            string apellidoP = tbApellidoPaterno.Text;

            if (String.IsNullOrWhiteSpace(apellidoP))
                return;

            string apellidoM = tbApellidoMaterno.Text;

            if (String.IsNullOrWhiteSpace(apellidoM))
                return;

            string nombre = tbNombre.Text;

            if (String.IsNullOrWhiteSpace(nombre))
                return;

            string fechaDia = cbFechaDia.SelectedItem.ToString();

            if (String.IsNullOrWhiteSpace(fechaDia))
                return;

            string fechaMes = cbFechaMes.SelectedItem.ToString();

            if (String.IsNullOrWhiteSpace(fechaMes))
                return;

            string fechaAnio = cbFechaAnio.SelectedItem.ToString();

            if (String.IsNullOrWhiteSpace(fechaAnio))
                return;

            string[] nombres = nombre.Split(' ');

            char primeraLetraApellidoP = apellidoP.ToUpper()[0];
            char primeraLetraSegundoNombre = nombres[1].ToUpper()[0];
            char primeraLetraApellidoM = apellidoM.ToUpper()[0];
            char primeraLetraPrimerNombre = nombres[0].ToUpper()[0];
            string anio = fechaAnio.Substring(2, 2);
            string mes = Util.Datos.Meses[fechaMes].ToString();
            string dia = fechaDia;

            // CARP971113HTSSMB03
            string curp = $"{primeraLetraApellidoP}{primeraLetraSegundoNombre}{primeraLetraApellidoM}{primeraLetraPrimerNombre}{anio}{mes}{dia}HTSSMB";

            tbCurp.Text = curp;
        }

        private string GenerarMatricula()
        {
            var hoy = DateTime.Now;

            // 1601F0225

            return $"{hoy.Year.ToString().Substring(2, 2)}01F{cantidadAlumnosRegistrados.ToString().PadLeft(4, '0')}";
        }

        private void LlenarDatosDetallesAlumno(string matricula)
        {
            var cu = new CasoUsoSeleccionarVistaDetallesAlumno();
            VistaDetallesAlumno vista = cu.Ejecutar(matricula);

            if (vista == null)
            {
                MessageBox.Show("Error fatal. Codigo ALVT02");
                return;
            }

            tbNombre.Text = vista.Nombre;
            tbApellidoPaterno.Text = vista.ApellidoPaterno;
            tbApellidoMaterno.Text = vista.ApellidoMaterno;

            string fechaCorta = DateTime.Parse(vista.FechaNacimiento).ToShortDateString();
            string[] tokensFecha = fechaCorta.Split('/');

            cbFechaDia.SelectedItem = int.Parse(tokensFecha[1]);
            cbFechaMes.SelectedIndex = int.Parse(tokensFecha[0]);
            cbFechaAnio.SelectedItem = int.Parse(tokensFecha[2]);

            rbSexoHombre.IsChecked = vista.Sexo;
            tbCurp.Text = vista.Curp;
            tbTelefono.Text = vista.Telefono;
            cbEstadoCivil.SelectedIndex = vista.EstadoCivil;
            tbCodigoPostal.Text = vista.CodigoPostal.ToString();
            cbCalle.SelectedItem = vista.Calle;
            tbNumeroExterior.Text = vista.NumeroExterior.ToString();
            tbNumeroInterior.Text = vista.NumeroInterior.ToString();
            cbColonia.SelectedItem = vista.Localidad;
            cbCiudad.SelectedItem = vista.Municipio;
            cbEstado.SelectedItem = vista.Estado;
            tbMatricula.Text = vista.Matricula;
            tbCorreoInstitucional.Text = "correo";
            cbEspecialidad.SelectedItem = vista.Esepcialidad;
            tbGrupo.Text = "";
            cbTutor.SelectedItem = $"{vista.NombreTutor} {vista.ApellidoPaternoTutor} {vista.ApellidoMaternoTutor}";
        }

        private void LlenarFecha()
        {
            cbFechaMes.ItemsSource = Util.Datos.Meses.Keys.ToList<string>();
            cbFechaMes.SelectedIndex = 0;

            cbFechaDia.ItemsSource = Util.Datos.DiasDeMes(cbFechaMes.SelectedItem.ToString());
            cbFechaDia.SelectedIndex = 0;

            cbFechaAnio.ItemsSource = Util.Datos.Anios();
            cbFechaAnio.SelectedIndex = 0;
        }

        private void LlenarCarreras()
        {
            List<Carrera> carreras = Util.ConsultasGlobales.Carreras();
            var nombresCarreras = new List<string>();

            carreras.ForEach(carrera => nombresCarreras.Add(carrera.Nombre));

            cbCarrera.ItemsSource = nombresCarreras;
            cbCarrera.SelectedIndex = 0;
        }

        private void LlenarEspecialidadesPorCarrera(string carrera)
        {
            List<string> especialidades = Util.ConsultasGlobales.EspecialidadesPorCarreras(carrera);

            cbEspecialidad.ItemsSource = especialidades;
            cbEspecialidad.SelectedIndex = 0;
        }

        private void LlenarEstadosCiviles()
        {
            cbEstadoCivil.ItemsSource = Util.Datos.EstadoCivil.Keys;
            cbEstadoCivil.SelectedIndex = 0;
        }

        private void LlenarDireccion()
        {
            var ubicaciones = ConsultasGlobales.VistasUbicaciones;

            var calles = new List<string>();
            var colonias = new List<string>();
            var ciudades = new List<string>();
            var estados = new List<string>();
            
            ubicaciones.ForEach(ubicacion =>
            {
                calles.Add(ubicacion.NombreCalle);
                colonias.Add(ubicacion.NombreLocalidad);
                ciudades.Add(ubicacion.NombreMunicipio);
                estados.Add(ubicacion.NombreEstado);
            });

            cbCalle.ItemsSource = calles.Distinct().ToList();
            cbColonia.ItemsSource = colonias.Distinct().ToList();
            cbCiudad.ItemsSource = ciudades.Distinct().ToList();
            cbEstado.ItemsSource = estados.Distinct().ToList();

            cbCalle.SelectedIndex = 0;
            cbColonia.SelectedIndex = 0;
            cbCiudad.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
        }

        private void LlenarMatricula()
        {
            string matricula = GenerarMatricula();
            tbMatricula.Text = matricula;
        }

        private void LlenarTutores()
        {
            List<Tutor> tutores = Util.ConsultasGlobales.Tutores();
            var nombresTutores = new List<string>();

            tutores.ForEach(tutor => nombresTutores.Add($"{tutor.Nombre} {tutor.ApellidoPaterno} {tutor.ApellidoMaterno}"));

            cbTutor.ItemsSource = nombresTutores;
            cbTutor.SelectedIndex = 0;
        }

        private int ObtenerCantidadAlumnosRegistrados()
        {
            var cu = new CasoUsoSeleccionarCantidadAlumnosRegistrados();
            return cu.Ejecutar();
        }

        private bool RegistrarPersona()
        {
            string apellidoP = tbApellidoPaterno.Text;
            string apellidoM = tbApellidoMaterno.Text;
            string nombres = tbNombre.Text;
            string fechaNac = $"{Convert.ToInt32(cbFechaAnio.SelectedItem)}-{Util.Datos.Meses[cbFechaMes.SelectedItem.ToString()]}-{Convert.ToInt32(cbFechaDia.SelectedItem)}";
            bool sexo = rbSexoHombre.IsChecked == true;
            string curp = tbCurp.Text;
            string telefono = tbTelefono.Text;
            string calle = cbCalle.SelectedItem.ToString();
            string numExt = tbNumeroExterior.Text;
            string numInt = tbNumeroInterior.Text;
            string codigoPostal = tbCodigoPostal.Text;
            int edoCivil = 1;
            int discapacidad = 1;

            var cu = new CasoUsoAltaPersona();

            bool exito = cu.Ejecutar(
                apellidoP,
                apellidoM,
                nombres,
                fechaNac,
                sexo,
                curp,
                telefono,
                calle,
                int.Parse(numExt),
                int.Parse(numInt),
                int.Parse(codigoPostal),
                edoCivil,
                discapacidad
            );

            if (!exito)
            {
                MessageBox.Show("Error al registrar persona");
                return false;
            }

            return true;
        }

        private bool RegistrarAlumno()
        {
            var tutorSeleccionado = cbTutor.SelectedItem.ToString().Split(' ');

            string matricula = tbMatricula.Text;
            string carrera = cbCarrera.SelectedItem.ToString();
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
                DialogResult = false;
                return false;
            }

            MessageBox.Show("Exito al registrar alumno");
            DialogResult = true;

            return true;
        }

        private bool ValidarDatosPersona()
        {
            string apellidoP = tbApellidoPaterno.Text;
            string apellidoM = tbApellidoMaterno.Text;
            string nombres = tbNombre.Text;
            string fechaNac = $"{Convert.ToInt32(cbFechaAnio.SelectedItem)}-{Util.Datos.Meses[cbFechaMes.SelectedItem.ToString()]}-{Convert.ToInt32(cbFechaDia.SelectedItem)}";
            bool sexo = rbSexoHombre.IsChecked == true;
            string curp = tbCurp.Text;
            string telefono = tbTelefono.Text;
            string calle = cbCalle.SelectedItem.ToString();
            string numExt = tbNumeroExterior.Text;
            string numInt = tbNumeroInterior.Text;
            string codigoPostal = tbCodigoPostal.Text;

            var validadores = new List<Validador<string>>()
            {
                new ValidadorStringNoVacio(apellidoP),
                new ValidadorStringNoVacio(apellidoM),
                new ValidadorStringNoVacio(nombres),
                new ValidadorFecha(fechaNac),
                new ValidadorCurp(curp),
                new ValidadorTelefono(telefono),
                new ValidadorStringNoVacio(calle),
                new ValidadorNumeroString(numExt),
                new ValidadorNumeroString(numInt),
                new ValidadorNumeroString(codigoPostal),
            };

            foreach (Validador<string> validador in validadores)
            {
                if (!validador.Validar())
                {
                    MessageBox.Show(validador.UltimoError(), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool ValidarDatosAlumno()
        {
            var tutorSeleccionado = cbTutor.SelectedItem.ToString().Split(' ');

            string matricula = tbMatricula.Text;
            string carrera = cbCarrera.SelectedItem.ToString();
            string tutorApellidoP = tutorSeleccionado[1];
            string tutorApellidoM = tutorSeleccionado[2];
            string tutorNombre = tutorSeleccionado[0];
            string especialidad = cbEspecialidad.SelectedItem.ToString();

            var validadores = new List<Validador<string>>()
            {
                new ValidadorMatriculaAlumno(matricula),
                new ValidadorStringNoVacio(carrera),
                new ValidadorStringNoVacio(tutorApellidoP),
                new ValidadorStringNoVacio(tutorApellidoM),
                new ValidadorStringNoVacio(tutorNombre),
                new ValidadorStringNoVacio(especialidad),
            };

            foreach (Validador<string> validador in validadores)
            {
                if (!validador.Validar())
                {
                    MessageBox.Show(validador.UltimoError(), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
