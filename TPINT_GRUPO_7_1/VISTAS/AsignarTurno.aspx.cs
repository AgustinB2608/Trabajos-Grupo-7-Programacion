using NEGOCIOS;
using System.Web.UI.WebControls;
using System;

namespace VISTAS
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        NegocioMedico negM = new NegocioMedico();
        NegocioHorarios negH = new NegocioHorarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarDropDownLists();
            }
        }

        private void InicializarDropDownLists()
        {
            // Configuración de ddlMedico
            //ddlMedico.DataSource = negM.ObtenerMedico();
            //ddlMedico.DataTextField = "CodMedico";
            //ddlMedico.DataValueField = "Nombre";
            //ddlMedico.DataBind();
            //ddlMedico.Items.Insert(0, new ListItem("Seleccione un medico para asignar turno", "0"));

            // Configuración de ddlHorario
            //ddlHorario.DataSource = negH.ObtenerHorarios();
            //ddlHorario.DataTextField = "Horario";
            //ddlHorario.DataValueField = "IdHorario";
            //ddlHorario.DataBind();
            //ddlHorario.Items.Insert(0, new ListItem("Seleccione un horario para turno", "0"));
        }
    }
}
