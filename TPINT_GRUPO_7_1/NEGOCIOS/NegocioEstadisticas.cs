using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;


 namespace NEGOCIOS
{
   public class NegocioEstadisticas
    {
        DaoEstadisticas dao = new DaoEstadisticas();
        public DataTable ObtenerEstadisticasMensuales(string mes, string codEspecialidad)
        {
            return dao.ObtenerEstadisticasMensuales(mes, codEspecialidad);
        }

        public DataTable ObtenerPacientesMes(int mes, string estado)
        {
            return dao.ObtenerPacientesMes(mes, estado);
        }

        public DataTable TotalTurnos()
        {
            return dao.TotalTurnos();
        }

        public DataTable TotalTurnosMes(int mes)
        {
            return dao.TotalTurnosMes(mes);
        }

        public DataTable TotalTurnosSegunEstadoyMes(int mes, string estado)
        {
            return dao.TotalTurnosSegunEstadoyMes(mes, estado);
        }

        public DataTable TotalTurnosPorEstadoGlobal()
        {
            return dao.TotalTurnosPorEstadoGlobal();
        }

        public DataTable TotalTurnosSegunEstadoGlobal(string estado)
        {
            return dao.TotalTurnosSegunEstadoGlobal(estado);
        }


    }
}
