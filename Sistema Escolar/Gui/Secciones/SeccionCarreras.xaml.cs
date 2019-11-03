using SistemaEscolar.Gui.Dialogos;
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
    /// Interaction logic for SeccionCarreras.xaml
    /// </summary>
    public partial class SeccionCarreras : UserControl
    {
        public SeccionCarreras()
        {
            InitializeComponent();

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
    }
}
