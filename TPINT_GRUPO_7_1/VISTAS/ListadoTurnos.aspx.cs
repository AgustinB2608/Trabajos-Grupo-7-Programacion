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
            if (!IsPostBack)
            {
                CargarTurnos();
                CargarEspecialidades();
               
            }
        }
        protected void CargarTurnos()
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

        

    }
}