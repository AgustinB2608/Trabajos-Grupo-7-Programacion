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
    public partial class EstadisticasComparativoMensual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMeses();
        }

        /*
         Estadísticas de Asistencia y Ausencia: Comparativo Mensual

        Informará el porcentaje correspondiente al mes. Porcentaje de ausentes y presentes, 
        informará cuáles personas fueron las presentes y cuáles las ausentes.

         */
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
            ddlMes.Items.Clear();
            CargarMeses();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RealizarInformes.aspx");
        }
    }
}