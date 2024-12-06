using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIOS;
using ENTIDADES;
using System.Data.SqlClient;
using System.Data;

namespace VISTAS
{
    public partial class EstadisticaMensualEspecialidad : System.Web.UI.Page
    {
        NegocioEspecialidades negE = new NegocioEspecialidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
        }

        /*
         Estadística Mensual de Asistencia y Ausencia: Especialidad

        Informará los porcentajes y la información de asistencias y ausencias según la especialidad.
         
         */
        public void CargarEspecialidades()
        {
            // Configuración de ddlEspecialidad
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ddlEspecialidad.Items.Clear();
            CargarEspecialidades();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RealizarInformes.aspx");
        }
    }
}