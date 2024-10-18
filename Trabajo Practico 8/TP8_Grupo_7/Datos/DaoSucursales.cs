using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


            public DataTable ObtenerSucursal(int idSucursal)
            {
                string consulta = "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal, P.DescripcionProvincia, S.DireccionSucursal " +
                                  "FROM Sucursal S " +
                                  "INNER JOIN Provincia P ON P.Id_Provincia = S.Id_ProvinciaSucursal " +
                                  "WHERE S.Id_Sucursal = @IdSucursal";

                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@IdSucursal", idSucursal)
                };

                return ds.EjecutarConsultaConParametros(consulta, parametros);
            }
        
            // Metodo para obtener las tablas con todas las sucursales y la provincia
            public DataTable getTablaSucursal()
            {
                DataTable tabla = ds.ObtenerTabla("Sucursal",
                    "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal, P.DescripcionProvincia, S.DireccionSucursal " +
                    "FROM Sucursal S " +
                    "INNER JOIN Provincia P ON P.Id_Provincia = S.Id_ProvinciaSucursal");
                return tabla;
            }
    }
}
