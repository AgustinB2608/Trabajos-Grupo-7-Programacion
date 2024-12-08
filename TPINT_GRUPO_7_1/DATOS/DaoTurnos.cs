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
            string consulta = "SP_ObtenerTurnos"; // Nombre del procedimiento que selecciona los campos necesarios

            // Usa el método de la clase Conexion para ejecutar el sp
            return ds.EjecutarConsultaConParametros(consulta, null);

        }
       

        
        public DataTable ObtenerTurnosFiltrados(string especialidad, string estado, string nombreMedico)
        {

            // Crear la lista de parámetros para el procedimiento almacenado
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Especialidad", SqlDbType.VarChar) { Value = especialidad},
                new SqlParameter("@Estado", SqlDbType.Char) { Value = estado},
                new SqlParameter("@NombreMedico", SqlDbType.VarChar) { Value = nombreMedico}
               
            };

            // Ejecutar el procedimiento almacenado
            return ds.EjecutarProcedimientoConParametro("sp_FiltrarTurnos", parametros);
        }

        public DataTable ObtenerTurnoPorID(string turnoID)
        {
            // Crear la lista de parámetros para el procedimiento almacenado
            SqlParameter[] parametros = new SqlParameter[]
            {
             new SqlParameter("@TurnoID", SqlDbType.VarChar) { Value = turnoID }
            };

            // Ejecutar el procedimiento almacenado que obtiene el turno por ID
            return ds.EjecutarProcedimientoConParametro("sp_ObtenerTurnoPorID", parametros);
        }




        // 06/12
        public DataTable TurnoEspecifico(string codespecialidad, string codmedico, string dni, string fecha, TimeSpan hora)
        {
            string consulta = "EXEC SP_TurnoEspecifico @codespecialidad, @codmedico, @dni, @fecha, @hora";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@codespecialidad", SqlDbType.VarChar) { Value = codespecialidad},
                new SqlParameter("@codmedico", SqlDbType.Char) { Value = codmedico},
                new SqlParameter("@dni", SqlDbType.VarChar) { Value = dni},
                new SqlParameter("@fecha", SqlDbType.VarChar) { Value = fecha},
                new SqlParameter("@hora", SqlDbType.VarChar) { Value = hora}
            };

            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public string RetornarCodigoTurno(string codespecialidad, string codmedico, string dni, string fecha, TimeSpan hora)
        {
            DataTable dt = TurnoEspecifico(codespecialidad, codmedico, dni, fecha, hora);
            string CodigoTurno = null;

            if (dt.Rows.Count > 0)

            {
                CodigoTurno = dt.Rows[0]["CodigoTurno"].ToString();
                return CodigoTurno;
            }
            else
            {
                //"Error al encontrar el codigo del turno";
                return CodigoTurno;
            }

        }

        public bool ModificarEstado(string estado, string codturno)
        {
            string consulta = "UPDATE Turnos SET EstadoEtapa_TU = @estado WHERE CodTurno_TU = @codturno; ";

            SqlParameter[] parametros = new SqlParameter[]
           {
                new SqlParameter("@estado", SqlDbType.VarChar) { Value = estado},
                new SqlParameter("@codturno", SqlDbType.VarChar) { Value = codturno}
                
           };

            // Ejecutar el procedimiento almacenado que obtiene el turno por ID
            int exito = ds.EjecutarConsultaSinRetorno(consulta, parametros);

            if (exito > 0) return true;
            return false;
        }
        
        public bool AgregarObservacion(string codturno, string observacion)
        {
            string consulta = "EXEC SP_GenerarObservacion @codturno, @observacion";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@codturno", SqlDbType.VarChar) { Value = codturno},
                new SqlParameter("@observacion", SqlDbType.VarChar) { Value = observacion}

            };

            // Ejecutar el procedimiento almacenado que obtiene el turno por ID
           int exito = ds.EjecutarConsultaSinRetorno(consulta, parametros);

            if (exito > 0) return true;
            else
            {
                return false;
            }
        }

    }
}

