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

        public bool InsertarUsuario(string codmedico, string contraseña)
        {
            string consulta = "EXEC SP_AgregarUsuario @CodMedico, @Contraseña";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", codmedico),
                new SqlParameter("@Contraseña", contraseña)
            };

            int resultado = ds.EjecutarConsultaSinRetorno(consulta, parametros);
            return resultado > 0;
        }


        public bool VerificarUsuarioExistente(string codmedico)
        {
            string consulta = "SELECT Legajo_ME_US FROM Usuarios WHERE Legajo_ME_US = @CodMedico;";
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@CodMedico", codmedico)
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

            try
            {
                int filasAfectadas = ds.EjecutarProcedimientoConRetorno(procedimiento, parametros);
                return filasAfectadas > 0; // Retorna true si se modificaron filas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el Usuario: {ex.Message}");
                return false;
            }
        }

        public DataTable listarUsuarioEspecifico(string codUsuario)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarUsuario @Legajo";

            // envia el valor del codUsuario como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Legajo", codUsuario)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public bool eliminarUsuario(string CodMedico)
        {
            string eliminar = "EXEC SP_BajaUsuario @codMedico";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", CodMedico)
            };
            int exito = ds.EjecutarConsultaSinRetorno(eliminar, parametros);

            return exito > 0;

        }

    }

}
