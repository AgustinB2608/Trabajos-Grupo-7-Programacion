using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIO;

namespace VISTA
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {

        NegocioProvincia negP = new NegocioProvincia();
        NegocioSucursal negS = new NegocioSucursal();
        Sucursal reg = new Sucursal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProvincia.DataSource = negP.ObtenerProvincias();
                ddlProvincia.DataTextField = "DescripcionProvincia1";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();

                // Opción inicial
                ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            
            reg.setNombreSucursal(TxtSucursal.Text.Replace("'", "''"));
            reg.setDescripcionSucursal(TxtDescripcion.Text.Replace("'", "''"));
            reg.setProvinciaSucursal(ddlProvincia.SelectedValue);
            reg.setDireccionSucursal(TxtDireccion.Text.Replace("'", "''"));

            bool exito = negS.agregarSucursal(reg);

            if (exito)
            {
                lblMensaje.Text = "Sucursal añadida con éxito";


            }
            else
            {
                lblMensaje.Text = "No se pudo añadir la sucursal";

            }

            TxtSucursal.Text = " ";
            TxtDescripcion.Text = " ";
            ddlProvincia.ClearSelection();
            TxtDireccion.Text = " ";
            
        }
    }
}