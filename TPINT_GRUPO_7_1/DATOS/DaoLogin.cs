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
                string consulta = "SELECT Legajo_AD_US AS LegajoAdministrador, Legajo_ME_US AS LegajoMedico, "+
                    "Nombre_US AS Nombre, Apellido_US AS Apellido,"+
                    "TipoUsuario_US AS TipoUsuario, Contraseña_US AS Contraseña " +
                    "FROM Usuarios WHERE Legajo_ME_US = @Legajo OR Legajo_AD_US = @Legajo " +
                    "AND Contraseña_US = @Contraseña AND Estado_US = 1; ";


                // Parametrización de la consulta
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Legajo", SqlDbType.Char) { Value = legajo },
                    new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = contrasena }
                };

                // Ejecuta la consulta y obtiene el resultado
                DataTable resultado = conexion.EjecutarConsultaConParametros(consulta, parametros);

                // Verifica si se encontró un usuario que coincida
                if (resultado.Rows.Count > 0)
                {
                    // Crea un objeto Login con los datos obtenidos
                    Login usuario = new Login()
                    {
                        Contraseña = resultado.Rows[0]["Contraseña"].ToString(),
                        TipoUsuario = resultado.Rows[0]["TipoUsuario"].ToString(),
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
