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
    public class DaoTurnos
    {
        private Conexion ds = new Conexion();

        public bool agregarTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos (CodEspecialidades_TU, Dia_TU, NombrePaciente_TU, ApellidoPaciente_TU, DniPaciente_TU, CodMedico_TU, Horario_TU, CodEstadoTurno_TU)" +
                               " VALUES (@Especialidad, @Dia, @Nombre, @Apellido, @Dni, @Medico, @horario, @CodEstadoTurno)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@Especialidad", turno.getEspecialidad()),
                    new SqlParameter("@Dia", turno.getDia()),
                    new SqlParameter("@Nombre", turno.getNombre()),
                    new SqlParameter("@Apellido", turno.getApellido()),
                    new SqlParameter("@Dni", turno.getDni()),
                    new SqlParameter("@Medico", turno.getMedico()),
                    new SqlParameter("@horario", turno.getDuracion()),
                    new SqlParameter("@CodEstadoTurno", turno.getCodEstadoTurno()),
            };

            int exito = ds.EjecutarConsultaSinRetorno(consulta, parametros);

            return exito > 0;
        }

        public DataTable ObtenerTurnos()
        {
            string consulta = "sp_ObtenerTurnos"; // Nombre del procedimiento que selecciona los campos necesarios

            // Usa el método de la clase Conexion para ejecutar el sp
            return ds.EjecutarConsultaConParametros(consulta, null);

        }
        public DataTable ObtenerTurnosPorEspecialidad(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                
                return new DataTable(); 
            }

            // Crear el parámetro para el procedimiento almacenado
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@Estado", SqlDbType.NVarChar) { Value = estado }
            };


            return ds.EjecutarProcedimientoConParametro("SP_ObtenerTurnosEstado", parametros);
        }

        public DataTable ObtenerTurnosPorEspYEst(string especialidadSeleccionada, string estadoSeleccionado)
        {
            // Si no se pasan ambos valores, devolver una tabla vacía
            if (string.IsNullOrEmpty(estadoSeleccionado) || string.IsNullOrEmpty(especialidadSeleccionada))
            {
                return new DataTable(); // Devolver tabla vacía si falta alguno de los valores
            }

            // Crear los parámetros para el procedimiento almacenado
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Estado", SqlDbType.NVarChar) { Value = estadoSeleccionado },
                new SqlParameter("@Especialidad", SqlDbType.NVarChar) { Value = especialidadSeleccionada }
            };

            // Ejecutar el procedimiento almacenado y devolver el resultado
            return ds.EjecutarProcedimientoConParametro("SP_ObtenerTurnosEspYEst", parametros);
        }

    }
}

