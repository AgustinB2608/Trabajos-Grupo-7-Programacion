using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ENTIDADES;

namespace DATOS
{
    public class DaoPacientes
    {
    private Conexion ds = new Conexion();

    // Metodo para agregar un nuevo paciente a la base de datos, retorna true si el registro fue agregado con exito, o false en caso contrario.
    public bool agregarPaciente(Pacientes paciente)
    {
        //Consulta SQL para insertar un nuevo paciente a la tabla Paciente
        string agregar = "INSERT INTO Paciente (CodPaciente_PA, Dni_PA, Nombre_PA, Apellido_PA, FechaNacimiento_PA, Direccion_PA, Localidad_PA, Provincia_PA, Email_PA, Telefono_PA, Estado)" +
                         "VALUES (@CodigoPaciente, @Dni, @Nombre, @Apellido, @FechaNacimiento, @Direccion, @Localidad, @Provincia, @Email, @Telefono, @Estado)";

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

        public bool eliminarPaciente(string CODPACIENTE)
        {
            //Consulta SQL para dar de baja un paciente en la tabla pacientes

            //ejecuta un procedimiento almacenado enviando el codigo del paciente a dar de baja

            string eliminar = "EXEC SP_bajaPaciente @CODPACIENTE";

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

    }
}
