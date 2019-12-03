using SistemaEscolar.Entidades;
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
    /// Interaction logic for SeccionMaterias.xaml
    /// </summary>
    public partial class SeccionMaterias : UserControl
    {
        public SeccionMaterias()
        {
            InitializeComponent();

            CargarMaterias();

            lvMaterias.MouseLeftButtonUp += LvMaterias_MouseLeftButtonUp;
        }

        private void LvMaterias_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var materia = lvMaterias.SelectedItem as Materia;

            tbCodigoMateria.Text = $"{materia.Codigo}";
            tbNombreMateria.Text = materia.Nombre;

            tbCreditos.Text = $"Creditos: {materia.Creditos.ToString()}";
            tbHorasPracticas.Text = $"Horas practicas: {materia.HorasPracticas.ToString()}";
            tbHorasTeoricas.Text = $"Horas teoricas: {materia.HorasTeoricas.ToString()}";
            
        }

        private void CargarMaterias()
        {
            var listamaterias = Util.ConsultasGlobales.Materias();

            lvMaterias.ItemsSource = listamaterias;
        }
    }
}
