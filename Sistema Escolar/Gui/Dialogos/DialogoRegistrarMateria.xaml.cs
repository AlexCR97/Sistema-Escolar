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
    /// <summary>
    /// Interaction logic for DialogoRegistrarMateria.xaml
    /// </summary>
    public partial class DialogoRegistrarMateria : Window
    {
        public DialogoRegistrarMateria()
        {
            InitializeComponent();

            CargarCarreras();

            bRegistrar.Click += BRegistrar_Click;
        }

        private void CargarCarreras()
        {
            var carreras = Util.ConsultasGlobales.Carreras();

            cbCarreras.ItemsSource = carreras;
            cbCarreras.SelectedIndex = 0;
        }

        private void BRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos() == true)
            {
                RegistrarMateria();
            }
        }

        private void RegistrarMateria()
        {
            var codigoMateria = txtClaveMateria.Text;
            var nombreMateria = txtNombreMateria.Text;
            var carrera = cbCarreras.SelectedItem.ToString();
            var horasTeoricas = Int32.Parse(txtHorasTeoricas.Text);
            var horasPracticas = Int32.Parse(txtHorasPracticas.Text);
            var creditos = Int32.Parse(txtCreditos.Text);

            var cu = new CasoUsoRegistrarMateria();

            bool exito = cu.Ejecutar(codigoMateria, nombreMateria, horasTeoricas, horasPracticas, creditos, carrera);

            if (!exito)
            {
                MessageBox.Show("Error al registrar gupo");
                DialogResult = false;
                return;
            }

            DialogResult = true;
            MessageBox.Show("Exito al registrar grupo");
        }

        private bool ValidarCampos()
        {
            var codigoMateria = txtClaveMateria.Text;
            var nombreMateria = txtNombreMateria.Text;
            var carrera = cbCarreras.SelectedItem.ToString();
            var horasTeoricas = txtHorasTeoricas.Text;
            var horasPracticas = txtHorasPracticas.Text;
            var creditos = txtCreditos.Text;

            var validadores = new List<Validador<string>>()
            {
                new ValidadorStringNoVacio(codigoMateria),
                new ValidadorStringNoVacio(nombreMateria),
                new ValidadorStringNoVacio(horasTeoricas),
                new ValidadorNumeroString(horasTeoricas),
                new ValidadorStringNoVacio(horasPracticas),
                new ValidadorNumeroString(horasPracticas),
                new ValidadorStringNoVacio(creditos),
                new ValidadorNumeroString(creditos)
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
