using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP7_Grupo_7
{
    public partial class ListadoSucursalesSeleccionadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tabla"] != null)
            {
                gvSucursalesSeleccionadas.DataSource = (DataTable)Session["tabla"];
                gvSucursalesSeleccionadas.DataBind();
            }
        }
    }
}