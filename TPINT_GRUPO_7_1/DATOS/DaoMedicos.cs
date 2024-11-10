using System;
using System.Collections.Generic;
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
            //Consulta SQL para insertar un nuevo medico a la tabla Medicos
                string agregar = "INSERT INTO Medicos (Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNacimiento_ME, Direccion_ME, Localidad_ME, Provincia_ME, Email_ME, Telefono_ME, CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME, Estado) " +
                                 "VALUES (@Legajo, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodEspecialidad, @Dias, @HorarioAtencion, @Estado)";

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
    }
}
