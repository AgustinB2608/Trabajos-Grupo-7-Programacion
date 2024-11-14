using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class AddMedico : System.Web.UI.Page
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

                 //Verificar si el usuario está logueado y traer los datos de la session(Administrador)
        
                if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
                {
                    string nombre = Session["UsuarioNombre"].ToString();//Nombre
                    string apellido = Session["UsuarioApellido"].ToString();//Apellido
                    string tipoUsuario = Session["UsuarioTipo"].ToString();//Tipo de usuario

                    lblUsuario.Text = $"{nombre} {apellido}";
                }
                else
                {
                    Response.Redirect("InicioLogin.aspx");
                } 
                // VALIDACION DE USUARIO LOGUEADO (ADMINISTRADOR)

                InicializarDropDownLists();

            } 
        }

        private void InicializarDropDownLists()
        {
            // Configuración de ddlSexo
            ddlSexo.DataSource = negS.ObtenerSexo();
            ddlSexo.DataTextField = "DescripcionSexo_SX";
            ddlSexo.DataValueField = "CodSexo_SX";
            ddlSexo.DataBind();
            ddlSexo.Items.Insert(0, new ListItem("Seleccionar el sexo", "0"));


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
            ddlLocalidad.Items.Insert(0, new ListItem("SeleccionarLocalidad", "0"));

            // Configuración de ddlEspecialidad
            ddlEspecialidad.DataSource = negE.ObtenerNombresEspecialidades();
            ddlEspecialidad.DataTextField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataValueField = "NombreEspecialidad_ES";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));

            // Configuración de ddlDiasAtencion
            ddlDiasAtencion.DataSource = negD.ObtenerDiasAtencion();
            ddlDiasAtencion.DataTextField = "Dias";
            ddlDiasAtencion.DataValueField = "IdDia";
            ddlDiasAtencion.DataBind();
            ddlDiasAtencion.Items.Insert(0, new ListItem("Seleccionar Dia de atencion", "0"));

            // Configuración de ddlHorario
            ddlHorario.DataSource = negH.ObtenerHorarios();
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario";
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("Selecciona Horario de atencion", "0"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación 
            if (!ValidarCamposVacios())
            {
                lblError.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Validación Dropdowns
            if (!ValidarSeleccionDropDown(ddlProvincia, "Debe seleccionar una provincia.") ||
                !ValidarSeleccionDropDown(ddlLocalidad, "Debe seleccionar una localidad.") ||
                !ValidarSeleccionDropDown(ddlSexo, "Debe seleccionar un sexo.") ||
                !ValidarSeleccionDropDown(ddlEspecialidad, "Debe seleccionar una especialidad.") ||
                !ValidarSeleccionDropDown(ddlHorario, "Debe seleccionar un horario.") ||
                !ValidarSeleccionDropDown(ddlDiasAtencion, "Debe seleccionar los días de atención."))
            {
                return;
            }

            // Validación de formato de correo electrónico
            if (!CorreoValido(txtEmail.Text))
            {
                lblError.Text = "El formato del correo electrónico es inválido.";
                return;
            }

            // Validación solo digitos y maximo 15 caracteres
            if (!SoloDigitos(txtCelular.Text) || txtCelular.Text.Length > 15)
            {
                lblError.Text = "El número de celular es inválido.";
                return;
            }

            // Validación solo digitos y 8 caracteres 
            if (!SoloDigitos(txtDni.Text) || txtDni.Text.Length != 8)
            {
                lblError.Text = "El DNI es invalido";
                return;
            }

            // Validación de fecha de nacimiento
            DateTime fechaNacimiento = ValidarFechaNacimiento();
            if (fechaNacimiento == DateTime.MinValue)
            {
                lblError.Text = "La fecha de nacimiento es inválida.";
                return;
            }

            // Si todas las validaciones pasan guardamos todos los datos
            reg.setNombre(txtNombre.Text.Trim());
            reg.setApellido(txtApellido.Text.Trim());
            reg.setDni(txtDni.Text.Trim());
            reg.setEmail(txtEmail.Text.Trim());
            reg.setCelular(txtCelular.Text.Trim());
            reg.setNacionalidad(txtNacionalidad.Text.Trim());
            reg.setDireccion(txtDireccion.Text.Trim());
            reg.setCodMedico(txtMatricula.Text.Trim());
            reg.setProvincia(ddlProvincia.SelectedValue);
            reg.setLocalidad(ddlLocalidad.SelectedValue);
            reg.setSexo(ddlSexo.SelectedValue);
            reg.setEspecialidad(ddlEspecialidad.SelectedValue);
            reg.setHorario(ddlHorario.SelectedValue);
            reg.setDiasAtencion(ddlDiasAtencion.SelectedValue);

            // Convertir la fecha de nacimiento a string antes de guardar
            string fechaString = fechaNacimiento.ToString("dd/MM/yyyy");
            reg.setFechaNacimiento(fechaString);

            if (negM.agregarMedico(reg))
            {
                LimpiarCampos(); //Limpiar campos despues de añadir
            }
            else
            {
                lblError.Text = "Error al guardar el médico";
            }
        }

        //Funcion para validar el correo electronico, retorna true si es valido, false si no lo es (Correos validos como ejemplo@ejemplo.com) 
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
        }

        // Método para validar que el texto contenga solo dígitos, retorna true si es valido, false si no lo es. 
        private bool SoloDigitos(string str) //Parametro a checkear
        {
            return str.All(Char.IsDigit); //La funcion usa el metodo All para validar que todos los caracteres sean digitos con IsDigit
        }

        protected DateTime ValidarFechaNacimiento()
        {
            if (string.IsNullOrEmpty(txtFechaNacimiento.Text))
            {
                lblError.Text = "La fecha de nacimiento es requerida";
                return DateTime.MinValue;
            } //1) Validar que la fecha de nacimiento sea válida(no vacía)

            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                lblError.Text = "El formato de fecha no es válido";
                return DateTime.MinValue;
            } //2) Validar que la fecha de nacimiento sea válida (formato)

            // Validar que no sea fecha futura
            if (fechaNacimiento > DateTime.Now)
            {
                lblError.Text = "La edad ingresada no es válida";
                return DateTime.MinValue;
            } //3) Validar que la fecha de nacimiento no sea futura

            // Calcular edad 
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                edad--;

            // Validar edad mínima (18 años)
            if (edad < 18)
            {
                lblError.Text = "El médico debe ser mayor de 18 años";
                return DateTime.MinValue;
            } //4) Validar que la edad sea mayor a 18 años

            // Validar edad máxima (120 años)
            if (edad > 120)
            {
                lblError.Text = "La edad ingresada no es válida";
                return DateTime.MinValue;
            } //5) Validar que la edad sea menor a 120 años

            // Validar que la fecha no sea muy antigua
            if (fechaNacimiento.Year < 1900)
            {
                lblError.Text = "La edad ingresada no es válida";
                return DateTime.MinValue;
            } //6) Validar que la fecha no sea muy antigua para el año

            return fechaNacimiento; // Devuelve la fecha de nacimiento si pasa todas las validaciones
        }

        protected void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtFechaNacimiento.Text = "";

            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            ddlHorario.SelectedIndex = 0;
            ddlDiasAtencion.SelectedIndex = 0;
        }

        // Función para validar DropDownList
        private bool ValidarSeleccionDropDown(DropDownList ddl, string mensajeError)
        {
            if (ddl.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddl.SelectedValue))
            {
                lblError.Text = mensajeError;
                return false;
            }
            return true;
        } // Valida que el dropdown tenga un valor seleccionado

        // Función para validar campos vacíos
        private bool ValidarCamposVacios()
        {
            return !(string.IsNullOrWhiteSpace(txtNombre.Text) ||
                     string.IsNullOrWhiteSpace(txtApellido.Text) ||
                     string.IsNullOrWhiteSpace(txtDni.Text) ||
                     string.IsNullOrWhiteSpace(txtEmail.Text) ||
                     string.IsNullOrWhiteSpace(txtCelular.Text) ||
                     string.IsNullOrWhiteSpace(txtNacionalidad.Text) ||
                     string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                     string.IsNullOrWhiteSpace(txtMatricula.Text));
        } // Valida que los campos no estén vacíos

    }
}