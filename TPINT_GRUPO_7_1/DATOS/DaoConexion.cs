using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    // Cambié 'internal' a 'public' para que la clase sea accesible desde otras clases
    public class Conexion
    {
        private String ruta = "Data Source=localhost\\SQLEXPRESS; Initial Catalog = Clinica; Integrated Security = True";
        //"Data Source=JUANMA\\SQLEXPRESS01; Initial Catalog = Clinica; Integrated Security = True";
        //private String ruta = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog = Clinica; Integrated Security = True";
        //private String ruta = "Data Source=localhost\\SQLEXPRESS; Initial Catalog = Clinica; Integrated Security = True";
        public Conexion()
        {
            // Constructor
        }

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

        public DataTable EjecutarConsultaConParametros(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        //EJECUTAR PROCEDIMIENTOS ALMACENADOS CON PARAMETRO
        public DataTable EjecutarProcedimientoConParametro(string procedimientoAlmacenado, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
               
                    conexion.Open();

                    // Creación del comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand(procedimientoAlmacenado, conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  // Asegura que se ejecute como procedimiento almacenado
                        if (parametros != null)
                        {
                            cmd.Parameters.AddRange(parametros);  // Añadir parámetros al comando
                        }

                        // Usar un adaptador para llenar el DataTable con los resultados
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                
               
            }
        }



        public int EjecutarConsultaSinRetorno(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

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
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
    }
}
