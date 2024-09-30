using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_7
{
    public class Conexion
    {
        string rutaNeptuno = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"; 

        public Conexion()
        {
            //Contructor
        }
        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaNeptuno);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable EjecutarConsulta(string consulta)
        {
            using (SqlConnection conexion = new SqlConnection(rutaNeptuno))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}