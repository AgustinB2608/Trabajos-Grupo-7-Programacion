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
    public partial class AnalisisMensualDemanda : System.Web.UI.Page
    {
        NegocioEspecialidades negE = new NegocioEspecialidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEspecialidades();
                CargarMeses();
            }
        }

        /*
         Análisis Mensual de Demanda por Especialidad

        Informará cuál fue la especialidad con más turnos asignados (demanda) en el mes.
         
         */
        public void cargarEspecialidades()
        {
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));
        }
        public void CargarMeses()
        {
            // Cargar meses
            ddlMes.Items.Add(new ListItem("Seleccionar Mes", "0"));
            ddlMes.Items.Add(new ListItem("Enero", "01"));
            ddlMes.Items.Add(new ListItem("Febrero", "02"));
            ddlMes.Items.Add(new ListItem("Marzo", "03"));
            ddlMes.Items.Add(new ListItem("Abril", "04"));
            ddlMes.Items.Add(new ListItem("Mayo", "05"));
            ddlMes.Items.Add(new ListItem("Junio", "06"));
            ddlMes.Items.Add(new ListItem("Julio", "07"));
            ddlMes.Items.Add(new ListItem("Agosto", "08"));
            ddlMes.Items.Add(new ListItem("Septiembre", "09"));
            ddlMes.Items.Add(new ListItem("Octubre", "10"));
            ddlMes.Items.Add(new ListItem("Noviembre", "11"));
            ddlMes.Items.Add(new ListItem("Diciembre", "12"));
        }


        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ddlEspecialidad.Items.Clear();
            cargarEspecialidades();
            ddlMes.Items.Clear();
            CargarMeses();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioReportes.aspx");
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarResultados();
        }
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarResultados();
        }

        private void FiltrarResultados()
        {
            string mesSeleccionado = ddlMes.SelectedValue;
            string especialidadSeleccionada = ddlEspecialidad.SelectedValue;

            // Validar selección
            if (mesSeleccionado == "0" || especialidadSeleccionada == "0")
            {
                lblMensaje.Text = "Por favor, seleccione un mes y una especialidad.";
                grvEstadistica.DataSource = null;
                grvEstadistica.DataBind();
                return;
            }

            NegocioReportes negEst = new NegocioReportes();
            DataTable dt = negEst.ObtenerEstadisticasMensuales(mesSeleccionado, especialidadSeleccionada);

            if (dt.Rows.Count > 0)
            {
                grvEstadistica.DataSource = dt;
                grvEstadistica.DataBind();
                lblMensaje.Text = "";
            }
            else
            {
                grvEstadistica.DataSource = null;
                grvEstadistica.DataBind();
                lblMensaje.Text = "No se encontraron datos para la especialidad seleccionada en el mes indicado.";
            }
        }

        
    }
}