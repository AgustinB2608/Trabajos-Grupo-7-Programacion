using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class ABMLPacientes : System.Web.UI.Page
        //instancia negociopaciente
    {
        NegocioPacientes negocioPacientes = new NegocioPacientes();
        NegocioProvincia negP = new NegocioProvincia();
        NegocioLocalidades negL = new NegocioLocalidades();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InicializarDropDownLists();
            }
        }
        // El boton guardar se encarga de recopilar toda la informacion escrita por el usuario para asi guardarla en la base de datos.
        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            // Genera un código único para el paciente
            string codPaciente = "m" + DateTime.Now.ToString("yyMMdd");

            // Crear una instancia de Pacientes y asignar los valores de los controles del formulario
            Pacientes nuevoPaciente = new Pacientes
            {
                codPaciente = codPaciente,
                Dni = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Calendar1.SelectedDate.ToString("yyyy-MM-dd"),
                Direccion = txtDireccion.Text, 
                Localidad = ddlLocalidad.SelectedValue,
                Provincia = ddlProvincia.SelectedValue,
                Email = txtEmail.Text,
                Celular = txtCelular.Text,
                Sexo = ddlSexo.SelectedValue, 
                Nacionalidad = txtNacionalidad.Text, 
                Estado = true // Estado activo por defecto
            };

            // Llamar al método de negocio para agregar el paciente

            bool exito = negocioPacientes.AgregarPaciente(nuevoPaciente);

            if (exito)
            {
                LimpiarCampos();
                lblMensajeConfirmacion.Text = "¡Paciente agregado exitosamente!";
                lblMensajeConfirmacion.CssClass = "mensaje-exito";
                lblMensajeConfirmacion.Visible = true;
            }
            else
            {
                lblMensajeConfirmacion.Text = "Error al agregar el paciente.";
                lblMensajeConfirmacion.CssClass = "mensaje-error";
                lblMensajeConfirmacion.Visible = true;
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar todos los campos después de guardar
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            Calendar1.SelectedDate = DateTime.MinValue; 
            txtDireccion.Text = ""; 
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            txtEmail.Text = ""; 
            txtCelular.Text = ""; 
        }


        private void InicializarDropDownLists()
        {
            
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

            // Configuración de ddlSexo
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
            ddlSexo.Items.Insert(0, new ListItem("Seleccionar el sexo", "0"));



        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProvincia = ddlProvincia.SelectedValue;

            // Verificar si se seleccionó una provincia válida
            if (string.IsNullOrEmpty(idProvincia) || idProvincia == "0")
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("Seleccionar Localidad", "0"));
                return;
            }

            try
            {
                // Obtener localidades filtradas por la provincia seleccionada
                List<Localidades> localidades = new NegocioLocalidades().ObtenerLocalidadesPorProvincia(idProvincia);

                // Limpiar y cargar el DropDownList de localidades
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("Seleccionar Localidad", "0"));

                if (localidades.Count > 0)
                {
                    foreach (var loc in localidades)
                    {
                        ddlLocalidad.Items.Add(new ListItem(loc.DescripcionLocalidad1, loc.Id_Localidad));
                    }
                }
                else
                {
                    ddlLocalidad.Items.Add(new ListItem("No hay localidades disponibles", "0"));
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error en caso de fallas
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("Error al cargar localidades", "0"));
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}