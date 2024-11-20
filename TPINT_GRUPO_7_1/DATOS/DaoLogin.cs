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
        public Login ValidarLogin(int legajo, string contrasena)
        {
            try
            {
                // Consulta SQL para obtener el usuario y su contraseña
                string consulta = "SELECT Legajo, Contraseña, TipoUsuario, Nombre_US, Apellido_US " +
                                  "FROM Usuarios WHERE Legajo = @Legajo AND Contraseña = @Contrasena";

                // Parametrización de la consulta
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Legajo", SqlDbType.Int) { Value = legajo },
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
                        Contraseña = resultado.Rows[0]["Contraseña"].ToString(),
                        TipoUsuario = resultado.Rows[0]["TipoUsuario"].ToString(),
                        Nombre = resultado.Rows[0]["Nombre_US"]?.ToString(),
                        Apellido = resultado.Rows[0]["Apellido_US"]?.ToString()
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


        public void InsertUsuario(Login usuario)
        {
            try
            {
                string consulta = "INSERT INTO Usuarios (Contraseña, TipoUsuario, CodAdmin_AD, CodMedicos_ME, Nombre_US, Apellido_US) " +
                                  "VALUES (@Contraseña, @TipoUsuario, @CodAdmin, @CodMedicos, @Nombre, @Apellido)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = usuario.Contraseña },
                    new SqlParameter("@TipoUsuario", SqlDbType.Char) { Value = usuario.TipoUsuario }, 
                    new SqlParameter("@CodMedicos", SqlDbType.Char) { Value = usuario.CodigoMedico }, 
                    new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = usuario.Nombre },
                    new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = usuario.Apellido }
                };

                // Ejecuta la consulta
                int filasAfectadas = conexion.EjecutarConsultaSinRetorno(consulta, parametros);
                if (filasAfectadas > 0)
                {
                    Console.WriteLine("Usuario guardado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al guardar el usuario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
            }
        }


    }
}
