using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data;

namespace DATOS
{
    public class DaoMedicos
    {
        private Conexion ds = new Conexion();

        // Metodo para agregar un nuevo medico a la base de datos retorna true si el registro fue exitoso, o false en caso contrario.

        public bool agregarMedico(Medico medic)
        {
            //Consulta SQL para insertar un nuevo medico a la tabla Medicos
                string agregar = "INSERT INTO Medicos (CodMedicos_ME, Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNacimiento_ME, Direccion_ME, Localidad_ME, Provincia_ME, Email_ME, Telefono_ME, CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME, Estado) " +
                                 "VALUES (@Matricula, @Legajo, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodEspecialidad, @Dias, @HorarioAtencion, @Estado)";

            // Crea el array de parametros con los valores obtenidos de los get y set 
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Matricula", medic.getCodMedico()),
                new SqlParameter("@Legajo", medic.getLegajo()),
                new SqlParameter("@Dni", medic.getDni()),
                new SqlParameter("@Nombre", medic.getNombre()),
                new SqlParameter("@Apellido", medic.getApellido()),
                new SqlParameter("@Sexo", medic.getSexo()),
                new SqlParameter("@Nacionalidad", medic.getNacionalidad()),
                new SqlParameter("@FechaNacimiento", medic.getFechaNacimiento()),
                new SqlParameter("@Direccion", medic.getDireccion()),
                new SqlParameter("@Localidad", medic.getLocalidad()),
                new SqlParameter("@Provincia", medic.getProvincia()),
                new SqlParameter("@Email", medic.getEmail()),
                new SqlParameter("@Telefono", medic.getCelular()),
                new SqlParameter("@CodEspecialidad", medic.getEspecialidad()),
                new SqlParameter("@Dias", medic.getDiasAtencion()),
                new SqlParameter("@HorarioAtencion", medic.getHorario()),
                new SqlParameter("@Estado", 1)
            };


            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado(solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(agregar);

            if (exito > 0)
            {
                return true;
            }
            else
            {
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

            // Consulta SQL para ejecutar el procedimiento almacenado que actualiza los valores
            string modificar = "EXEC SP_modificarMedico @Legajo, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento" +
            "@Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodEspecialidad, @Dias, @HorarioAtencion, @Usuario, @Contraseña";

            // envia los valores de mi obj medico como parametro

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Legajo", medico.getLegajo()),
                new SqlParameter("@Nombre", medico.getNombre()),
                new SqlParameter("@Apellido", medico.getApellido()),
                new SqlParameter("@Sexo", medico.getSexo()),
                new SqlParameter("@Nacionalidad", medico.getNacionalidad()),
                new SqlParameter("@FechaNacimiento", medico.getFechaNacimiento()),
                new SqlParameter("@Direccion", medico.getDireccion()),
                new SqlParameter("@Localidad", medico.getLocalidad()),
                new SqlParameter("@Provincia", medico.getProvincia()),
                new SqlParameter("@Email", medico.getEmail()),
                new SqlParameter("@Telefono", medico.getCelular()),
                new SqlParameter("@CodEspecialidad", medico.getEspecialidad()), 
                new SqlParameter("@Dias", medico.getDiasAtencion()),
                new SqlParameter("@HorarioAtencion", medico.getHorario()), 
                new SqlParameter("@Usuario", medico.getUsuario()),
                new SqlParameter("@Contraseña", medico.getContraseña())
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(modificar, parametros);

            if (exito > 0) return true;
            return false;
        }

        public DataTable listarMedicos()
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae todos los registros
            string consulta = "SELECT CodMedicos_ME AS CodigoMedico, Dni_ME AS Dni, Nombre_ME AS Nombre, Apellido_ME AS Apellido," +
               "Sexo_ME AS Sexo, Nacionalidad_ME AS Nacionalidad, FechaNacimiento_ME AS 'Fecha de Nacimiento'," +
               "Direccion_ME AS Direccion, Localidad_ME AS Localidad, Provincia_ME AS Provincia, Email_ME AS Email," +
               "CodEspecialidad_ME AS CodigoEspecialidad, NombreEspecialidad_ES AS 'Nombre Especialidad'," +
               "Dias_ME AS 'Dias de Atención', HorarioAtencion_ME AS 'Horarios de Atención' FROM Medicos INNER JOIN Especialidad " +
               "ON (CodEspecialidad_ME = CodEspecialidad_ES) WHERE Estado = 1";


            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsulta(consulta);

        }

        public DataTable listarMedicoEspecifico(string codMedico)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistro @CodMedico";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@CodMedico", codMedico)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }
    }
}
