using ENTIDADES;
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
    public partial class ListadoTurnos : System.Web.UI.Page
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
                CargarTurnos();
                CargarEspecialidades();

            }
            //buscar otra forma de declararlo
            btnConfirmarEliminar.Visible = false;
            btnCancelar.Visible = false;
        }
        protected void CargarTurnos() //
        {

            NegocioTurnos negocioTurnos = new NegocioTurnos();

            // Obtenemos los datos desde la capa de negocio
            DataTable dt = negocioTurnos.ObtenerTurnos();

            // Asignamos los datos al GridView
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void CargarEspecialidades()
        {
            NegocioEspecialidades negocioEspecialidades = new NegocioEspecialidades();
            // Obtenemos la lista de especialidades
            List<Especialidades> listaEspecialidades = negocioEspecialidades.ObtenerNombresEspecialidades();

            // Configuramos el DataSource 
            ddlEspecialidad.DataSource = listaEspecialidades;
            ddlEspecialidad.DataTextField = "DescripcionEspecialidad"; // Mostrar la descripción en el dropdown
            ddlEspecialidad.DataValueField = "Id_Especialidad"; // Usar el ID como valor
            ddlEspecialidad.DataBind();

            // Agregamos un elemento inicial
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));
        }


      
        private void FiltrarTurnos()
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            string especialidadSeleccionada = ddlEspecialidad.SelectedItem.Text;
            string estadoSeleccionado = ddlEstado.SelectedItem.Value;
            string nombreMedico = txtBuscar.Text;



            DataTable turnosFiltrados;

            if (especialidadSeleccionada == "Seleccione una especialidad" && estadoSeleccionado == "0" && string.IsNullOrEmpty(nombreMedico))
            {
                // Mostrar todos los turnos si no hay filtros
                turnosFiltrados = negocioTurnos.ObtenerTurnos();
            }
            else
            {
                // Obtener los turnos filtrados dinámicamente
                turnosFiltrados = negocioTurnos.ObtenerTurnosFiltrados(especialidadSeleccionada, estadoSeleccionado, nombreMedico);
            }

            // Mostrar los turnos filtrados en el GridView
            gvTurnos.DataSource = turnosFiltrados;
            gvTurnos.DataBind();
        }

        

        //SECCION DE FILTROS

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarTurnos(); // Filtrar cuando cambia la especialidad
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarTurnos(); // Filtrar cuando cambia el estado
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarTurnos(); // Filtrar cuando se busca por nombre
        }


        //SECCION DE AUSENTE/PRESENTE

        protected void lkbPresente_Command(object sender, CommandEventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();

            //PARA MI: cambiar a como lo hace el resto
            if (e.CommandName == "MarcarPresente")
            {
                // Obtener el ID del turno seleccionado 
                string turnoID = e.CommandArgument.ToString();

               //Cambiamos el estado en la bd
                negocioTurnos.ModificarEstado("P",turnoID);

                // Redirigir a ObservacionTurno.aspx con el ID del turno
                Response.Redirect("ObservacionTurno.aspx?TurnoID=" + turnoID);
            }

        }
        protected void btnAusente_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarcarAusente")
            {
                // Mostrar el mensaje de confirmación
                lblMensaje2.Text = "¿Está seguro de que desea marcar ausente este turno?";
                lblMensaje2.Visible = true;

                // Guardar el ID del turno seleccionado
                //ViewState mantiene el valor de una variable aunque se genere un postback
                ViewState["TurnoIDSeleccionado"] = e.CommandArgument.ToString();


                // Mostrar los botones de confirmación y cancelación
                btnConfirmarEliminar.Visible = true;
                btnCancelar.Visible = true;
            }
        }
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            // Recuperar el ID del turno seleccionado desde ViewState
            string turnoIDSeleccionado = ViewState["TurnoIDSeleccionado"] as string;
            if (!string.IsNullOrEmpty(turnoIDSeleccionado))
            {
                
                NegocioTurnos negocioTurnos = new NegocioTurnos();

                // Cambiar el estado del turno en la base de datos
                negocioTurnos.ModificarEstado("A", turnoIDSeleccionado);

                // Recargar los turnos después de la modificación
                CargarTurnos();

                // Limpiar y ocultar los controles de confirmación
                lblMensaje2.Visible = false;
                btnConfirmarEliminar.Visible = false;
                //btnCancelar.Visible = false;
                lblMensaje2.Text = ""; // Limpiar el mensaje
            }
            
        }

        //Cambio de pagina en el listado
        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Cambia el índice de la página actual
            gvTurnos.PageIndex = e.NewPageIndex;

            // Vuelve a cargar los datos del GridView
            CargarTurnos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMensaje2.Visible = false;
            btnConfirmarEliminar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje2.Text = ""; // Limpiar el mensaje
        }
    }


}
