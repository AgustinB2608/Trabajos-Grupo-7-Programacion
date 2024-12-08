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
    public partial class ObservacionTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la sesión 
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "M")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido

                lblUsuario.Text = $"{nombre} {apellido} ";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }
            

            if (!IsPostBack)
            {
                // Obtener el TurnoID desde la URL
                string turnoID = Request.QueryString["TurnoID"];

                if (!string.IsNullOrEmpty(turnoID))
                {
                    // Convertir el ID a entero y cargar la información
                    CargarInformacionTurno(turnoID);
                }
                else
                {
                    ///mensaje error
                }
                lblObservacionVacia.Visible = false;
            }
            


        }


        private void CargarInformacionTurno(string turnoID)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            DataTable turno = negocioTurnos.ObtenerTurnoPorID(turnoID);

            if (turno.Rows.Count > 0)
            {
                // Asignar los datos al GridView
                gvTurnoSeleccionado.DataSource = turno;
                gvTurnoSeleccionado.DataBind();
            }
            else
            {
                // Mostrar mensaje en caso de que no se encuentre el turno
                gvTurnoSeleccionado.EmptyDataText = "No se encontró el turno.";
                gvTurnoSeleccionado.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblObservacionVacia.Text = "";

            if (txtObservacion.Text != "") {
                string turnoID = Request.QueryString["TurnoID"];
                NegocioTurnos negocioTurno = new NegocioTurnos();
                negocioTurno.AgregarObservacion(turnoID, txtObservacion.Text);
                
                    lblObservacionVacia.ForeColor=System.Drawing.Color.Green;
                    lblObservacionVacia.Text = "*La observación se guardó correctamente";
                    lblObservacionVacia.Visible = true;
                
                
            }
            else
            {
                lblObservacionVacia.Text = "*La observación no debe estar vacía";
                lblObservacionVacia.Visible = true;
            }

        }
       
    }
}
