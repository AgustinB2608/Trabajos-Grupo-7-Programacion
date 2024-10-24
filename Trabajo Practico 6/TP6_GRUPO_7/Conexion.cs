﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_7
{
    public class Conexion
    {
        string rutaNeptuno = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";

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
            catch (Exception)
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
        // Nueva función para ejecutar comandos como DELETE, INSERT, UPDATE
        public int EjecutarConsultaSinRetorno(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = new SqlConnection(rutaNeptuno))
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
    }
}