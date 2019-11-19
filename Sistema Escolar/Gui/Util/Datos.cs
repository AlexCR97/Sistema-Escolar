﻿using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Util
{
    public class Datos
    {
        public static readonly SortedDictionary<string, int> EstadoCivil = new SortedDictionary<string, int>()
        {
            { "Soltero/a", 1 },
            { "Casado/a", 2 },
            { "Divorciado/a", 3 },
            { "Viudo/a", 4 },
        };

        public static readonly SortedDictionary<string, int> Meses = new SortedDictionary<string, int>()
        {
            { "Enero", 1 },
            { "Febrero", 2 },
            { "Marzo", 3 },
            { "Abril", 4 },
            { "Mayo", 5 },
            { "Junio", 6 },
            { "Julio", 7 },
            { "Agosto", 8 },
            { "Septiembre", 9 },
            { "Octubre", 10 },
            { "Noviembre", 11 },
            { "Diciembre", 12 },
        };

        public static readonly Dictionary<string, int> Dias = new Dictionary<string, int>()
        {
            { "Enero", 31 },
            { "Febrero", 28 },
            { "Marzo", 31 },
            { "Abril", 30 },
            { "Mayo", 31 },
            { "Junio", 30 },
            { "Julio", 31 },
            { "Agosto", 31 },
            { "Septiembre", 30 },
            { "Octubre", 31 },
            { "Noviembre", 30 },
            { "Diciembre", 31 },
        };

        public static readonly List<string> Estatus = new List<string>()
        {
            "Alta",
            "Baja",
            "Baja temporal",
            "Graduado",
        };

        public static readonly SortedDictionary<string, int> Miembros = new SortedDictionary<string, int>
        {
            ["Miembro"] = 1,
            ["Vocal2"] = 2,
            ["Vocal1"] = 3,
            ["Secretario"] = 4,
            ["Presidente"] = 5,
        };

        public static List<int> Anios()
        {
            var anios = new List<int>();

            for (int i = 2019; i >= 1900; i--)
                anios.Add(i);

            return anios;
        }

        public static string CorreoDeAlumno(VistaAlumno alumno)
        {
            string apellidoP = alumno.ApellidoP.ToLower();
            string apellidoM = alumno.ApellidoM.ToLower();
            string matricula = $"{alumno.Matricula.Substring(0, 2)}{alumno.Matricula.Substring(6, 3)}";

            return $"{apellidoP}.{apellidoM}.{matricula}@itsmante.edu.mx";
        }

        public static List<int> DiasDeMes(string mes)
        {
            var dias = new List<int>();

            if (!Dias.ContainsKey(mes))
                return dias;

            for (int i = 1; i <= Dias[mes]; i++)
                dias.Add(i);

            return dias;
        }
    }
}
