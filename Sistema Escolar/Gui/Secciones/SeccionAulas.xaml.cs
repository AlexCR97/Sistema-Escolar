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
    /// Interaction logic for SeccionAulas.xaml
    /// </summary>
    public partial class SeccionAulas : UserControl
    {
        public SeccionAulas()
        {
            InitializeComponent();

            bRegistrarAula.Click += (s, e) =>
            {
                RegistrarAula();
            };
        }

        private void RegistrarAula()
        {
            var dialogo = new Dialogos.DialogoRegistrarAula();
            dialogo.Show();
        }
    }
}
