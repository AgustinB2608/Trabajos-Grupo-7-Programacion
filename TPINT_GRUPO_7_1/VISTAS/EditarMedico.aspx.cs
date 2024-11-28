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
    public partial class EditarMedico : System.Web.UI.Page
    {
        NegocioMedico negM = new NegocioMedico();
        NegocioProvincia negP = new NegocioProvincia();
        NegocioLocalidades negL = new NegocioLocalidades();
        NegocioEspecialidades negE = new NegocioEspecialidades();
        NegocioDiasAtencion negD = new NegocioDiasAtencion();
        NegocioHorarios negH = new NegocioHorarios();
        Medico reg = new Medico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarDropDownLists();
                if (Request.QueryString["codigo"] != null)
                {
                    string codigoMedico = Request.QueryString["codigo"];
                    //CargarDatosMedico(codigoMedico);
                }
            }
        }
        private void InicializarDropDownLists()
        {
            // Configuración de ddlSexo
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
            ddlSexo.Items.Insert(0, new ListItem("Seleccionar el sexo", "0"));


            // Configuración de ddlProvincia
            ddlProvincia.DataSource = negP.ObtenerProvincias();
            ddlProvincia.DataTextField = "DescripcionProvincia1";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("Seleccionar Provincia", "0"));


            // Configuración de ddlLocalidad
            ddlLocalidad.DataSource = negL.ObtenerLocalidad();
            ddlLocalidad.DataTextField = "DescripcionLocalidad1";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("SeleccionarLocalidad", "0"));

            // Configuración de ddlEspecialidad
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));

            // Configuración de ddlDiasAtencion
            ddlDiasAtencion.DataSource = negD.ObtenerDiasAtencion();
            ddlDiasAtencion.DataTextField = "Descripcion";
            ddlDiasAtencion.DataValueField = "IdDias";
            ddlDiasAtencion.DataBind();
            ddlDiasAtencion.Items.Insert(0, new ListItem("Seleccionar dias de atencion", "0"));

            // Configuración de ddlHorario
            ddlHorario.DataSource = negH.ObtenerHorarios();
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario";
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("Selecciona horario de atencion", "0"));

            // Cargar días, meses y años para la fecha de nacimiento
            CargarFechaNacimiento();

        }
       /* HAY QUE ACOMODARLO CON LOS AS DE LAS COLUMNAS, IGUAL YA HAY UN METODO QUE LO HACE ASI!!!! USAR EL OTRO
        * private void CargarDatosMedico(string codigoMedico)
        {
            // Método para obtener los datos del médico
            DataTable dt = negM.ObtenerMedicoPorCodigo(codigoMedico);

            if (dt.Rows.Count > 0)
            {
                // Asigna los datos de la tabla a los controles
                txtNombre.Text = dt.Rows[0]["Nombre_ME"].ToString();
                txtApellido.Text = dt.Rows[0]["Apellido_ME"].ToString();
                txtDni.Text = dt.Rows[0]["DNI_ME"].ToString();
                txtEmail.Text = dt.Rows[0]["Email_ME"].ToString();
                txtCelular.Text = dt.Rows[0]["Telefono_ME"].ToString();
                txtNacionalidad.Text = dt.Rows[0]["Nacionalidad_ME"].ToString();
                txtDireccion.Text = dt.Rows[0]["Direccion_ME"].ToString();

                // Configura los dropdowns para la fecha de nacimiento
                ddlDia.SelectedValue = Convert.ToDateTime(dt.Rows[0]["FechaNacimiento_ME"]).Day.ToString();
                ddlMes.SelectedValue = Convert.ToDateTime(dt.Rows[0]["FechaNacimiento_ME"]).Month.ToString();
                ddlAño.SelectedValue = Convert.ToDateTime(dt.Rows[0]["FechaNacimiento_ME"]).Year.ToString();

                // Configura el resto de los ddl
                ddlSexo.SelectedValue = dt.Rows[0]["Sexo_ME"].ToString();
                ddlProvincia.SelectedValue = dt.Rows[0]["CodProvincia_ME"].ToString();
                ddlLocalidad.SelectedValue = dt.Rows[0]["CodLocalidad_ME"].ToString();
                ddlEspecialidad.SelectedValue = dt.Rows[0]["CodEspecialidad_ME"].ToString();
                ddlDiasAtencion.SelectedValue = dt.Rows[0]["CodDiasAtencion_ME"].ToString();
                ddlHorario.SelectedValue = dt.Rows[0]["CodHorariosAtencion_ME"].ToString();
            }
        }*/

        private void CargarFechaNacimiento()
        {
            // Cargar días
            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            // Cargar meses
            ddlMes.Items.Add(new ListItem("Enero", "1"));
            ddlMes.Items.Add(new ListItem("Febrero", "2"));
            ddlMes.Items.Add(new ListItem("Marzo", "3"));
            ddlMes.Items.Add(new ListItem("Abril", "4"));
            ddlMes.Items.Add(new ListItem("Mayo", "5"));
            ddlMes.Items.Add(new ListItem("Junio", "6"));
            ddlMes.Items.Add(new ListItem("Julio", "7"));
            ddlMes.Items.Add(new ListItem("Agosto", "8"));
            ddlMes.Items.Add(new ListItem("Septiembre", "9"));
            ddlMes.Items.Add(new ListItem("Octubre", "10"));
            ddlMes.Items.Add(new ListItem("Noviembre", "11"));
            ddlMes.Items.Add(new ListItem("Diciembre", "12"));

            // Cargar años
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1900; i--)
            {
                ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ddlDia.Items.Insert(0, new ListItem("Seleccionar Día", "0"));
            ddlMes.Items.Insert(0, new ListItem("Seleccionar Mes", "0"));
            ddlAño.Items.Insert(0, new ListItem("Seleccionar Año", "0"));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");
        }
    }
}