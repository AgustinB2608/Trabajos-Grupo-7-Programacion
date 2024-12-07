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
        public DataTable ObtenerEstadisticasMensuales(string mes, string codEspecialidad)
        {
            DaoEstadisticas dao = new DaoEstadisticas();
            return dao.ObtenerEstadisticasMensuales(mes, codEspecialidad);
        }
    }
}
