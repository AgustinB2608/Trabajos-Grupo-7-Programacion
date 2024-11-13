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
    public partial class ListarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            NegocioPacientes negP = new NegocioPacientes();

            DataTable lista = negP.listarPacientes();

            if (lista != null && lista.Rows.Count > 0)
            {
                gvPaciente.DataSource = lista;
                gvPaciente.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se encontraron registros de pacientes.";
            }
        }
    }
}