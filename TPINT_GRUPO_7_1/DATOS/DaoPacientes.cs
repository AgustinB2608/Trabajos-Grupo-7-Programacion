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
            string agregar = "INSERT INTO Paciente (CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA, Localidad_PA, Provincia_PA, Email_PA, Telefono_PA, Sexo_PA, Nacionalidad_PA, Estado) " +
                             "VALUES (@CodigoPaciente, @Dni, @Nombre, @Apellido, @FechaNacimiento, @Direccion, @Localidad, @Provincia, @Email, @Telefono, @Sexo, @Nacionalidad, @Estado)";

            // Crear los parámetros y asignar los valores
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodigoPaciente", paciente.codPaciente),
                new SqlParameter("@Dni", paciente.Dni),
                new SqlParameter("@Nombre", paciente.Nombre),
                new SqlParameter("@Apellido", paciente.Apellido),
                new SqlParameter("@FechaNacimiento", DateTime.Parse(paciente.FechaNacimiento)), // Asegúrate de convertir correctamente a DateTime
                new SqlParameter("@Direccion", paciente.Direccion),
                new SqlParameter("@Localidad", paciente.Localidad),
                new SqlParameter("@Provincia", paciente.Provincia),
                new SqlParameter("@Email", paciente.Email),
                new SqlParameter("@Telefono", paciente.Celular),
                new SqlParameter("@Sexo", paciente.Sexo),           // Nuevo parámetro para Sexo
                new SqlParameter("@Nacionalidad", paciente.Nacionalidad), // Nuevo parámetro para Nacionalidad
                new SqlParameter("@Estado", paciente.Estado)
            };

            // Ejecutar la consulta con los parámetros
            int exito = ds.EjecutarConsultaSinRetorno(agregar, parametros.ToArray());

            if (exito > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminarPaciente(string CODPACIENTE)
        {
            //Consulta SQL para dar de baja un paciente en la tabla pacientes

            //ejecuta un procedimiento almacenado enviando el codigo del paciente a dar de baja

            string eliminar = "EXEC SP_bajaPaciente @CODPACIENTE";

            // envia mi string codPaciente como parametro
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@CODPACIENTE", CODPACIENTE)
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(eliminar);

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
            string modificar = "EXEC SP_modificarPaciente @Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodPaciente";

            // envia los valores de mi obj paciente como parametro

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Direccion", Paciente.Direccion),
                new SqlParameter("@Localidad", Paciente.Localidad),
                new SqlParameter("@Provincia", Paciente.Provincia),
                new SqlParameter("@Email", Paciente.Email),
                new SqlParameter("@Telefono", Paciente.Celular),
                new SqlParameter("@CodPaciente", Paciente.codPaciente)
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(modificar);

            if (exito > 0) return true;
                return false;   
        }

        public DataTable listarPacientes()
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae todos los registros
            string consulta = "SELECT CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA" +
            "Localidad_PA, Provincia_PA, Email_PA, Telefono_PA FROM Paciente WHERE Estado = 1";

            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsulta(consulta);

        }
        public DataTable listarPacienteEspecifico(string codPaciente)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistro @CodPaciente";

            // envia el valor del codpaciente como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@CodPaciente", codPaciente)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros); 

        }


    }
}
