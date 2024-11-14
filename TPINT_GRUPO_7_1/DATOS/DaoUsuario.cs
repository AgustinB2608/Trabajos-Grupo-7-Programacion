using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoUsuario
    {
            private Conexion conexion = new Conexion();

            public bool InsertarUsuario(string legajo, string contraseña, string nombre, string apellido)
            {
                string consulta = "INSERT INTO USUARIO (Legajo, Contrasena, Nombre, Apellido) VALUES (@Legajo, @Contraseña, @Nombre, @Apellido)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@Legajo", legajo),
                new SqlParameter("@Contraseña", contraseña),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido)
                };

                int resultado = conexion.EjecutarConsultaSinRetorno(consulta, parametros);
                return resultado > 0;
            }
    }
}
