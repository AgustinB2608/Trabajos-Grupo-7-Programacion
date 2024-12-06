using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class AnalisisPacientesCancelaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarOrden();
        }

        /*
         Análisis de Pacientes con Alta Tasa de Cancelaciones

        Informará sobre el mes anterior al actual. Tiene como objetivo identificar 
        y analizar a aquellos pacientes que han cancelado una cantidad significativa de turnos 
        y poder listarlos bajo una categoría de baja prioridad lo que le permitirá a la clínica tener en cuenta 
        estas cancelaciones al momento de gestionar la programación de citas futuras.
         
         */
        public void CargarOrden()
        {
            ddlOrden.Items.Insert(0, new ListItem("Seleccionar Orden", "0"));
            ddlOrden.Items.Add(new ListItem("Ascendente", "01"));
            ddlOrden.Items.Add(new ListItem("Descendente", "02"));
        }
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ddlOrden.Items.Clear();
            CargarOrden();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RealizarInformes.aspx");
        }
    }
}