using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TP5_Grupo_7
{
    public class Conexion
    {
        private String ruta = "Data Source=localhost\\sqlexpress01; Initial Catalog = BDSucursales; Integrated Security = True";
        // Metodo para ejecutar INSERT, DELETE, UPDATE
        public void EjecutarComando(string consulta)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();  // Ejecuta comandos que no retornan resultados (INSERT, DELETE, UPDATE)
            }
        }

        // Metodo para ejecutar consultas SELECT y retornar los resultados
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
    }
}