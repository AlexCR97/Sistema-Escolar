using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas.Implementaciones
{
    public class ConsultaSeleccionarAdmin : Consulta
    {
        public ConsultaSeleccionarAdmin(params object[] args) : base(args) { }

        protected override Dictionary<string, object> DefinirParametros(params object[] args)
        {
            string matricula = args[0].ToString();
            string contrasena = args[1].ToString();

            var parametros = new Dictionary<string, object>();
            parametros["@matricula"] = matricula;
            parametros["@contrasena"] = contrasena;

            return parametros;
        }

        protected override string DefinirQuery()
        {
            return "select * from Administrador where matricula = @matricula and contrasena = @contrasena";
        }
    }
}
