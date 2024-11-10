using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class NegocioDiasAtencion
    {
        private DaoDiasAtencion ltDiasAtencion = new DaoDiasAtencion();

        // Obtengo la lista de dias de atencion llamando al metodo ObtenerDiasAtencion de DaoDiasAtencion
        public List<DiasAtencion> ObtenerDiasAtencion()
        {
            return ltDiasAtencion.ObtenerDiasAtencion();
        }
    }
}
