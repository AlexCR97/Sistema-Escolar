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
    /// <summary>
    /// Interaction logic for SeccionarPersonal.xaml
    /// </summary>
    public partial class SeccionPersonal : UserControl
    {
        public SeccionPersonal()
        {
            InitializeComponent();

            bRegistrarPersonal.Click += (s, e) =>
            {
                RegistrarPersonal();
            };
        }

        private void RegistrarPersonal()
        {
            var dialogo = new Dialogos.DialogoRegistrarEmpleado();
            dialogo.Show();
        }
    }
}
