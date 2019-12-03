using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Util;
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
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoRegistrarCarrera.xaml
    /// </summary>
    public partial class DialogoRegistrarCarrera : Window
    {
        private TipoOperacion TipoOperacion;

        public DialogoRegistrarCarrera(TipoOperacion tipoOperacion)
        {
            InitializeComponent();

            TipoOperacion = tipoOperacion;

            switch (TipoOperacion)
            {
                case TipoOperacion.Editar:
                {
                    bRegistrar.Content = "Editar";
                    break;
                }

                case TipoOperacion.Registrar:
                {
                    break;
                }
            }

            CargarListaCoordinadores();

            bRegistrar.Click += (s, e) =>
            {
                switch (TipoOperacion)
                {
                    case TipoOperacion.Registrar:
                    {
                        RegistrarCarrera();
                        break;
                    }

                    case TipoOperacion.Editar:
                    {
                        break;
                    }
                }
            };
        }

        private void RegistrarCarrera()
        {
            string carrera = tbCarrera.Text;
            VistaDetallesEmpleados empleadoSeleccionado = cbCoordinador.SelectedItem as VistaDetallesEmpleados;

            string nombreCoordinador = empleadoSeleccionado.Nombre;
            string apellidoPaternoCoordinador = empleadoSeleccionado.ApellidoPaterno;
            string apellidoMaternoCoordinador = empleadoSeleccionado.ApellidoMaterno;

            var casoUso = new CasoUsoRegistrarCarrera();

            bool exito = casoUso.Ejecutar(carrera, nombreCoordinador, apellidoPaternoCoordinador, apellidoMaternoCoordinador);

            if (!exito)
            {
                MessageBox.Show("Error al registrar carrera!");
                return;
            }

            MessageBox.Show("Exito registrando la carrera!");

            var dialogo = new DialogoRegistrarEspecialidad(TipoOperacion.Registrar, carrera);
            dialogo.ShowDialog();

            Close();
        }

        private void CargarListaCoordinadores()
        {
            List<VistaDetallesEmpleados> empleados = ConsultasGlobales.VistasDetallesEmpleados;
            cbCoordinador.ItemsSource = empleados;
            cbCoordinador.SelectedIndex = 0;
        }
    }
}
