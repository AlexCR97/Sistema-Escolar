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
    public partial class DialogoRegistrarEmpleado : Window
    {
        public TipoOperacion TipoOperacion { get; set; }

        public DialogoRegistrarEmpleado(TipoOperacion tipoOperacion, string nombres, string apellidoP, string apellidoM)
        {
            InitializeComponent();

            TipoOperacion = tipoOperacion;

            // llenar datos

            if (TipoOperacion == TipoOperacion.Editar)
            {
                if (nombres != null && apellidoP != null && apellidoM != null)
                {
                    LlenarDatosEmpleado(nombres, apellidoP, apellidoM);
                }
            }

            LlenarAcademias();
            LlenarDireccion();
            LlenarFecha();
            LlenarEstadosCiviles();
            LlenarMiembros();
            LlenarPuestos();

            bRegistrar.Click += (s, e) =>
            {
                if (!ValidarDatosPersona())
                    return;

                if (!ValidarDatosEmpleado())
                    return;

                if (!ValidarDatosProfesor())
                    return;

                if (!RegistrarPersona())
                    return;

                if (!RegistrarEmpleado())
                    return;

                if (!RegistrarProfesor())
                    return;

                Close();
            };
        }

        private void LlenarDatosEmpleado(string nombres, string apellidoP, string apellidoM)
        {
            var cu = new CasoUsoSeleccionarVistaDetallesEmpleados2();
            VistaDetallesEmpleados2 vista = cu.Ejecutar(nombres, apellidoP, apellidoM);

            if (vista == null)
            {
                MessageBox.Show("Error fatal. Codigo ALVT02");
                return;
            }

            tbNombre.Text = vista.Nombres;
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
            tbCorreo.Text = "correo@live.com";
            cbPuestos.SelectedItem = vista.Puesto;
            tbIdProfesor.Text = vista.IdProfesor;
            cbTipoMiembro.SelectedIndex = vista.TipoMiembro;
            cbAcademias.SelectedItem = vista.Academia;

            bRegistrar.Content = "Editar";
        }

        private void LlenarAcademias()
        {
            List<Academia> academias = Util.ConsultasGlobales.Academias;
            var nombresAcademias = new List<string>();

            academias.ForEach(academia => nombresAcademias.Add(academia.Nombre));

            cbAcademias.ItemsSource = nombresAcademias;
            cbAcademias.SelectedIndex = 0;
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

        private void LlenarFecha()
        {
            cbFechaMes.ItemsSource = Util.Datos.Meses.Keys.ToList<string>();
            cbFechaMes.SelectedIndex = 0;

            cbFechaDia.ItemsSource = Util.Datos.DiasDeMes(cbFechaMes.SelectedItem.ToString());
            cbFechaDia.SelectedIndex = 0;

            cbFechaAnio.ItemsSource = Util.Datos.Anios();
            cbFechaAnio.SelectedIndex = 0;
        }

        private void LlenarEstadosCiviles()
        {
            cbEstadoCivil.ItemsSource = Util.Datos.EstadoCivil.Keys;
            cbEstadoCivil.SelectedIndex = 0;
        }

        private void LlenarMiembros()
        {
            cbTipoMiembro.ItemsSource = Util.Datos.Miembros.Keys.ToList<string>();
            cbTipoMiembro.SelectedIndex = 0;
        }

        private void LlenarPuestos()
        {
            List<Empleos> empleos = Util.ConsultasGlobales.Empleos();
            var puestos = new List<string>();

            empleos.ForEach(empleo => puestos.Add(empleo.Puesto));

            cbPuestos.ItemsSource = puestos;
            cbPuestos.SelectedIndex = 0;
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
            string calle = "Cipres";
            string numExt = tbNumeroExterior.Text;
            string numInt = tbNumeroInterior.Text;
            string codigoPostal = tbCodigoPostal.Text;
            int edoCivil = 1;
            int discapacidad = 1;

            var cu = new CasoUsoAltaPersona();

            bool exito = cu.Ejecutar(apellidoP, apellidoM, nombres, fechaNac, sexo, curp, telefono, calle, int.Parse(numExt), int.Parse(numInt), int.Parse(codigoPostal), edoCivil, discapacidad);

            if (!exito)
            {
                MessageBox.Show("Error al registrar persona");
                return false;
            }

            MessageBox.Show("Exito al registrar persona");

            return true;
        }

        public bool RegistrarEmpleado()
        {
            string puestoSeleccionado = cbPuestos.SelectedItem.ToString();
            int idEmplo = -1;
            
            List<Empleos> empleos = Util.ConsultasGlobales.Empleos();
            empleos.ForEach(empleo =>
            {
                if (empleo.Puesto == puestoSeleccionado)
                {
                    idEmplo = empleo.Id;
                    return;
                }
            });

            var cu = new CasoUsoAltaEmpleados();

            bool exito = cu.Ejecutar(idEmplo);

            if (!exito)
            {
                MessageBox.Show("Error al registrar empleado");
                return false; ;
            }

            MessageBox.Show("Exito al registrar empleado");

            return true;
        }

        public bool RegistrarProfesor()
        {
            string idProfesor = tbIdProfesor.Text;
            int idAcademia = -1;
            int tipoMiembro = -1;

            // encontrar id de la academia
            string selectedAcademia = cbAcademias.SelectedItem.ToString();
            ConsultasGlobales.Academias.ForEach(academia =>
            {
                if (academia.Nombre == selectedAcademia)
                {
                    idAcademia = academia.Id;
                    return;
                }
            });

            // encontrar id del tipo de miembro
            string selectedTipoMiembro = cbTipoMiembro.SelectedItem.ToString();
            tipoMiembro = Util.Datos.Miembros[selectedTipoMiembro];

            var cu = new CasoUsoAltaProfesor();

            bool exito = cu.Ejecutar(idProfesor, idAcademia, tipoMiembro);

            if (!exito)
            {
                MessageBox.Show("Error al registrar profesor");
                DialogResult = false;
                return false;
            }

            MessageBox.Show("Exito al registrar profesor");
            DialogResult = true;

            return true;
        }

        public bool ValidarDatosPersona()
        {
            string apellidoP = tbApellidoPaterno.Text;
            string apellidoM = tbApellidoMaterno.Text;
            string nombres = tbNombre.Text;
            string fechaNac = $"{Convert.ToInt32(cbFechaAnio.SelectedItem)}-{Util.Datos.Meses[cbFechaMes.SelectedItem.ToString()]}-{Convert.ToInt32(cbFechaDia.SelectedItem)}";
            bool sexo = rbSexoHombre.IsChecked == true;
            string curp = tbCurp.Text;
            string telefono = tbTelefono.Text;
            string calle = "Cipres";
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

        public bool ValidarDatosEmpleado()
        {
            string puestoSeleccionado = cbPuestos.SelectedItem.ToString();

            var validador = new ValidadorStringNoVacio(puestoSeleccionado);

            if (!validador.Validar())
            {
                MessageBox.Show(validador.UltimoError(), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        public bool ValidarDatosProfesor()
        {
            string idProfesor = tbIdProfesor.Text;

            var validador = new ValidadorStringNoVacio(idProfesor);

            if (!validador.Validar())
            {
                MessageBox.Show(validador.UltimoError(), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
