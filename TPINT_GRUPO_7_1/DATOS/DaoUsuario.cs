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

        public bool InsertarUsuario(string contraseña, string tipousuario, string codmedico, string nombre, string apellido)
        {
            string consulta = "INSERT INTO Usuarios (Contraseña_US, TipoUsuario_US, CodMedicos_US, Nombre_US, Apellido_US) " +
                              "VALUES (@Contraseña, @TipoUsuario, @CodMedico, @Nombre, @Apellido)";

            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Contraseña", contraseña),
            new SqlParameter("@TipoUsuario", tipousuario),
            new SqlParameter("@CodMedico", codmedico),
            new SqlParameter("@Nombre", nombre),
            new SqlParameter("@Apellido", apellido)
            };

            int resultado = conexion.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }

        public bool VerificarUsuarioExistente(string codmedico)
        {
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE CodMedicos_US = @CodMedico";
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@CodMedico", codmedico)
            };

            int resultado = (int)conexion.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }
    }

}
