using SistemaEscolar.Gui.Dialogos;
using SistemaEscolar.Gui.Vistas;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SistemaEscolar.Gui.Secciones
{
    /// <summary>
    /// Interaction logic for SeccionCarreras.xaml
    /// </summary>
    public partial class SeccionCarreras : UserControl
    {
        public SeccionCarreras()
        {
            InitializeComponent();

            LlenarListaCarreras();

            bRegistrarCarrera.Click += (s, e) =>
            {
                RegistrarCarrera();
            };
        }

        private void RegistrarCarrera()
        {
            var dialogo = new DialogoRegistrarCarrera();
            dialogo.Show();
        }

        private void LlenarDatosCarrera()
        {

        }

        private void LlenarListaCarreras()
        {
            var cuCarreras = new CasoUsoListarCarreras();
            //var carreras = cuCarreras.Ejecutar();

            var cuVistasCarreras = new CasoUsoListarVistaCarreras();
            var vistasCarreras = cuVistasCarreras.Ejecutar();

            var carreras = new List<Carrera>();
            carreras.Add(new Carrera()
            {
                UrlImagen = "foo",
                Codigo = "ISC",
                Nombre = "Ingenieria en Sistemas Computacionales",
                Especialidad = "Administracion de Base de Datos",
                Coordinador = "Ing. Alejandro Castillo"
            });

            lvCarreras.ItemsSource = carreras;
        }
    }
}