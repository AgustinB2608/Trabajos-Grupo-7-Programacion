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

            // Validación 
            if (!ValidarCamposVacios())
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (!ValidarSeleccionDropDown(ddlProvincia, "Debe seleccionar una provincia.") ||
                !ValidarSeleccionDropDown(ddlLocalidad, "Debe seleccionar una localidad.") ||
                !ValidarSeleccionDropDown(ddlSexo, "Debe seleccionar un sexo."))
            {
                return;
            }

            // Validación de formato de correo electrónico
            if (!CorreoValido(txtEmail.Text))
            {
                lblMensaje.Text = "El formato del correo electrónico es inválido.";
                return;
            }

            // Validación solo digitos y maximo 15 caracteres
            if (!SoloDigitos(txtCelular.Text) || txtCelular.Text.Length > 15)
            {
                lblMensaje.Text = "El número de celular es inválido.";
                return;
            }

            // Validación solo digitos y 8 caracteres 
            if (!SoloDigitos(txtDni.Text) || txtDni.Text.Length != 8)
            {
                lblMensaje.Text = "El DNI es invalido";
                return;
            }

            // Validación de la fecha de nacimiento
            int dia = 0, mes = 0, año = 0;

            // Obtener valores seleccionados de los DropDownLists de fecha
            if (!int.TryParse(ddlDia.SelectedValue, out dia) || dia == 0)
            {
                lblMensaje.Text = "Debe seleccionar un día válido.";
                return;
            }

            if (!int.TryParse(ddlMes.SelectedValue, out mes) || mes == 0)
            {
                lblMensaje.Text = "Debe seleccionar un mes válido.";
                return;
            }

            if (!int.TryParse(ddlAño.SelectedValue, out año) || año == 0)
            {
                lblMensaje.Text = "Debe seleccionar un año válido.";
                return;
            }

            // Crear la fecha a partir de los valores seleccionados
            string fecha = string.Concat(año, "-", mes, "-", dia);

            DateTime fechaNacimiento;

            if (!ValidateFechaNacimiento(out fechaNacimiento))
            {
                return;
            }

            // Crear una instancia de Pacientes y asignar los valores de los controles del formulario
            Pacientes nuevoPaciente = new Pacientes();

            nuevoPaciente.Dni = (txtDni.Text.Trim().ToString());
            nuevoPaciente.Nombre = (txtNombre.Text.Trim().ToString());
            nuevoPaciente.Apellido = (txtApellido.Text.Trim().ToString());
            nuevoPaciente.Direccion = (txtDireccion.Text.Trim().ToString());
            nuevoPaciente.Localidad = (ddlLocalidad.SelectedValue);
            nuevoPaciente.Provincia = (ddlProvincia.SelectedValue);
            nuevoPaciente.Email = (txtEmail.Text.Trim().ToString());
            nuevoPaciente.Celular = (txtCelular.Text.Trim().ToString());
            nuevoPaciente.Sexo = (ddlSexo.SelectedValue);
            nuevoPaciente.Nacionalidad = (txtNacionalidad.Text.Trim().ToString());
            nuevoPaciente.FechaNacimiento = (fechaNacimiento.ToString("yyyy-MM-dd"));


            // Llamar al método de negocio para agregar el paciente

            if (negocioPacientes.AgregarPaciente(nuevoPaciente))
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "¡Paciente agregado exitosamente!";
                lblMensaje.CssClass = "mensaje-exito";
                LimpiarCampos();
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Error al agregar el paciente.";
                lblMensaje.CssClass = "mensaje-error";
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar todos los campos después de guardar
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = ""; 
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlDia.SelectedIndex = 0;
            ddlMes.SelectedIndex = 0;
            ddlAño.SelectedIndex = 0;
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
            ddlProvincia.Items.Insert(0, new ListItem("Seleccionar Provincia", "0"));

            // Configuración de ddlLocalidad
            ddlLocalidad.DataSource = negL.ObtenerLocalidad();
            ddlLocalidad.DataTextField = "descripcionLocalidad1";
            ddlLocalidad.DataValueField = "id_Localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccionar Localidad", "0"));

            // Configuración de ddlSexo
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
            ddlSexo.Items.Insert(0, new ListItem("Seleccionar Sexo", "0"));

            CargarFechaNacimiento();
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

        private void CargarFechaNacimiento()
        {
         
            // Cargar meses
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

            // Cargar años
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1900; i--)
            {
                ddlAño.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

           
        }

        private bool ValidarCamposVacios()
        {
            return !(string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text)) ;
            // Valida que los campos no estén vacíos
        }
        private bool ValidarSeleccionDropDown(DropDownList ddl, string mensajeError)
        {
            if (ddl.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddl.SelectedValue))
            {
                lblMensaje.Text = mensajeError;
                return false;
            }
            return true;
        } // Valida que el dropdown tenga un valor seleccionado

        private bool CorreoValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email); //signa el email a una variable de tipo MailAddress
                return addr.Address == email; //retorna true si el email es valido
            }
            catch //Si el email no es valido, se captura la excepcion y se retorna false
            {
                return false;
            }
        }/// valida correo

        // Método para validar que el texto contenga solo dígitos, retorna true si es valido, false si no lo es. 
        private bool SoloDigitos(string str)
        {
            return str.All(Char.IsDigit); //La funcion usa el metodo All para validar que todos los caracteres sean digitos con IsDigit
        }

        private bool ValidateFechaNacimiento(out DateTime fechaNacimiento)
        {
            int dia = 0, mes = 0, año = 0;
            if (!int.TryParse(ddlDia.SelectedValue, out dia) || dia == 0 ||
                !int.TryParse(ddlMes.SelectedValue, out mes) || mes == 0 ||
                !int.TryParse(ddlAño.SelectedValue, out año) || año == 0)
            {
                lblMensaje.Text = "Debe seleccionar una fecha de nacimiento válida.";
                fechaNacimiento = DateTime.MinValue;
                return false;
            }

            string fecha = $"{año}/{mes}/{dia}";
            if (!DateTime.TryParse(fecha, out fechaNacimiento))
            {
                lblMensaje.Text = "La fecha ingresada no es válida.";
                return false;
            }

            // Validate date range
            if (fechaNacimiento < new DateTime(1900, 1, 1) || fechaNacimiento > DateTime.Now)
            {
                lblMensaje.Text = "La fecha de nacimiento debe estar entre el 1/1/1900 y la fecha actual.";
                return false;
            }

            return true;
        }
    }

}
