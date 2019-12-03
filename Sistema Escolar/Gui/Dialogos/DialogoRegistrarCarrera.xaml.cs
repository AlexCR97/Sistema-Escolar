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
    /// Interaction logic for DialogoRegistrarCarrera.xaml
    /// </summary>
    public partial class DialogoRegistrarCarrera : Window
    {
        public DialogoRegistrarCarrera()
        {
            InitializeComponent();

            CargarListaCoordinadores();

            bRegistrar.Click += (s, e) => { RegistrarUsuario(); };
        }

        private void RegistrarUsuario()
        {
            var carrera = tbCarrera.Text;
            var coordinador = cbCoordinador.SelectedItem.ToString().Split(' ');

            var nombreCoordinador = coordinador[0].ToString();
            var apellidoPaternoCoordinador = coordinador[1].ToString();
            var apellidoMaternoCoordinador = coordinador[2].ToString();

            var casoUso = new CasoUsoRegistrarCarrera();

            bool exito = casoUso.Ejecutar(carrera, nombreCoordinador, apellidoPaternoCoordinador, apellidoMaternoCoordinador);

            if (!exito)
            {
                MessageBox.Show("Error al registrar carrera!");
                return;
            }

            MessageBox.Show("Exito registrando la carrera!");
        }

        private void CargarListaCoordinadores()
        {
            List<Coordinardor> coordinadores = new CasoUsoListarCoordinadores().Ejecutar();
            cbCoordinador.ItemsSource = coordinadores;
        }
    }
}
