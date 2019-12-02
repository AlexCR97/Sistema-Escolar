using SistemaEscolar.Entidades;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SistemaEscolar.Gui.Dialogos
{
    /// <summary>
    /// Interaction logic for DialogoRegistrarAula.xaml
    /// </summary>
    public partial class DialogoRegistrarAula : Window
    {
        private List<Materia> materias;
        private List<Profesor> profesores;

        public DialogoRegistrarAula()
        {
            InitializeComponent();

            chkNoEsSalon.Checked += ChkNoEsSalon_Checked;
            chkNoEsSalon.Unchecked += ChkNoEsSalon_Unchecked;

            chkGrupoConocido.Checked += ChkGrupoConocido_Checked;
            chkGrupoConocido.Unchecked += ChkGrupoConocido_Unchecked;

            cbGrupo.IsEnabled = false;

            bRegistrar.Click += BRegistrar_Click;

            cbAulas.IsEnabled = false;

            LlenarAulas();
            LlenarProfesores();
            LlenarMaterias();
            LlenarDias();
            LlenarHoras();
            LlenarGrupos();
        }

        private void ChkGrupoConocido_Unchecked(object sender, RoutedEventArgs e)
        {
            cbGrupo.IsEnabled = false;
            txtCodigoGrupo.IsEnabled = true;
        }

        private void ChkGrupoConocido_Checked(object sender, RoutedEventArgs e)
        {
            cbGrupo.IsEnabled = true;
            txtCodigoGrupo.IsEnabled = false;
        }

        private class GrupoComparer : IEqualityComparer<Grupo>
        {
            public bool Equals(Grupo x, Grupo y)
            {
                return x.ClaveGrupo.Trim() == y.ClaveGrupo.Trim();
            }

            public int GetHashCode(Grupo obj)
            {
                return base.GetHashCode();
            }
        }

        private void LlenarGrupos()
        {
            // TESTALV
            var cuListarGrupos = new CasoUsoListarGrupos();
            var grupos = cuListarGrupos.Ejecutar();

            var gruposDistintos = grupos.Distinct(new GrupoComparer()).ToList();

            var listaClaves = new List<String>();
            gruposDistintos.ForEach(v => listaClaves.Add(v.ClaveGrupo));

            cbGrupo.ItemsSource = listaClaves;
        }

        private void BRegistrar_Click(object sender, RoutedEventArgs e)
        {
            var claveGrupo = txtCodigoGrupo.Text;
            var claveMateria = materias[cbMateria.SelectedIndex].Codigo;
            string aula;
            if (chkNoEsSalon.IsChecked == true)
            {
                aula = cbAulas.SelectedItem.ToString();
            }
            else
            {
                aula = txtEdificio.Text + txtPlanta.Text + ((txtSalon.Text.Length < 2) ? "0" + txtSalon.Text : txtSalon.Text);
            }
            var claveProfesor = profesores[cbProfesor.SelectedIndex].IdProfesor;
            var hora = Util.Datos.HorasClases[cbHora.SelectedItem.ToString()];
            var dia = Util.Datos.DiasSemana[cbDia.SelectedItem.ToString()]; ;

            var cu = new CasoUsoRegistrarGrupo();

            bool exito = cu.Ejecutar(claveGrupo, claveMateria, aula, claveProfesor, hora, dia);

            if (!exito)
            {
                MessageBox.Show("Error al registrar gupo");
                return;
            }

            MessageBox.Show("Exito al registrar grupo");
        }

        private void LlenarHoras()
        {
            cbHora.ItemsSource = Util.Datos.HorasClases.Keys;
            cbHora.SelectedIndex = 0;
        }

        private void LlenarDias()
        {
            cbDia.ItemsSource = Util.Datos.DiasSemana.Keys;
            cbDia.SelectedIndex = 0;
        }

        private void LlenarMaterias()
        {
            this.materias = Util.ConsultasGlobales.Materias();

            var listaMaterias = new List<String>();

            foreach (var materia in materias)
            {
                listaMaterias.Add(materia.Nombre);
            }

            cbMateria.ItemsSource = listaMaterias;
            cbMateria.SelectedIndex = 0;
        }

        private void LlenarProfesores()
        {
            this.profesores = Util.ConsultasGlobales.Profesores();

            var listaProfesores = new List<String>();

            foreach (var profesor in profesores)
            {
                listaProfesores.Add($"{profesor.Nombre} {profesor.ApellidoPaterno} {profesor.ApellidoMaterno}");
            }

            cbProfesor.ItemsSource = listaProfesores;
            cbProfesor.SelectedIndex = 0;
        }

        private void LlenarAulas()
        {
            var aulas = new List<String>()
            {
                "CC1",
                "CC2",
                "Lab. Quim.",
                "Tal. Ind.",
                "Campo"
            };
            cbAulas.ItemsSource = aulas;
            cbAulas.SelectedIndex = 0;
        }

        private void ChkNoEsSalon_Unchecked(object sender, RoutedEventArgs e)
        {
            txtEdificio.IsEnabled = true;
            txtPlanta.IsEnabled = true;
            txtSalon.IsEnabled = true;

            cbAulas.IsEnabled = false;
        }

        private void ChkNoEsSalon_Checked(object sender, RoutedEventArgs e)
        {
            txtEdificio.IsEnabled = false;
            txtPlanta.IsEnabled = false;
            txtSalon.IsEnabled = false;

            cbAulas.IsEnabled = true;
        }
    }
}
