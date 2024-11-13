using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias();
            }
        }

        public void CargarProvincias()
        {
            NegocioProvincia negocioProvincia = new NegocioProvincia();
            List<Provincias> listaProvincias = negocioProvincia.ObtenerProvincias();

            // Cargamos el dropdown provincias
            ddlProvincia.DataSource = listaProvincias;
            ddlProvincia.DataTextField = "DescripcionProvincia1"; // Propiedad para mostrar
            ddlProvincia.DataValueField = "Id_Provincia"; // Propiedad para el valor
            ddlProvincia.DataBind();

            // item inicial
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione una provincia--"));

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}