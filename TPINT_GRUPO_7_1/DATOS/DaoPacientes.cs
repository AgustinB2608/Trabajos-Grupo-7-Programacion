using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ENTIDADES;
using System.Data;

namespace DATOS
{
    public class DaoPacientes
    {
    private Conexion ds = new Conexion();

    // Metodo para agregar un nuevo paciente a la base de datos, retorna true si el registro fue agregado con exito, o false en caso contrario.
    public bool agregarPaciente(Pacientes paciente)
    {

            // Consulta SQL para insertar un nuevo paciente en la tabla Paciente
            
            string agregar = "EXEC SP_AgregarPaciente @Provincia, @Localidad, @Dni, @Nombre, @Apellido, @FechaNacimiento, @Nacionalidad, @Direccion, @Email, @Sexo, @Telefono";

            
            // Crear los parámetros y asignar los valores
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Provincia", SqlDbType.VarChar) { Value = paciente.Provincia },
                new SqlParameter("@Localidad", SqlDbType.VarChar) { Value = paciente.Localidad },
                new SqlParameter("@Dni", SqlDbType.VarChar) { Value = paciente.Dni },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = paciente.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = paciente.Apellido },
                new SqlParameter("@FechaNacimiento", SqlDbType.VarChar) { Value = paciente.FechaNacimiento },
                new SqlParameter("@Nacionalidad", SqlDbType.VarChar) { Value = paciente.Nacionalidad },
                new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = paciente.Direccion },
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = paciente.Email },
                new SqlParameter("@Sexo", SqlDbType.VarChar) { Value = paciente.Sexo },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = paciente.Celular },

            };

            // Ejecutar la consulta con los parámetros
            int exito = ds.EjecutarConsultaSinRetorno(agregar, parametros);

            if (exito > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminarPaciente(string Dni)
        {
            //Consulta SQL para dar de baja un paciente en la tabla pacientes

            //ejecuta un procedimiento almacenado enviando el codigo del paciente a dar de baja

            string eliminar = "EXEC SP_bajaPacienteDni @Dni";

            // envia mi string codPaciente como parametro
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Dni", Dni)
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(eliminar, parametros);

            if (exito > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool modificarPaciente(Pacientes Paciente)
        {

            // Consulta SQL para ejecutar el procedimiento almacenado que actualiza los valores
            string modificar = "EXEC SP_modificarPaciente @Provincia, @Localidad, @Dni, @Nombre, @Apellido, @FechaNacimiento, "+
                "@Nacionalidad, @Direccion, @Email, @Sexo, @Telefono";

            // envia los valores de mi obj paciente como parametro

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Provincia", SqlDbType.VarChar) { Value = Paciente.Provincia },
                new SqlParameter("@Localidad", SqlDbType.VarChar) { Value = Paciente.Localidad },
                new SqlParameter("@Dni", SqlDbType.VarChar) { Value = Paciente.Dni },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = Paciente.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = Paciente.Apellido },
                new SqlParameter("@FechaNacimiento", SqlDbType.VarChar) { Value = Paciente.FechaNacimiento },
                new SqlParameter("@Nacionalidad", SqlDbType.VarChar) { Value = Paciente.Nacionalidad },
                new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = Paciente.Direccion },
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = Paciente.Email },
                new SqlParameter("@Sexo", SqlDbType.VarChar) { Value = Paciente.Sexo },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Paciente.Celular },

            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(modificar, parametros);

            if (exito > 0) return true;
                return false;   
        }

        public DataTable listarPacientes()
        {
            // Consulta SQL para traer todos los registros de pacientes activos
            string consulta = "EXEC SP_RegistrosPacientes";


            // Retorna el DataTable utilizando el método EjecutarConsultaConParametros de Conexion
            return ds.EjecutarConsulta(consulta);
        }

        public DataTable listarPacienteEspecificoDni(string dni)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado segun dni
            string consulta = "EXEC SP_retornarRegistroPacienteDni @Dni";

            // envia el valor del codpaciente como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Dni", dni)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

    }
}
