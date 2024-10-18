using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace ENTIDADES
{
    public class Sucursal
    {
        private int Id_Sucursal;
        private String NombreSucursal;
        private String DescripcionSucursal;
        private String DireccionSucursal;

        public Sucursal()
        { }
        public int getIdSucursal()
        {
            return Id_Sucursal;
        }
        public void setIdSucursal(int idSucursal)
        {
            Id_Sucursal = idSucursal;
        }
        public String getNombreSucursal()
        {
            return NombreSucursal;
        }
        public void setNombreSucursal(String _NombreSucursal)
        {
            NombreSucursal = _NombreSucursal;
        }
        public String getDescripcionSucursal()
        {
            return DescripcionSucursal;
        }
        public void setDescripcionSucursal(String descripcionSucursal)
        {
            DescripcionSucursal = descripcionSucursal;
        }
        public String getDireccionSucursal()
        {
            return DescripcionSucursal;
        }
        public void setDireccionSucursal(String direccionSucursal)
        {
            DireccionSucursal = direccionSucursal;
        }


    }        

}
