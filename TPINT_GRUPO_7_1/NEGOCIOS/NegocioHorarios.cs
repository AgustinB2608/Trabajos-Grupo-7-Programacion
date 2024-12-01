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

        public DataTable EncontrarTurno(string hora, string fecha, string codespecialidad, string codmedico)
        {
            return ltHorariosAtencion.EncontrarTurno(hora, fecha, codespecialidad, codmedico);
        }
    }
}
