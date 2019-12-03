using SistemaEscolar.Entidades;
using SistemaEscolar.Gui.Util;
using SistemaEscolar.Negocios.Casos;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using SistemaEscolar.Negocios.Validadores;
using SistemaEscolar.Negocios.Validadores.Propiedades;
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

namespace SistemaEscolar.Gui.Dialogos
{
    public partial class DialogoRegistrarEspecialidad : Window
    {
        private TipoOperacion TipoOperacion;

        public DialogoRegistrarEspecialidad(TipoOperacion tipoOperacion, string carrera)
        {
            InitializeComponent();

            LlenarDatos();

            cbCarrera.SelectedItem = carrera;

            TipoOperacion = tipoOperacion;

            switch (TipoOperacion)
            {
                case TipoOperacion.Registrar:
                {
                    RegistrarEspecialidad();
                    break;
                }

                case TipoOperacion.Editar:
                {
                    break;
                }
            }

            bRegistrar.Click += (s, e) => RegistrarEspecialidad();
        }

        private void LlenarDatos()
        {
            List<Carrera> carreras = ConsultasGlobales.Carreras();
            cbCarrera.ItemsSource = carreras;
            cbCarrera.SelectedIndex = 0;
        }

        private void RegistrarEspecialidad()
        {
            string especialidad = tbEspecialidad.Text;
            string carrera = cbCarrera.SelectedItem.ToString();

            var validadores = new List<Validador<string>>()
            {
                new ValidadorStringNoVacio(especialidad),
                new ValidadorStringNoVacio(carrera),
            };

            foreach (Validador<string> validador in validadores)
            {
                if (!validador.Validar())
                {
                    MessageBox.Show(validador.UltimoError());
                    return;
                }
            }

            var cu = new CasoUsoInsertarEspacialidad();

            bool exito = cu.Ejecutar(especialidad, carrera);

            if (!exito)
            {
                MessageBox.Show("Error al reigstrar especialidad");
            }
            else
            {
                MessageBox.Show("Exito al reigstrar especialidad");
            }
            Close();
        }
    }
}
