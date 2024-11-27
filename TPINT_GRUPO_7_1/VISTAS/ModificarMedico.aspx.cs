using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIOS;

namespace VISTAS
{
    public partial class ModificarMedico : System.Web.UI.Page
    {
        NegocioMedico regM = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de texto está vacío o contiene solo espacios
            if (string.IsNullOrWhiteSpace(txtCodigoMedico.Text))
            {
                lblMensajeBusqueda.Text = "Por favor, ingrese un Código de Médico.";
                return;
            }

            // Obtener el código ingresado, eliminando espacios adicionales
            string input = txtCodigoMedico.Text.Trim();

            // Obtener los datos del médico
            DataTable dt = regM.listarMedicoEspecifico(input);

            // Mostrar resultados en la grilla
            grvMedicos.DataSource = dt;
            grvMedicos.DataBind();

            // Mostrar mensaje según los resultados
            lblMensajeBusqueda.Text = dt.Rows.Count > 0
                ? ""
                : "No se encontraron médicos con el Código.";
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            DataTable reg = regM.listarMedicos();


            if (reg != null && reg.Rows.Count > 0)
            {
                grvMedicos.DataSource = reg;
                grvMedicos.DataBind();

            }
            else
            {
                lblMensajeBusqueda.Visible = true;
                // Si no se encontraron registros
                lblMensajeBusqueda.Text = "No se encontraron resultados.";
            }
        }

        protected void grvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMedicos.PageIndex = e.NewPageIndex; // Cambiar el índice de página
            BindGridView(); // Asegurarte de recargar los datos
        }

        private void BindGridView()
        {
            grvMedicos.DataSource = regM.listarMedicos();
            grvMedicos.DataBind();
        }

        protected void grvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int rowIndex = e.NewEditIndex;

            // Suponiendo que la clave primaria (como el código del médico) está en la primera columna
            string codigoMedico = grvMedicos.DataKeys[rowIndex].Value.ToString();

            // Redirigir a la página EditarMedico.aspx con el código del médico en la QueryString
            Response.Redirect($"EditarMedico.aspx?codigo={codigoMedico}");
        }

    }
}