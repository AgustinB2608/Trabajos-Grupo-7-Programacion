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
    public class DaoEstadisticas
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

    }
}
