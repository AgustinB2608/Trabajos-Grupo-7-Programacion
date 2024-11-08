using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEGOCIOS
{
    public class NegocioProvincia
    {
        private DaoProvincia ltProvincias = new DaoProvincia();

        // Obtengo la lista de provincias llamando al metodo ObtenerProvincias de DaoProvincias
        public List<Provincias> ObtenerProvincias()
        {
            return ltProvincias.ObtenerProvincias();
        }
    }
}
