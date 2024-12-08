using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DaoLogin
    {
        private Conexion conexion;

        public DaoLogin()
        {
            conexion = new Conexion();
        }

        // Método que valida el login y retorna el usuario si es válido, o null si no lo es
        public Login ValidarLogin(string legajo, string contrasena)
        {
           
                // Consulta SQL para obtener el usuario y su contraseña
                string consulta = "EXEC SP_VerificarUsuario @Legajo, @Contraseña ";


                // Paso los parametros
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Legajo", SqlDbType.Char) { Value = legajo },
                    new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = contrasena }
                };

                // Ejecuto la consulta y obtengo el resultado
                DataTable resultado = conexion.EjecutarConsultaConParametros(consulta, parametros);

                // Verifico si se encontró un usuario que coincida
                if (resultado.Rows.Count > 0)
                {
                    // Creo un objeto Login con los datos obtenidos
                    Login usuario = new Login()
                    {
                        Contraseña = resultado.Rows[0]["Contraseña"].ToString(),
                        TipoUsuario = resultado.Rows[0]["TipoUsuario"].ToString(),
                        Nombre = resultado.Rows[0]["Nombre"]?.ToString(),
                        Apellido = resultado.Rows[0]["Apellido"]?.ToString()
                    };

                    return usuario; // Retorno el usuario encontrado
                }

                return null; // Si no se encontró el usuario
            
        }

    }
}
