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

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioEspecialidades negocioEspecialidades = new NegocioEspecialidades();
            NegocioTurnos negocioTurnos = new NegocioTurnos();

            string estadoSeleccionado = ddlEstado.SelectedItem.Value;
            string especialidadSeleccionada = ddlEspecialidad.SelectedItem.Text;

            // Verificar si ambos son valores por defecto
            if (estadoSeleccionado == "0" && especialidadSeleccionada == "Seleccione una especialidad")
            {
                // Si ambos están vacíos, mostrar todos los turnos
                var todosTurnos = negocioTurnos.ObtenerTurnos(); // Este método debe devolver todos los turnos sin filtros
                gvTurnos.DataSource = todosTurnos;
                gvTurnos.DataBind();
                return;
            }

            // Si solo se seleccionó "Seleccione una especialidad"
            if (especialidadSeleccionada == "Seleccione una especialidad")
            {
                if (estadoSeleccionado == "0") // Si no hay estado seleccionado, limpiar el GridView
                {
                    gvTurnos.DataSource = null;
                    gvTurnos.DataBind();
                    return;
                }

                // Mostrar turnos filtrados solo por estado
                var turnosPorEstado = negocioTurnos.ObtenerTurnosPorEstado(estadoSeleccionado);
                gvTurnos.DataSource = turnosPorEstado;
                gvTurnos.DataBind();
                return;
            }

            // Si solo se seleccionó "Seleccione estado"
            if (estadoSeleccionado == "0") // Mostrar turnos solo por especialidad
            {
                var turnosPorEspecialidad = negocioEspecialidades.ObtenerTurnosPorEspecialidad(especialidadSeleccionada);
                gvTurnos.DataSource = turnosPorEspecialidad;
                gvTurnos.DataBind();
            }
            else // Mostrar turnos por especialidad y estado
            {
                var turnos = negocioTurnos.ObtenerTurnosPorEspYEst(especialidadSeleccionada, estadoSeleccionado);
                gvTurnos.DataSource = turnos;
                gvTurnos.DataBind();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioTurnos negocioTurnos = new NegocioTurnos();
            NegocioEspecialidades negocioEspecialidades = new NegocioEspecialidades();

            string estadoSeleccionado = ddlEstado.SelectedItem.Value;
            string especialidadSeleccionada = ddlEspecialidad.SelectedItem.Text;

            // Verificar si ambos son valores por defecto
            if (estadoSeleccionado == "0" && especialidadSeleccionada == "Seleccione una especialidad")
            {
                // Si ambos están vacíos, mostrar todos los turnos
                var todosTurnos = negocioTurnos.ObtenerTurnos(); // Este método debe devolver todos los turnos sin filtros
                gvTurnos.DataSource = todosTurnos;
                gvTurnos.DataBind();
                return;
            }

            // Si la especialidad es "Seleccione una especialidad"
            if (especialidadSeleccionada == "Seleccione una especialidad")
            {
                if (estadoSeleccionado == "0") // Si no hay estado seleccionado, limpiar el GridView
                {
                    gvTurnos.DataSource = null;
                    gvTurnos.DataBind();
                    return;
                }

                // Mostrar turnos filtrados solo por estado
                var turnosPorEstado = negocioTurnos.ObtenerTurnosPorEstado(estadoSeleccionado);
                gvTurnos.DataSource = turnosPorEstado;
                gvTurnos.DataBind();
                return;
            }

            // Si la especialidad está seleccionada
            if (estadoSeleccionado == "0") // Mostrar turnos solo por especialidad
            {
                var turnosPorEspecialidad = negocioEspecialidades.ObtenerTurnosPorEspecialidad(especialidadSeleccionada);
                gvTurnos.DataSource = turnosPorEspecialidad;
                gvTurnos.DataBind();
            }
            else // Mostrar turnos por especialidad y estado
            {
                var turnos = negocioTurnos.ObtenerTurnosPorEspYEst(especialidadSeleccionada, estadoSeleccionado);
                gvTurnos.DataSource = turnos;
                gvTurnos.DataBind();
            }
        }
    }
}