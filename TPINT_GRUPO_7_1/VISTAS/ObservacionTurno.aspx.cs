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
            NegocioTurnos negT = new NegocioTurnos();


        }
    }
}
