using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarMensajeInicial();
            }
        }

        protected void MostrarMensajeInicial()
        {
            contentPlaceholder.Controls.Clear();
            Label lblInicio = new Label
            {
                Text = "Bienvenido al Sistema de Gestión Clínica",
                CssClass = "mensaje-inicial"
            };
            lblInicio.Text = Server.HtmlEncode(lblInicio.Text);
            contentPlaceholder.Controls.Add(lblInicio);
        }

        
    }
}