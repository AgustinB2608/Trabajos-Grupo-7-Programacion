using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoSucursales
    {
        /// 
        /// 
            private Conexion ds = new Conexion();

            
            public Sucursal ObtenerSucursal(int SucursalElegida)
            {
                
                string consulta = $"SELECT id_Sucursal, NombreSucursal, DescripcionSucursal, DireccionSucursal FROM Sucursal WHERE id_Sucursal = {SucursalElegida}";

                DataTable dt = ds.EjecutarConsulta(consulta);

                if (dt.Rows.Count == 0)
                {
                    return null; // Si no hay resultados devuelve null 
                }

                DataRow row = dt.Rows[0];  // obtengo la única fila
                Sucursal sucursal = new Sucursal
                {
                id_sucursal = (int)row["id_Sucursal"],
                NombreSucursal = row["NombreSucursal"].ToString(),
                DescripcionSucursal = row["DescripcionSucursal"].ToString(),
                DireccionSucursal = row["DireccionSucursal"].ToString()
                };

                return sucursal;
            }
        
    }
}
