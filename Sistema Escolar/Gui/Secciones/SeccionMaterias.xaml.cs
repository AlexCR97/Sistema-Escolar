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

            cbCarreras.SelectionChanged += CbCarreras_SelectionChanged;

            CargarCarreras();
            CargarMaterias();

            lvMaterias.MouseLeftButtonUp += LvMaterias_MouseLeftButtonUp;
        }

        private void CbCarreras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCarreras.SelectedItem.ToString().Trim().Equals("Todos"))
            {
                CargarMaterias();
                return;
            }

            var listamaterias = Util.ConsultasGlobales.MateriasCarreras();

            var materias = listamaterias.Values.ToList().Where(x => x.Carrera.Equals(cbCarreras.SelectedItem.ToString()));

            lvMaterias.ItemsSource = materias;
        }

        private void CargarCarreras()
        {
            var carreras = Util.ConsultasGlobales.Carreras();

            if (!carreras[0].Nombre.Trim().Equals("Todos"))
            {
                carreras.Insert(0, new Carrera()
                {
                    Nombre = "Todos"
                });
            }

            cbCarreras.ItemsSource = carreras;
            cbCarreras.SelectedIndex = 0;
        }

        private void LvMaterias_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var materia = lvMaterias.SelectedItem as Materia;

            if (materia == null)
            {
                return;
            }

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

        private void bNuevaMateria_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = new Dialogos.DialogoRegistrarMateria().ShowDialog();
            if (dialogResult == true)
            {
                MessageBox.Show("Materia registrada exitosamente!.");
            }
            else
            {
                MessageBox.Show("Materia fallo al registrarse.");
            }
        }
    }
}
