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
    public class NegocioHorarios
    {
        private DaoHorario ltHorariosAtencion = new DaoHorario();

        // Obtengo la lista de dias de atencion llamando al metodo ObtenerHorarios de DaoHorario
        public List<Horarios> ObtenerHorarios()
        {
            return ltHorariosAtencion.ObtenerHorarios();
        }

        public bool EncontrarTurno(TimeSpan hora, DateTime fecha, string codespecialidad, string codmedico)
        {
             
            DataTable dt = ltHorariosAtencion.EncontrarTurno(hora, fecha, codespecialidad, codmedico);

            if (dt.Rows.Count > 0)
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
