using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using ENTIDADES;

namespace NEGOCIO
{
    public class NegocioSucursal
    {
        private DaoSucursales dao;

        public NegocioSucursal()
        {
            dao = new DaoSucursales();
        }

        // Metodo que obtiene una tabla con los datos de todas las sucursales
        public DataTable getTabla()
        {
            return dao.getTablaSucursal();
        }

        //Metodo que obtiene la fila con los datos de una sucursal en concreto
        public DataTable getSucursalPorId(int idSucursal)
        {
            return dao.ObtenerSucursal(idSucursal);


        }
    }
}
