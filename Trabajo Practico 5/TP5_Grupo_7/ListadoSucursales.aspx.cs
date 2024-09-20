using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_Grupo_7
{
    public partial class ListadoSucursales : System.Web.UI.Page
    { 
        private Conexion conexion = new Conexion();

        
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarSucursales();
                }
            }
            private void CargarSucursales()
            {



            }

            protected void Button1_Click(object sender, EventArgs e)

            {
                string IDsucursal = txtSucursal.Text;

                   string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, " +
                           "DescripcionProvincia, DireccionSucursal " +
                           "FROM Sucursal " +
                           "INNER JOIN Provincia ON Provincia.Id_Provincia = Sucursal.Id_ProvinciaSucursal " +
                           "WHERE Id_Sucursal = '" + IDsucursal + "'";
               DataTable dt = conexion.EjecutarConsulta(consulta);
                if (dt.Rows.Count > 0)
                {
                    grvSucursales.DataSource = dt;
                    grvSucursales.DataBind();
                }
        }
    }
}
