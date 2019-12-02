using SistemaEscolar.Entidades;
using SistemaEscolar.Negocios.Casos.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Util
{
    public class ConsultasGlobales
    {
        #region Carreras
        private static List<Carrera> carreras;

        public static List<Carrera> Carreras()
        {
            if (carreras == null)
                carreras = new CasoUsoListarCarreras().Ejecutar();

            return carreras;
        }

        public static void ActualizarCarreras()
        {
            List<Carrera> carrerasTemp = new CasoUsoListarCarreras().Ejecutar();

            if (carrerasTemp == null)
                return;

            carreras = new List<Carrera>();
            carreras.AddRange(carrerasTemp);
        }
        #endregion

        #region Especialidades
        private static List<Especialidad> especialidades;

        public static List<Especialidad> Especialidades()
        {
            if (especialidades == null)
                especialidades = new CasoUsoListarEspecialidades().Ejecutar();

            return especialidades;
        }

        public static void ActualizarEspecialidades()
        {
            List<Especialidad> especialidadesTemp = new CasoUsoListarEspecialidades().Ejecutar();

            if (especialidadesTemp == null)
                return;

            especialidades = new List<Especialidad>();
            especialidades.AddRange(especialidadesTemp);
        }
        #endregion

        #region Especialidades por carrera
        private static Dictionary<string, List<string>> especialidadesPorCarrera = new Dictionary<string, List<string>>();

        public static List<string> EspecialidadesPorCarreras(string carrera)
        {
            if (!especialidadesPorCarrera.ContainsKey(carrera))
                especialidadesPorCarrera[carrera] = new CasoUsoListarEspecialidadesPorCarrera().Ejecutar(carrera);

            return especialidadesPorCarrera[carrera];
        }

        internal static string ObtenerProfesor(string claveProfesor)
        {
            string nombre = "";
            profesores = Profesores();
            foreach (var profesor in profesores)
            {
                if (profesor.IdProfesor == claveProfesor)
                {
                    nombre = $"{profesor.Nombre} {profesor.ApellidoPaterno} {profesor.ApellidoPaterno}";
                    break;
                }
            }
            return nombre;
        }

        public static void ActualizarEspecialidadesPorCarrera(string carrera)
        {
            List<string> especialidadesPorCarreraTemp = new CasoUsoListarEspecialidadesPorCarrera().Ejecutar(carrera);

            if (especialidadesPorCarreraTemp == null)
                return;

            especialidadesPorCarrera[carrera] = especialidadesPorCarreraTemp;
        }
        #endregion

        #region Tutores
        private static List<Tutor> tutores;

        public static List<Tutor> Tutores()
        {
            if (tutores == null)
                tutores = new CasoUsoListarTutores().Ejecutar();

            return tutores;
        }

        public static void ActualizarTutores()
        {
            List<Tutor> tutoresTemp = new CasoUsoListarTutores().Ejecutar();

            if (tutoresTemp == null)
                return;

            tutores = new List<Tutor>();
            tutores.AddRange(tutoresTemp);
        }
        #endregion

        #region Coordinadores

        private static List<Coordinardor> coordinadores;

        public static List<Coordinardor> Coordinadores()
        {
            if (coordinadores == null)
                coordinadores = new CasoUsoListarCoordinadores().Ejecutar();

            return coordinadores;
        }

        #endregion

        #region Profesores
        // TODO Cambiar esta lista por un diccionario <String(Clave profesor), Profesor>
        private static List<Profesor> profesores;

        public static List<Profesor> Profesores()
        {
            if (profesores == null)
                profesores = new CasoUsoListarProfesores().Ejecutar();

            return profesores;
        }
        #endregion

        #region Materias
        private static List<Materia> materias;

        public static List<Materia> Materias()
        {
            if (materias == null)
                materias = new CasoUsoListarMaterias().Ejecutar();

            return materias;
        }
        #endregion

        #region Grupos
        //public static readonly SortedDictionary<String, Grupo> grupos = new SortedDictionary<String, Grupo>();
        //public static SortedDictionary<String, Grupo> Grupos()
        //{
        //    if (grupos == null)
        //        grupos = new CasoUsoListarGrupos().Ejecutar();

        //    return grupos;
        //}

        #endregion
    }
}
