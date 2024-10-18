using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;

namespace VISTA
{
    public partial class ListadoSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }

        private void CargarSucursales()
        {
            //Creo la instancia
            NegocioSucursal negocioSucursal = new NegocioSucursal();
            //Llamo al metodo
            DataTable dt = negocioSucursal.getTabla();
            //Asigno los datos y los muestro
            grvSucursales.DataSource = dt;
            grvSucursales.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {

        }
    }
}