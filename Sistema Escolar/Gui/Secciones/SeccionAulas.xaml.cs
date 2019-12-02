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
        List<Grupo> grupos;
        public SeccionAulas()
        {
            InitializeComponent();

            bRegistrarAula.Click += (s, e) =>
            {
                RegistrarAula();
            };

            CargarAulas();

            lvAulas.MouseLeftButtonUp += (s, e) =>
            {
                string aula = lvAulas.SelectedItem.ToString().Trim();
                CargarGrupos(aula);
            };
        }

        private void CargarGrupos(String aula)
        {
            // Lunes a Sabado
            var listasDias = new Dictionary<int, List<VistaGrupo>>();
            listasDias[1] = new List<VistaGrupo>();
            listasDias[2] = new List<VistaGrupo>();
            listasDias[3] = new List<VistaGrupo>();
            listasDias[4] = new List<VistaGrupo>();
            listasDias[5] = new List<VistaGrupo>();
            listasDias[6] = new List<VistaGrupo>();

            foreach (var grupo in grupos)
            {
                if (grupo.Aula.Trim() == aula)
                {
                    var vista = new VistaGrupo()
                    {
                        NombreProfesor = Util.ConsultasGlobales.ObtenerProfesor(grupo.ClaveProfesor),
                        NombreMateria = grupo.NombreMateria,
                        Hora = Util.Datos.ClasesHoras[grupo.Hora]
                    };

                    listasDias[grupo.Dia].Add(vista);
                }
            }

            lvLunes.ItemsSource = listasDias[1];
            lvMartes.ItemsSource = listasDias[2];
            lvMiercoles.ItemsSource = listasDias[3];
            lvJueves.ItemsSource = listasDias[4];
            lvViernes.ItemsSource = listasDias[5];
            lvSabado.ItemsSource = listasDias[6];
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
            grupos = cuListarGrupos.Ejecutar();

            var gruposDistintos = grupos.Distinct(new GrupoComparer()).ToList();

            lvAulas.ItemsSource = gruposDistintos;
        }

        private void RegistrarAula()
        {
            var dialogo = new Dialogos.DialogoRegistrarAula();
            dialogo.Show();
        }
    }
}
