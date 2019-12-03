using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos
{
    public sealed class Conexion
    {
        private string servidor;
        private string baseDatos;
        private string usuario;
        private string contrasena;
        private SqlConnection conexion;

        public Conexion()
        {
            servidor = "ADA\\TECMANTE";
            baseDatos = "BDTEC";
            usuario = "sa";
            contrasena = "sa1234";

            string cadenaConexion = CadenaConexion();
            conexion = new SqlConnection(cadenaConexion);
        }

        public Conexion(string servidor, string baseDatos, string usuario, string contrasena)
        {
            this.servidor = servidor;
            this.baseDatos = baseDatos;
            this.usuario = usuario;
            this.contrasena = contrasena;

            string cadenaConexion = CadenaConexion();
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            return conexion;
        }

        public string CadenaConexion()
        {
            return $"Data Source={servidor};Initial Catalog={baseDatos};User id={usuario};Password={contrasena};";
        }

        public void CerrarConexion()
        {
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();
        }
    }
}
