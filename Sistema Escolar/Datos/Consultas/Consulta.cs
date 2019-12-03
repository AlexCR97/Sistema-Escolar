using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Datos.Consultas
{
    public abstract class Consulta
    {
        private Conexion bd;
        private string query;
        private Dictionary<string, object> parametros;

        public Consulta(params object[] args)
        {
            bd = new Conexion();
            query = DefinirQuery();
            parametros = DefinirParametros(args);
        }

        protected abstract Dictionary<string, object> DefinirParametros(params object[] args);

        protected abstract string DefinirQuery();

        public bool EjecutarQuery()
        {
            using (SqlConnection conexion = bd.AbrirConexion())
            {
                using (var comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                })
                {
                    foreach (var i in parametros)
                    {
                        string campo = i.Key;
                        object valor = i.Value;
                        comando.Parameters.AddWithValue(campo, valor);
                    }

                    try
                    {
                        int resultado = comando.ExecuteNonQuery();

                        if (resultado <= 0)
                            return false;

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public DataTable EjecutarSelect()
        {
            using (SqlConnection conexion = bd.AbrirConexion())
            {
                using (var comando = new SqlCommand()
                {
                    Connection = conexion,
                    CommandText = query,
                    CommandType = System.Data.CommandType.Text,
                })
                {
                    foreach (var i in parametros)
                    {
                        string campo = i.Key;
                        object valor = i.Value;
                        comando.Parameters.AddWithValue(campo, valor);
                    }

                    try
                    {
                        var dataTable = new DataTable();
                        var dataAdapter = new SqlDataAdapter(comando);

                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
