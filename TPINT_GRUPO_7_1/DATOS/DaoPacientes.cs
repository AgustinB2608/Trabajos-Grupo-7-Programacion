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
            SqlParameter[] parametros = new SqlParameter[]
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
            SqlParameter[] parametros = new SqlParameter[]
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

        public bool eliminarPacienteDNI(string Dni)
        {

            //ejecuta un procedimiento almacenado, envia DNI del paciente como parametro

            string eliminar = "EXEC SP_bajaPacienteDni @Dni";

            
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Dni", Dni)
            };

           //Verifica si hubo exito
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
            string modificar = "EXEC SP_modificarPaciente @CodPaciente, @Direccion, @Localidad, @Provincia, @Email, @Telefono";

            // envia los valores de mi obj paciente como parametro

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodPaciente", Paciente.Direccion),
                new SqlParameter("@Direccion", Paciente.Direccion),
                new SqlParameter("@Localidad", Paciente.Localidad),
                new SqlParameter("@Provincia", Paciente.Provincia),
                new SqlParameter("@Email", Paciente.Email),
                new SqlParameter("@Telefono", Paciente.Celular),
                
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(modificar);

            if (exito > 0) return true;
                return false;   
        }

        public DataTable listarPacientes(string contenido = "")
        {
            // Consulta SQL para traer todos los registros de pacientes activos
            string consulta = "SELECT CodPaciente_PA AS CodPaciente, Dni_PA AS Dni, Nombre_PA AS Nombre, Apellido_PA AS Apellido, " +
                              "FechaNacimiento_PA AS 'Fecha de Nacimiento', Direccion_PA AS Direccion, Localidad_PA AS Localidad, " +
                              "Provincia_PA AS Provincia, Email_PA AS Email, Telefono_PA AS Telefono " +
                              "FROM Paciente WHERE Estado = 1";

            // Si se proporciona un término de búsqueda, agrega condiciones de filtrado
            List<SqlParameter> parametros = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(contenido))
            {
                consulta += " AND (Nombre_PA LIKE @Contenido OR Apellido_PA LIKE @Contenido OR Dni_PA LIKE @Contenido)";
                parametros.Add(new SqlParameter("@Contenido", "%" + contenido + "%"));
            }

            // Retorna el DataTable utilizando el método EjecutarConsultaConParametros de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros.ToArray());
        }


        public DataTable listarPacienteEspecifico(string codPaciente)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistroPacienteCod @CodPaciente";

            // envia el valor del codpaciente como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@CodPaciente", codPaciente)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros); 

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

        // Metodo para obtener lista de todos los pacientes desde la base de datos.
        public List<Pacientes> ObtenerPaciente()
        {
            // Consulta SQL para seleccionar datos de la tabla Pacientes
            string consulta = "SELECT CodPaciente_PA, Nombre_PA FROM Paciente";

            // Ejecuta la consulta y obtiene los resultados en un DataTable
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Crea una lista de objetos de Pacientes para almacenar los resultados
            List<Pacientes> pacientes = new List<Pacientes>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Crea un nuevo objeto de Pacientes y asigna los valores de la fila actual
                Pacientes paciente = new Pacientes();
                paciente.codPaciente = row["CodPaciente_PA"].ToString();
                paciente.Nombre = row["Nombre_PA"].ToString();


                // Agrega el objeto Pacientes a la lista
                pacientes.Add(paciente);
            }
            return pacientes;
        }
    }
}
