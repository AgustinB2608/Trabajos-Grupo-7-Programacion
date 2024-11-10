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
        private NegocioPacientes negocioPacientes = new NegocioPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        // El boton guardar se encarga de recopilar toda la informacion escrita por el usuario para asi guardarla en la base de datos.
        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            // Genera un código único para el paciente
            string codPaciente = "o" + DateTime.Now.ToString("yyMMdd");

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
                lblMensaje.Text = "Paciente agregado exitosamente.";
                LimpiarCampos();
            }
            else
            {
                lblMensaje.Text = "Error al agregar el paciente.";
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
    }
}
