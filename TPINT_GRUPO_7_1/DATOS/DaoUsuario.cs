using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoUsuario
    {
        private Conexion ds = new Conexion();

        public bool InsertarUsuario(string codmedico, string nombre, string apellido, string contraseña)
        {
            string consulta = "EXEC SP_AgregarUsuario @CodMedico, @Nombre, @Apellido, @Contraseña";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", codmedico),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@Contraseña", contraseña)
            };

            int resultado = ds.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }


        public bool VerificarUsuarioExistente(string legajo, string contraseña)
        {
            string consulta = "EXEC SP_VerificarUsuario @legajo, @contraseña";
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@legajo", legajo),
            new SqlParameter("@contraseña", contraseña)
            };

            int resultado = ds.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }

        public bool modificarUsuario(Usuarios usuarios)
        {
            string procedimiento = "SP_modificarUsuario";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Legajo", usuarios.Legajo),
                new SqlParameter("@Contraseña", usuarios.Contraseña)
            };

           
                int filasAfectadas = ds.EjecutarProcedimientoConRetorno(procedimiento, parametros);
                return filasAfectadas > 0; // Retorna true si se modificaron filas
            
        }


        public bool eliminarUsuario(string legajo)
        {
            string eliminar = "EXEC SP_BajaUsuario @CodMedico";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", legajo)
            };
            int exito = ds.EjecutarConsultaSinRetorno(eliminar, parametros);

            return exito > 0;

        }


        public string RecuperarContraseña(string dni, string legajo)
        {
            string consulta = "EXEC SP_recuperarContraseñaConDNI @Dni, @Legajo";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Dni", dni),
                new SqlParameter("@Legajo", legajo)
            };

            DataTable resultado = ds.EjecutarConsultaConParametros(consulta, parametros);

            if (resultado.Rows.Count > 0)
            {
                return resultado.Rows[0]["Contraseña"].ToString();
            }

            return null;
        }



    }

}
