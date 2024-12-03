using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        NegocioUsuarios negU = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar si hay un código de médico en la sesión
                if (Session["CodMedico"] != null)
                {
                    string codmedico = Session["CodMedico"].ToString();
                    txtCodigo.Text = codmedico; // Prellenar el campo con el valor de la sesión
                    txtCodigo.Enabled = false; // Evitar que se modifique
                }
                else
                {
                    lblMensaje2.Visible = true;
                    lblMensaje2.Text = "No se encontró un código de médico en la sesión.";
                    btnEliminar.Enabled = false; // Deshabilitar el botón si no hay código
                }

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}