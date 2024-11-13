using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIOS;

namespace VISTAS
{
    public partial class ABMLMedicos : System.Web.UI.Page
    {
        NegocioMedico negM = new NegocioMedico();
        NegocioSexo negS = new NegocioSexo();
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
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Asignar valores de TextBox
            reg.setNombre(txtNombre.Text.Trim());
            reg.setApellido(txtApellido.Text.Trim());
            reg.setDni(txtDni.Text.Trim());
            reg.setCodMedico(txtMatricula.Text.Trim());
            reg.setEmail(txtEmail.Text.Trim());
            reg.setCelular(txtCelular.Text.Trim());
            reg.setNacionalidad(txtNacionalidad.Text.Trim());
            reg.setDireccion(txtDireccion.Text.Trim());

            // Asignar valores de DropDownList
            reg.setProvincia(ddlProvincia.SelectedValue);
            reg.setLocalidad(ddlLocalidad.SelectedValue);
            reg.setSexo(ddlSexo.SelectedValue);
            reg.setEspecialidad(ddlEspecialidad.SelectedValue);
            reg.setHorario(ddlHorario.SelectedValue);
            reg.setDiasAtencion(ddlDiasAtencion.SelectedValue);

            //MIRAR ESTO DE LA FECHA PORQUE NO SE GUARDA!!!!!!
            string fechaNacimientoStr = fechaNacimiento.Value;
            fechaNacimientoStr = fechaNacimientoStr.Trim();
            DateTime fechaNacimientoParsed;
            string formatoFecha = "dd/MM/yyyy";

            if (DateTime.TryParseExact(fechaNacimientoStr, formatoFecha, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaNacimientoParsed))
            {
                reg.setFechaNacimiento(fechaNacimientoParsed.ToString("dd/MM/yyyy"));
            }
            else
            {
                lblMensaje.Text = "Fecha de nacimiento no válida. Usa el formato dd/MM/yyyy.";
            }

            // Llamar al método para guardar el registro
            bool exito = negM.agregarMedico(reg);

            if (exito)
            {
                lblMensaje.Text = "Médico añadido con éxito.";
            }
            else
            {
                lblMensaje.Text = "No se pudo añadir el médico.";
            }

            limpiarCampos();
        }





        private void InicializarDropDownLists()
        {
            // Configuración de ddlSexo
            ddlSexo.DataSource = negS.ObtenerSexo();
            ddlSexo.DataTextField = "DescripcionSexo_SX";
            ddlSexo.DataValueField = "CodSexo_SX";
            ddlSexo.DataBind();
            ddlSexo.Items.Insert(0, new ListItem("Seleccione sexo del medico", "0"));


            // Configuración de ddlProvincia
            ddlProvincia.DataSource = negP.ObtenerProvincias();
            ddlProvincia.DataTextField = "DescripcionProvincia1";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia", "0"));

            // Configuración de ddlLocalidad
            ddlLocalidad.DataSource = negL.ObtenerLocalidad();
            ddlLocalidad.DataTextField = "descripcionLocalidad1";
            ddlLocalidad.DataValueField = "id_Localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));

            // Configuración de ddlEspecialidad
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataValueField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));

            // Configuración de ddlDiasAtencion
            ddlDiasAtencion.DataSource = negD.ObtenerDiasAtencion();
            ddlDiasAtencion.DataTextField = "Dias";
            ddlDiasAtencion.DataValueField = "IdDia";
            ddlDiasAtencion.DataBind();
            ddlDiasAtencion.Items.Insert(0, new ListItem("Seleccione un dia de atencion", "0"));

            // Configuración de ddlHorario
            ddlHorario.DataSource = negH.ObtenerHorarios();
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario";
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("Seleccione un horario de atencion", "0"));
        }

        private void limpiarCampos()
        {
            // Limpiar TextBox
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtMatricula.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";

            // Limpiar DropDownList
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            ddlHorario.SelectedIndex = 0;
            ddlDiasAtencion.SelectedIndex = 0;
        }
    }
}