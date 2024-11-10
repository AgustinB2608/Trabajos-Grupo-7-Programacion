using System;
using System.Collections.Generic;
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
    }
}
