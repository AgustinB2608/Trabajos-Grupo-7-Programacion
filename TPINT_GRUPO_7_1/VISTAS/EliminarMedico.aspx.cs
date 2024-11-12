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
                    Medico medico = new Medico();

                    medico.setCodMedico(reg.Rows[0]["CodMedicos_ME"].ToString());
                    medico.setDni(reg.Rows[0]["Dni_ME"].ToString());
                    medico.setNombre(reg.Rows[0]["Nombre_ME"].ToString());
                    medico.setApellido(reg.Rows[0]["Apellido_ME"].ToString());
                    medico.setEmail(reg.Rows[0]["Email_ME"].ToString());
                    medico.setCelular(reg.Rows[0]["Telefono_ME"].ToString());
                    medico.setEspecialidad(reg.Rows[0]["CodEspecialidad_ME"].ToString());


                    lblMensaje2.Text = "¿Está seguro de que desea eliminar este médico?";
                }
                else
                {
                    // Si no se encontraron registros
                    lblMensaje.Text = "No se encontraron resultados para el médico.";
                }
            }
        }
    }
}