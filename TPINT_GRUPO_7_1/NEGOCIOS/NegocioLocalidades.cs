using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class NegocioLocalidades
    {
        private DaoLocalidad ltLocalidad = new DaoLocalidad();

        // Obtengo la lista de localidades llamando al metodo ObtenerLocalidad de DaoLocalidad
        public List<Localidades> ObtenerLocalidad()
        {
            return ltLocalidad.ObtenerLocalidad();
        }
    }
}
