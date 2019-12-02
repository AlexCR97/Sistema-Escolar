using SistemaEscolar.Entidades;
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

            CargarAulas();
        }

        private class GrupoComparer : IEqualityComparer<Grupo>
        {
            public bool Equals(Grupo x, Grupo y)
            {
                return x.Aula.Trim() == y.Aula.Trim();
            }

            public int GetHashCode(Grupo obj)
            {
                return base.GetHashCode();
            }
        }

        private void CargarAulas()
        {
            var cuListarGrupos = new CasoUsoListarGrupos();
            var grupos = cuListarGrupos.Ejecutar();

            grupos = grupos.Distinct(new GrupoComparer()).ToList();

            lvAulas.ItemsSource = grupos;

            //var vistasGrupo = new List<VistaGrupo>();

            //foreach (var grupo in grupos)
            //{

            //}
        }

        private void RegistrarAula()
        {
            var dialogo = new Dialogos.DialogoRegistrarAula();
            dialogo.Show();
        }
    }
}
