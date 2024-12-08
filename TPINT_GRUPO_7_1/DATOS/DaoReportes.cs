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
    public class DaoReportes
    {
            private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todos los dias de atencion desde la base de datos
        public DataTable ObtenerEstadisticasMensuales(string mes, string codEspecialidad)
        {
            string procedimiento = "SP_EstadisticasMensuales";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Mes", mes),
                new SqlParameter("@CodEspecialidad", codEspecialidad)
            };
         
            return ds.EjecutarProcedimientoConParametro(procedimiento, parametros);
        }

        public DataTable ObtenerPacientesMes(string mes, string estado)
        {
            string consulta = "SP_PacientesPresentesoAusentes";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@mes", mes),
                new SqlParameter("@estado", estado)
            };

            return ds.EjecutarProcedimientoConParametro(consulta, parametros);
        }


        public DataTable TotalTurnosMes(string mes)//total turnos de determinado mes
        {
            int mesActual = DateTime.Now.Month;

            if (int.Parse(mes) < mesActual)
            {

                string consulta = "SELECT COUNT(CodTurno_TU) AS 'Turnos Totales' FROM Turnos " +
                "WHERE EstadoEtapa_TU = 'A' OR EstadoEtapa_TU = 'P' AND MONTH(Dia_TU) = @mes";

                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@mes", mes)
                };

                return ds.EjecutarConsultaConParametros(consulta, parametros);

            }
            else if (int.Parse(mes) == mesActual)//total turnos del mes actual, contempla los no atendidos tambien
            {
                string consulta = "SELECT COUNT(CodTurno_TU) AS 'Turnos Totales' FROM Turnos " +
                "WHERE EstadoEtapa_TU = 'A' OR EstadoEtapa_TU = 'P' OR EstadoEtapa_TU = 'N' AND MONTH(Dia_TU) = @mes";

                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@mes", mes)
                };

                return ds.EjecutarConsultaConParametros(consulta, parametros);
            }
            else
            {
                return null;
            }

         
        }

        public DataTable TotalTurnosSegunEstadoyMes(string mes, string estado)
        {
            string consulta = "SELECT COUNT(EstadoEtapa_TU) AS Total FROM Turnos " +
            "WHERE MONTH(Dia_TU) = @mes AND EstadoEtapa_TU = @estado ; ";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@mes", SqlDbType.VarChar) { Value = mes},
                new SqlParameter("@estado", SqlDbType.VarChar) { Value = estado},
            };

            return ds.EjecutarProcedimientoConParametro(consulta, parametros);
        }
        
       

    }
}
