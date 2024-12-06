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
            cargarEspecialidades();
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

       

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ddlEspecialidad.Items.Clear();
            cargarEspecialidades();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RealizarInformes.aspx");
        }

    }
}