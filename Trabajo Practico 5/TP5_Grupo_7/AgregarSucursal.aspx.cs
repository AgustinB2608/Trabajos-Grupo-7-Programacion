using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_Grupo_7
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincia();
            }
        }

        private void CargarProvincia()
        {
            Conexion cargaProvincia = new Conexion();
            DataTable dtProvincias = cargaProvincia.EjecutarConsulta("SELECT Id_Provincia, DescripcionProvincia FROM Provincia");
            {
                ddlProvincia.DataSource = dtProvincias;
                ddlProvincia.DataTextField = "DescripcionProvincia";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, new ListItem("--Selecciona una provincia--", ""));
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            string consulta = "INSERT INTO Sucursal(IdSucursal, NombreSucursal, DescripcionSucursal, IdProvinciaSucursal, DireccionSucursal) VALUES ('"+ TxtSucursal.Text +" , '"+ TxtDescripcion.Text +"' ,'"+ TxtDireccion.Text +"');";
            Conexion conex = new Conexion();
            conex.EjecutarComando(consulta);
        }
    }
}