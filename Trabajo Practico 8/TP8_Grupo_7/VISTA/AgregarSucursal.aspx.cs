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
        NegocioProvincia reg = new NegocioProvincia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProvincia.DataSource = reg.ObtenerProvincias();
                ddlProvincia.DataTextField = "DescripcionProvincia1";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();

                // Opción inicial
                ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}