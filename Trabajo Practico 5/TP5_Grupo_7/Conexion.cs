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
        private String ruta = "Data Source=localhost\\SQLEXPRESS02; Initial Catalog = BDSucursales; Integrated Security = True";
        //private String ruta = "Data Source = localhost\\sqlexpress; Initial Catalog = BDSucursales; IntegratedSecurity = True";


        // Metodo para ejecutar INSERT, DELETE, UPDATE
        public bool EjecutarComando(string consulta)
        {
            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                if (comando.ExecuteNonQuery() > 0)// Ejecuta comandos que no retornan resultados (INSERT, DELETE, UPDATE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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