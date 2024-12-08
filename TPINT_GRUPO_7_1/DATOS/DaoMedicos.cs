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
    public class DaoMedicos
    {
        private Conexion ds = new Conexion();

        // Metodo para agregar un nuevo medico a la base de datos retorna true si el registro fue exitoso, o false en caso contrario.

        public bool agregarMedico(Medico medic)
        {
            string agregar = "EXEC SP_AgregarMedico @Provincia, @Localidad, @CodEspecialidad, @Dias, @HorarioAtencion, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Email, @Telefono";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Provincia", medic.getProvincia()),
                new SqlParameter("@Localidad", medic.getLocalidad()),
                new SqlParameter("@CodEspecialidad", medic.getEspecialidad()),
                new SqlParameter("@Dias", medic.getDiasAtencion()),
                new SqlParameter("@HorarioAtencion", medic.getHorario()),
                new SqlParameter("@Dni", medic.getDni()),
                new SqlParameter("@Nombre", medic.getNombre()),
                new SqlParameter("@Apellido", medic.getApellido()),
                new SqlParameter("@Sexo", medic.getSexo()),
                new SqlParameter("@Nacionalidad", medic.getNacionalidad()),
                new SqlParameter("@FechaNacimiento", medic.getFechaNacimiento()),
                new SqlParameter("@Direccion", medic.getDireccion()),
                new SqlParameter("@Email", medic.getEmail()),
                new SqlParameter("@Telefono", medic.getCelular())
            };

            int filasAfectadas = ds.EjecutarConsultaSinRetorno(agregar, parametros);
            if (filasAfectadas > 0)
            {
                Console.WriteLine("Médico agregado correctamente.");
                return true;
            }
            else
            {
                Console.WriteLine("No se pudo agregar el médico.");
                return false;
            }

        }




        public bool eliminarMedico(string CodMedico)
        {
            //Consulta SQL para dar de baja un medico en la tabla Medicos

            //ejecuta un procedimiento almacenado enviando el codigo del medico a dar de baja

            string eliminar = "EXEC SP_bajaMedico @codMedico";

            // envia mi string codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", CodMedico)
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(eliminar, parametros);

            return exito > 0;
            
        }

        public bool modificarMedico(Medico medico)
        {
            
            string procedimiento = "SP_modificarMedico";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@CodMedico", medico.getCodMedico()),
        new SqlParameter("@Nombre", medico.getNombre()),
        new SqlParameter("@Apellido", medico.getApellido()),
        new SqlParameter("@Sexo", medico.getSexo()),
        new SqlParameter("@Nacionalidad", medico.getNacionalidad()),
        new SqlParameter("@FechaNacimiento", medico.getFechaNacimiento()),
        new SqlParameter("@Direccion", medico.getDireccion()),
        new SqlParameter("@CodLocalidad", medico.getLocalidad()),
        new SqlParameter("@CodProvincia", medico.getProvincia()),
        new SqlParameter("@Email", medico.getEmail()),
        new SqlParameter("@Telefono", medico.getCelular()),
        new SqlParameter("@CodEspecialidad", medico.getEspecialidad()),
        new SqlParameter("@CodDiasAtencion", medico.getDiasAtencion()),
        new SqlParameter("@CodHorarioAtencion", medico.getHorario())
            };
            
            try
            {
                int filasAfectadas = ds.EjecutarProcedimientoConRetorno(procedimiento, parametros);
                return filasAfectadas > 0; // Retorna true si se modificaron filas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar el médico: {ex.Message}");
                return false;
            }
        }

        public DataTable listarMedicos()
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae todos los registros
            string consulta = "EXEC SP_RegistrosMedicos";


            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsulta(consulta);

        }

        public DataTable listarMedicoEspecifico(string codMedico)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistroMedicoCod @CodMedico";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@CodMedico", codMedico)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public DataTable listarMedicoEspecificoDni(string dni)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistroMedicoDni @Dni";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Dni", dni)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public DataTable RetornarCodMedico(string dni)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "SELECT CodMedico_ME AS CodMedico, Nombre_ME AS Nombre, Apellido_ME AS Apellido FROM Medicos WHERE Dni_ME = @Dni";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Dni", dni)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }


         public DataTable MedicosSegunEspecialidad(string especialidad)
         {
             string consulta = "EXEC SP_RetornarMedicosEspecialidad @Especialidad";

            SqlParameter[] parametros = new SqlParameter[]
               {
                    new SqlParameter("@Especialidad", especialidad)
               };

                        return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public DataTable HorariosPorMedico(string medico)
        {
            string consulta = "EXEC SP_retornarHorariosPorMedico @CodMedico";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", medico)
            };

            return ds.EjecutarConsultaConParametros(consulta, parametros);
        }

        public DataTable ObtenerTurnosNombMedico(string Nombre)
        {
            if (string.IsNullOrEmpty(Nombre))
            {

                return new DataTable();
            }

            // Crear el parámetro para el procedimiento almacenado
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = Nombre}
            };


            return ds.EjecutarProcedimientoConParametro("SP_ObtenerTurnosNombMedico", parametros);
        }

        public bool eliminarMedicoYUsuario(string codMedico)
        {
            // Primero eliminar el médico
            if (!eliminarMedico(codMedico))
            {
                Console.WriteLine("No se pudo eliminar el médico.");
                return false;
            }

            // Crear instancia de DaoUsuarios
            DaoUsuario daoUsuarios = new DaoUsuario();

            // Llamar a la función eliminarUsuario
            if (!daoUsuarios.eliminarUsuario(codMedico))
            {
                Console.WriteLine("No se pudo eliminar el usuario asociado.");
                return false;
            }

            return true;
        }

    }
}
