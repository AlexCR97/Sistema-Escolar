using SistemaEscolar.Gui.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Gui.Modelos
{
    public class ModeloSeccionCarreras
    {
        private List<VistaCarrera> carreras = new List<VistaCarrera>();
        public List<VistaCarrera> Carreras
        {
            get { return carreras; }
            set { carreras = value; }
        }

        public ModeloSeccionCarreras()
        {
            //carreras.Add(new Carrera()
            //{
            //    UrlImagen = "foo",
            //    Codigo = "ISC",
            //    Nombre = "Ingenieria en Sistemas Computacionales",
            //    Especialidad = "Administracion de Base de Datos",
            //    Coordinador = "Ing. Alejandro Castillo"
            //});

            carreras.Add(new VistaCarrera()
            {
                UrlImagen = "foo",
                Codigo = "IGE",
                Nombre = "Ingenieria en Gestion Empresarial",
                Especialidad = "No se :v",
                Coordinador = "Ing. Diana Gallegos"
            });

            carreras.Add(new VistaCarrera()
            {
                UrlImagen = "foo",
                Codigo = "IIAS",
                Nombre = "Ingenieria en Innovacion Agricola Sustentable",
                Especialidad = "Especialidad en Plantitas",
                Coordinador = "Ing. Pablo Ramirez"
            });

            carreras.Add(new VistaCarrera()
            {
                UrlImagen = "foo",
                Codigo = "II",
                Nombre = "Ingenieria Industrial",
                Especialidad = "No hace nada jajaja xd",
                Coordinador = "Lic. Don Nadie"
            });
        }
    }
}
