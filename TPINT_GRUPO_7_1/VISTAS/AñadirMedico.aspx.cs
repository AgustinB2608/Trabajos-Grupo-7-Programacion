using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIO;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace VISTAS
{
    public partial class AddMedico : System.Web.UI.Page
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
                // Verificar si el usuario está logueado y traer los datos de la sesión (Administrador)
                if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
                {
                    string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                    string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                    string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                    lblUsuario.Text = $"{nombre} {apellido}";
                }
                else
                {
                   // Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
                }

                // Validar si ya hay un código de médico registrado en la sesión
                if (Session["CodMedico"] != null)
                {
                    string codMedico = Session["CodMedico"].ToString();
                }

                // Inicializar los dropdowns
                InicializarDropDownLists();
            }
        }

        private void InicializarDropDownLists()
        {
            // Configuración de ddlSexo
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Otro", "O"));
            ddlSexo.Items.Insert(0, new ListItem("Seleccionar Sexo", "0"));


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
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccionar Localidad", "0"));

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

            // Validación solo digitos y máximo 15 caracteres
            if (!SoloDigitos(txtCelular.Text) || txtCelular.Text.Length > 15)
            {
                lblError.Text = "El número de celular es inválido.";
                return;
            }

            // Validación solo dígitos y 8 caracteres 
            if (!SoloDigitos(txtDni.Text) || txtDni.Text.Length != 8)
            {
                lblError.Text = "El DNI es inválido.";
                return;
            }

            // Validación de la fecha de nacimiento
            int dia = 0, mes = 0, año = 0;

            if (!int.TryParse(ddlDia.SelectedValue, out dia) || dia == 0)
            {
                lblError.Text = "Debe seleccionar un día válido.";
                return;
            }

            if (!int.TryParse(ddlMes.SelectedValue, out mes) || mes == 0)
            {
                lblError.Text = "Debe seleccionar un mes válido.";
                return;
            }

            if (!int.TryParse(ddlAño.SelectedValue, out año) || año == 0)
            {
                lblError.Text = "Debe seleccionar un año válido.";
                return;
            }

            DateTime fechaNacimiento;
            if (!ValidateFechaNacimiento(out fechaNacimiento))
            {
                return;
            }

            // Creación del médico
            reg.setNombre(txtNombre.Text.Trim());
            reg.setApellido(txtApellido.Text.Trim());
            reg.setDni(txtDni.Text.Trim());
            reg.setEmail(txtEmail.Text.Trim());
            reg.setCelular(txtCelular.Text.Trim());
            reg.setNacionalidad(txtNacionalidad.Text.Trim());
            reg.setFechaNacimiento(fechaNacimiento.ToString("yyyy/MM/dd"));
            reg.setDireccion(txtDireccion.Text.Trim());
            reg.setProvincia(ddlProvincia.SelectedValue);
            reg.setLocalidad(ddlLocalidad.SelectedValue);
            reg.setSexo(ddlSexo.SelectedValue);
            reg.setEspecialidad(ddlEspecialidad.SelectedValue);
            reg.setHorario(ddlHorario.SelectedValue);
            reg.setDiasAtencion(ddlDiasAtencion.SelectedValue);

            bool exito = negM.agregarMedico(reg);

            if (exito)
            {
                // Obtener el código del médico recién agregado
                DataTable dt = negM.RetornarCodMedico(txtDni.Text);

                string codmed = dt.Rows.Count > 0 ? dt.Rows[0]["CodMedico"].ToString() : null;

                if (!string.IsNullOrEmpty(codmed))
                {
                    // Guardar el código del médico en la sesión
                    Session["CodMedico"] = codmed;

                    // Redirigir a la página de creación de usuario
                    Response.Redirect("UsuarioMedico.aspx");
                }
                else
                {
                    lblError.Text = "Error al obtener el código del médico. Verifique que el médico fue registrado correctamente.";
                }
            }
            else
            {
                lblError.Text = "Ocurrió un error al intentar agregar el médico.";
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

        



        protected void LimpiarCampos()
        {
            // Limpiar los campos de texto
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";

            // Limpiar los DropDownLists
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            ddlHorario.SelectedIndex = 0;
            ddlDiasAtencion.SelectedIndex = 0;
            ddlDia.SelectedIndex = 0;
            ddlMes.SelectedIndex = 0;
            ddlAño.SelectedIndex = 0;
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
                     string.IsNullOrWhiteSpace(txtDireccion.Text));
        } // Valida que los campos no estén vacíos

        private void CargarFechaNacimiento()
        {
            // Cargar días
            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

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

        private bool ValidateFechaNacimiento(out DateTime fechaNacimiento)
        {
            int dia = 0, mes = 0, año = 0;
            if (!int.TryParse(ddlDia.SelectedValue, out dia) || dia == 0 ||
                !int.TryParse(ddlMes.SelectedValue, out mes) || mes == 0 ||
                !int.TryParse(ddlAño.SelectedValue, out año) || año == 0)
            {
                lblError.Text = "Debe seleccionar una fecha de nacimiento válida.";
                fechaNacimiento = DateTime.MinValue;
                return false;
            }

            string fecha = $"{año}/{mes}/{dia}";
            if (!DateTime.TryParse(fecha, out fechaNacimiento))
            {
                lblError.Text = "La fecha ingresada no es válida.";
                return false;
            }

            // Validate date range
            if (fechaNacimiento < new DateTime(1900, 1, 1) || fechaNacimiento > DateTime.Now)
            {
                lblError.Text = "La fecha de nacimiento debe estar entre el 1/1/1900 y la fecha actual.";
                return false;
            }

            return true;
        }


        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLMedicos.aspx");
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
            catch (Exception)
            {
                // Muestra un mensaje de error en caso de fallas
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("Error al cargar localidades", "0"));

            }
        }
    }
}
