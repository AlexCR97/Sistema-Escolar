using SistemaEscolar.Gui.Dialogos;
using SistemaEscolar.Gui.Vistas;
using SistemaEscolar.Gui.Util;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using SistemaEscolar.Entidades;

namespace SistemaEscolar.Gui.Secciones
{
    public partial class SeccionCarreras : UserControl
    {
        public SeccionCarreras()
        {
            InitializeComponent();

            LlenarFiltros();
            LlenarListaCarreras();

            cbCarreras.SelectionChanged += (s, e) => FiltrarPorCarrera();

            lvCarreras.MouseLeftButtonUp += (s, e) => LlenarDatosCarrera();

            bRegistrarCarrera.Click += (s, e) => RegistrarCarrera();
        }

        private void FiltrarPorCarrera()
        {
            string carreraSeleccionada = cbCarreras.SelectedItem.ToString();

            if (carreraSeleccionada == "Todos")
            {
                List<VistaCarrerasEspecialidades> carreras = ConsultasGlobales.VistasCarrerasEspecialidades;
                lvCarreras.ItemsSource = carreras;
            }
            else
            {
                List<VistaCarrerasEspecialidades> carreras = ConsultasGlobales.VistasCarrerasEspecialidades.FindAll(carrera => carrera.Carrera == carreraSeleccionada);
                lvCarreras.ItemsSource = carreras;
            }
        }

        private void RegistrarCarrera()
        {
            var dialogo = new DialogoRegistrarCarrera(TipoOperacion.Registrar);
            dialogo.ShowDialog();

            lvCarreras.ItemsSource = null;

            ConsultasGlobales.ActualizarVistasCarrerasEspecialidades();
            LlenarListaCarreras();
        }

        private void LlenarFiltros()
        {
            List<Carrera> carreras = new CasoUsoListarCarreras().Ejecutar();
            carreras.Insert(0, new Carrera() { Nombre = "Todos" });
            cbCarreras.ItemsSource = carreras;
            cbCarreras.SelectedIndex = 0;
        }

        private void LlenarDatosCarrera()
        {
            var carrera = lvCarreras.SelectedItem as VistaCarrerasEspecialidades;

            if (carrera == null)
                return;

            // contar materias con la carrera seleccionada
            int cantidadMaterias = ConsultasGlobales.VistasMateriasConCarreras
                .FindAll(materia => materia.Carrera == carrera.Carrera)
                .Count;

            // contar alumnos con la carrera seleccionada
            int cantidadAlumnos = ConsultasGlobales.VistasDetallesAlumnos
                .FindAll(alumno => alumno.Carrera == carrera.Carrera)
                .Count;

            tbCarrera.Text = carrera.Carrera;
            tbEspecialidad.Text = carrera.Especialidad;

            tbCantidadMaterias.Text = cantidadMaterias.ToString();
            tbCantidadAlumnos.Text = cantidadAlumnos.ToString();
        }

        private void LlenarListaCarreras()
        {
            List<VistaCarrerasEspecialidades> carreras = ConsultasGlobales.VistasCarrerasEspecialidades;
            lvCarreras.ItemsSource = carreras;
        }
    }
}
