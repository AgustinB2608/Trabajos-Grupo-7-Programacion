using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using ENTIDADES;
namespace NEGOCIO
{
    public class NegocioProvincia
    {
        private DaoProvincias ltProvincias = new DaoProvincias();

        // Obtengo la lista de provincias llamando al metodo ObtenerProvincias de DaoProvincias
        public List<Provincias> ObtenerProvincias()
        {
            return ltProvincias.ObtenerProvincias();
        }
    }
}
