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

        public bool agregarMedico(Medico medic)
        {
                string agregar = "INSERT INTO Medicos (Legajo_ME, Dni_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNacimiento_ME, Direccion_ME, Localidad_ME, Provincia_ME, Email_ME, Telefono_ME, CodEspecialidad_ME, Dias_ME, HorarioAtencion_ME) " +
                                 "VALUES (@Legajo, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodEspecialidad, @Dias, @HorarioAtencion)";

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
