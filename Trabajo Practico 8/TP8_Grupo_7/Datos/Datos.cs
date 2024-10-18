using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace Datos
{
    class Conexion
    {
        private String ruta = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog = BDSucursales; Integrated Security = True";

        public Conexion()
        {
            //Contructor
        }

        // Crea una conexion a la base de datos y la abre si ocurre un error retorna null.
        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Ejecuta una consulta SQL (SELECT) y devuelve los resultados en un DataTable.
        public DataTable EjecutarConsulta(string consulta)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Ejecuta una consulta SQL con parámetros y devuelve los resultados en un DataTable.
        public DataTable EjecutarConsultaConParametros(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        // Agrega los parámetros al comando SQL si los hay.
                        cmd.Parameters.AddRange(parametros);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Ejecuta comandos SQL que no devuelven resultados, como INSERT, UPDATE o DELETE, y retorna el número de filas afectadas.
        public int EjecutarConsultaSinRetorno(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        // Agrega los parametros al comando SQL si los hay.
                        cmd.Parameters.AddRange(parametros);
                    }

                    return cmd.ExecuteNonQuery(); // Retorna la cantidad de filas afectadas.
                }
            }
        }

        // Crea un adaptador para llenar un DataSet con los resultados de una consulta SQL.
        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception)
            {
                return null; // Retorna null si ocurre un error al crear el adaptador.
            }
        }

        // Obtiene una tabla especifica desde la base de datos usando una consulta SQL.
        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla); // Llena el DataSet con los datos de la consulta.
            Conexion.Close();
            return ds.Tables[NombreTabla]; // Retorna la tabla especifica del DataSet.
        }

        // Verifica si existen registros que coincidan con una consulta SQL y devuelve true si existe al menos uno.
        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader(); // Ejecuta la consulta y lee los resultados.
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
    }
}
