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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaEscolar.Gui.Secciones
{
    public partial class SeccionPersonal : UserControl
    {
        public SeccionPersonal()
        {
            InitializeComponent();

            bRegistrarPersonal.Click += (s, e) => RegistrarPersonal();

            LlenarTablaEmpleados();
        }

        private void RegistrarPersonal()
        {
            var dialogo = new Dialogos.DialogoRegistrarEmpleado();
            dialogo.ShowDialog();

            if (dialogo.DialogResult == true)
                LlenarTablaEmpleados();
        }

        private void LlenarTablaEmpleados()
        {
            var cuVistas = new CasoUsoListarVistaEmpleados();
            List<VistaEmpleados> vistas = cuVistas.Ejecutar();

            dgEmpleados.ItemsSource = vistas;
        }
    }
}
