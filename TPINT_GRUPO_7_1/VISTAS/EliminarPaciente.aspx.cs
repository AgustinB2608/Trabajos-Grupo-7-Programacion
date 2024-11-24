using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIOS;
using ENTIDADES;
using System.Data;

namespace VISTAS
{
    public partial class EliminarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirmarEliminar.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioPacientes negocioPaciente = new NegocioPacientes();

            if (string.IsNullOrWhiteSpace(txtEliminar.Text))
            {
                // si el TextBox esta vacío o solo tiene espacios en blanco
                lblMensaje.Text = "Por favor, ingrese un Dni.";
            }
            else
            { 
                
            if (txtEliminar.Text.Length == 8)
            {
                    ///hablariamos de que se ingresó un DNI
                    string dniN = txtEliminar.Text;

                    DataTable reg = negocioPaciente.listarPacienteEspecificoDni(dniN);

                    if (reg != null && reg.Rows.Count > 0)
                    {
                        gvPacienteInfo.DataSource = reg;
                        gvPacienteInfo.DataBind();

                        lblMensaje.Text = "¿Está seguro de que desea eliminar este médico?";

                        btnConfirmarEliminar.Visible = true;
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron resultados para el paciente.";
                    }

                    
            }

            }
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            NegocioPacientes neg = new NegocioPacientes();
            string dniN = txtEliminar.Text;

            bool SeElimino = neg.eliminarPaciente(dniN);

            ///avisos sobre si se pudo o no eliminar
            if (SeElimino)
            {
                lblMensaje.Text = "Paciente eliminado correctramente";
                gvPacienteInfo.DataSource = null;
                gvPacienteInfo.DataBind();
            }
            else
            {
                lblMensaje.Text = "Hubo un error al intentar eliminar el paciente.";
                
            }
            // Oculta el boton de confirmacion y limpia el mensaje
            lblMensaje.Text = " ";
            btnConfirmarEliminar.Visible = false;
        }
          
    }
}