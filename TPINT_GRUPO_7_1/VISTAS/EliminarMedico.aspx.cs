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
    public partial class EliminarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirmarEliminar.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioMedico negocioMedico = new NegocioMedico();

            if (string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                // si el TextBox esta vacío o solo tiene espacios en blanco
                lblMensaje.Text = "Por favor, ingrese un legajo.";
            }
            else
            {
                string medicoEliminar = txtLegajo.Text;

                DataTable reg = negocioMedico.listarMedicoEspecifico(medicoEliminar);

                // Verifica si el DataTable tiene datos

                if (reg != null && reg.Rows.Count > 0)
                {

                    // Filtra, remueve las columnas que no quiero mostrar
                    DataTable tablaFiltrada = reg.Copy();
                    tablaFiltrada.Columns.Remove("Sexo_ME");  
                    tablaFiltrada.Columns.Remove("Nacionalidad_ME"); 
                    tablaFiltrada.Columns.Remove("FechaNacimiento_ME"); 
                    tablaFiltrada.Columns.Remove("Direccion_ME");
                    tablaFiltrada.Columns.Remove("Localidad_ME");  
                    tablaFiltrada.Columns.Remove("Provincia_ME");
                    tablaFiltrada.Columns.Remove("Dias_ME");
                    tablaFiltrada.Columns.Remove("HorarioAtencion_ME");


                    gvMedicoInfo.DataSource = tablaFiltrada;
                    gvMedicoInfo.DataBind();

                    lblMensaje2.Text = "¿Está seguro de que desea eliminar este médico?";

                    btnConfirmarEliminar.Visible = true;
                }
                else
                {
                    // Si no se encontraron registros
                    lblMensaje.Text = "No se encontraron resultados para el médico.";
                }
            }


        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
           
                string medicoEliminar = txtLegajo.Text;
                NegocioMedico negocioMedico = new NegocioMedico();
                bool resultado = negocioMedico.eliminarMedico(medicoEliminar);

                if (resultado)
                {
                    lblMensaje.Text = "Médico eliminado correctamente.";
                    gvMedicoInfo.DataSource = null;
                    gvMedicoInfo.DataBind();
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al intentar eliminar el médico.";
                }

                // Oculta el boton de confirmacion y limpia el mensaje
                lblMensaje2.Text = " ";
                btnConfirmarEliminar.Visible = false;
            
        }
    }
}