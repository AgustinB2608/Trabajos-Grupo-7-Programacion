using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIOS;
using ENTIDADES;

namespace VISTAS
{
    public partial class ListarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensaje1.Visible = false;
            }
            else
            {
                lblMensaje1.Visible = false;
            }
           
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            NegocioMedico negMedico = new NegocioMedico();

            DataTable reg = negMedico.listarMedicos();


            if (reg != null && reg.Rows.Count > 0)
            {
                grvMedicos.DataSource = reg;
                grvMedicos.DataBind();

            }
            else
            {
                lblMensaje1.Visible = true;
                // Si no se encontraron registros
                lblMensaje1.Text = "No se encontraron resultados.";
            }
        }
    }
}