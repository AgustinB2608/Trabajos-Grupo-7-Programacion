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
   public class NegocioReportes
    {
        DaoReportes dao = new DaoReportes();
        public DataTable ObtenerEstadisticasMensuales(string mes, string codEspecialidad)
        {
            return dao.ObtenerEstadisticasMensuales(mes, codEspecialidad);
        }

        public DataTable ObtenerPacientesMes(string mes, string estado)
        {
            return dao.ObtenerPacientesMes(mes, estado);
        }


        public DataTable TotalTurnosMes(string mes)
        {
            return dao.TotalTurnosMes(mes);
        }

        public DataTable TotalTurnosSegunEstadoyMes(string mes, string estado)
        {
            return dao.TotalTurnosSegunEstadoyMes(mes, estado);
        }

    }
}
