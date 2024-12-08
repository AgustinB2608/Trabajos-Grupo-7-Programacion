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
        NegocioReportes negR = new NegocioReportes();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMeses();
        }

        /*
         Estadísticas de Asistencia y Ausencia: Comparativo Mensual

        Informará el porcentaje correspondiente a determinado mes. Porcentaje de ausentes y presentes, 
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
        
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InicioReportes.aspx");
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mes = ddlMes.SelectedValue;

            int total = totalturnosmes(mes);

            if (total > 0)
            {
                int totalAusentes = totalturnosEstado(mes, "A");
                int totalPresentes = totalturnosEstado(mes, "P");
                
                float resultadoP = (float)((totalPresentes * 100) / total);
                float resultadoA = (float)((totalAusentes * 100) / total);

                txtAsistencia.Text = resultadoP.ToString("F2") + "%";
                txtAusencia.Text = resultadoA.ToString("F2") + "%";
            }
            else
            {
                //cartel indicando que no hubo turnos en el mes seleccionado
                lblMensaje.Text = "No hubo turnos en el mes seleccionado.";
                return;
            }

            datosGv(mes);
        }

        //funciones

        public int totalturnosmes (string mes)
        {
            int tt = 0; // Total de turnos en el mes
            
            // Obtener el total de turnos del mes seleccionado
            DataTable dt = negR.TotalTurnosMes(mes);

            if (dt.Rows.Count > 0)
            {
                tt = int.Parse(dt.Rows[0]["Turnos Totales"].ToString());
            }
            return tt;
        }

        public int totalturnosEstado (string mes, string estado)
        {
            int total = 0; // Total de turnos

            DataTable da = negR.TotalTurnosSegunEstadoyMes(mes, estado);

            if (da.Rows.Count > 0)
            {
                total = int.Parse(da.Rows[0]["Total"].ToString());
            }
            return total;
        }

        public void datosGv(string mes)
        {
            DataTable dtAusentes = negR.ObtenerPacientesMes(mes, "A");
            DataTable dtPresentes = negR.ObtenerPacientesMes(mes, "P");

            // Unir DataTable en uno solo
            DataTable dtFinal = dtAusentes.Copy(); // Copiamos la estructura y los datos de ausentes

            if (dtPresentes.Rows.Count > 0)
            {
                dtFinal.Merge(dtPresentes); // Unimos los datos de presentes
            }


            if (dtFinal.Rows.Count > 0)
            {
                grvEstadistica.DataSource = dtFinal;
                grvEstadistica.DataBind();
            }
            else
            {
                grvEstadistica.DataSource = null;
                grvEstadistica.DataBind();
                lblMensaje.Text = "No se encontraron datos para el mes seleccionado.";
            }
        }
    }
}