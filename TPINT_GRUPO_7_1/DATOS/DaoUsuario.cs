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

        public bool InsertarUsuario(string contraseña, string codmedico, string nombre, string apellido)
        {
            string consulta = "EXEC SP_AgregarUsuario @CodMedico, @Contraseña, @Nombre, @Apellido";

            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@CodMedico", codmedico),
            new SqlParameter("@Contraseña", contraseña),
            new SqlParameter("@Nombre", nombre),
            new SqlParameter("@Apellido", apellido)
            };

            int resultado = conexion.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }

        public bool VerificarUsuarioExistente(string codmedico)
        {
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Legajo_ME_US = @CodMedico";
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@CodMedico", codmedico)
            };

            int resultado = (int)conexion.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }
    }

}
