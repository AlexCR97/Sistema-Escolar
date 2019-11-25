using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Util;
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
    public partial class DialogoRegistrarEmpleado : Window
    {
        public DialogoRegistrarEmpleado()
        {
            InitializeComponent();

            LlenarAcademias();
            LlenarDireccion();
            LlenarFecha();
            LlenarEstadosCiviles();
            LlenarMiembros();
            LlenarPuestos();

            bRegistrar.Click += (s, e) =>
            {
                RegistrarPersona();
                RegistrarEmpleado();
                RegistrarProfesor();
                Close();
            };
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

        private void RegistrarPersona()
        {
            string apellidoP = tbApellidoPaterno.Text;
            string apellidoM = tbApellidoMaterno.Text;
            string nombres = tbNombre.Text;
            string fechaNac = $"{Convert.ToInt32(cbFechaAnio.SelectedItem)}-{Util.Datos.Meses[cbFechaMes.SelectedItem.ToString()]}-{Convert.ToInt32(cbFechaDia.SelectedItem)}";
            bool sexo = rbSexoHombre.IsChecked == true;
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

        public void RegistrarEmpleado()
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
                return;
            }

            MessageBox.Show("Exito al registrar empleado");
        }

        public void RegistrarProfesor()
        {
            string idProfesor = tbIdProfesor.Text;
            int idAcademia = -1;
            int tipoMiembro = -1;

            // encontrar id de la academia
            string selectedAcademia = cbAcademias.SelectedItem.ToString();
            Util.ConsultasGlobales.Academias.ForEach(academia =>
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
                return;
            }

            MessageBox.Show("Exito al registrar profesor");
            DialogResult = true;
        }
    }
}
