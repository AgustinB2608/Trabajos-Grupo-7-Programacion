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
            string consulta = "EXEC SP_AgregarTurno @codespecialidad, @codmedico, @NombrePaciente, @ApellidoPaciente, @Dni, " +
                "@Fecha, @HorarioAtencion";


            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@codespecialidad", turno.getEspecialidad()),
                    new SqlParameter("@codmedico", turno.getMedico()),
                    new SqlParameter("@NombrePaciente", turno.getNombre()),
                    new SqlParameter("@ApellidoPaciente", turno.getApellido()),
                    new SqlParameter("@Dni", turno.getDni()),
                    new SqlParameter("@Fecha", turno.getDia()),
                    new SqlParameter("@HorarioAtencion", turno.getHorario()),
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

