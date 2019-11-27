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

namespace SistemaEscolar.Reportes
{
    /// <summary>
    /// Interaction logic for ReporteViewer.xaml
    /// </summary>
    public partial class ReporteViewer : Window
    {
        public ReporteViewer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        public void cargarReporte(object report)
        {

            viewer.ViewerCore.ReportSource = report;
        }
    }
}
