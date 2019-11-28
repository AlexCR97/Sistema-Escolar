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
    /// Interaction logic for SeccionReportes.xaml
    /// </summary>
    public partial class SeccionReportes : UserControl
    {
        public SeccionReportes()
        {
            InitializeComponent();

            bDetallesActividades.Click += (s, e) => AbrirReporte(new Reportes.ReporteDetalleActividades());
            bDetallesAlumnos.Click += (s, e) => AbrirReporte(new Reportes.ReporteDetalleAlumnos());
            bDetallesEmpleados.Click += (s, e) => AbrirReporte(new Reportes.ReporteDetalleEmpleados());
            bInformacionContacto.Click += (s, e) => AbrirReporte(new Reportes.ReporteInformacionContacto());
        }

        public void AbrirReporte(object reporte)
        {
            var viewer = new Reportes.ReportViewer();
            viewer.LoadReport(reporte);
            viewer.ShowDialog();
        }
    }
}
