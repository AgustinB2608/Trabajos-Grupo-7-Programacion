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
            try
            {
                // Consulta SQL para obtener el usuario y su contraseña
                string consulta = "SELECT Legajo_US, Contraseña_US, TipoUsuario_US, Nombre, Apellido " +
                                  "FROM Usuarios WHERE Legajo_US = @Legajo AND Contraseña_US = @Contrasena";

                // Parametrización de la consulta
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Legajo", SqlDbType.NVarChar) { Value = legajo },
                    new SqlParameter("@Contrasena", SqlDbType.NVarChar) { Value = contrasena }
                };

                // Ejecuta la consulta y obtiene el resultado
                DataTable resultado = conexion.EjecutarConsultaConParametros(consulta, parametros);

                // Verifica si se encontró un usuario que coincida
                if (resultado.Rows.Count > 0)
                {
                    // Crea un objeto Login con los datos obtenidos
                    Login usuario = new Login()
                    {
                        Legajo = resultado.Rows[0]["Legajo_US"].ToString(),
                        Contraseña = resultado.Rows[0]["Contraseña_US"].ToString(),
                        TipoUsuario = resultado.Rows[0]["TipoUsuario_US"].ToString(),
                        Nombre = resultado.Rows[0]["Nombre"]?.ToString(),
                        Apellido = resultado.Rows[0]["Apellido"]?.ToString()
                    };

                    return usuario; // Retorna el usuario encontrado
                }

                return null; // Si no se encontró el usuario
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de error en la consulta
                Console.WriteLine("Error al validar el login: " + ex.Message);
                return null;
            }
        }
    }
}
