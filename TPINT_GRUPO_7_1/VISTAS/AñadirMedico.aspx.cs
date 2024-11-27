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
                    //Response.Redirect("InicioLogin.aspx");
                }
                // VALIDACION DE USUARIO LOGUEADO (ADMINISTRADOR)

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

            // Validación de la fecha de nacimiento
            int dia = 0, mes = 0, año = 0;

            // Obtener valores seleccionados de los DropDownLists de fecha
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

            // Crear la fecha a partir de los valores seleccionados
            string fecha = string.Concat(año,"/",mes,"/",dia);

            DateTime fechaNacimiento;
            if (!DateTime.TryParse(fecha, out fechaNacimiento))
            {
                lblError.Text = "La fecha ingresada no es válida.";
                return;
            }

            // Validar que la fecha esté dentro de los rangos permitidos
            if (fechaNacimiento < new DateTime(1900, 1, 1) || fechaNacimiento > DateTime.Now)
            {
                lblError.Text = "La fecha de nacimiento debe estar entre el 1/1/1900 y la fecha actual.";
                return;
            }
            // Creación del médico
            reg.setNombre(txtNombre.Text.Trim());
            reg.setApellido(txtApellido.Text.Trim());
            reg.setDni(txtDni.Text.Trim());
            reg.setEmail(txtEmail.Text.Trim());
            reg.setCelular(txtCelular.Text.Trim());
            reg.setNacionalidad(txtNacionalidad.Text.Trim());
            reg.setFechaNacimiento(fecha);
            reg.setDireccion(txtDireccion.Text.Trim());
            reg.setProvincia(ddlProvincia.SelectedValue);
            reg.setLocalidad(ddlLocalidad.SelectedValue);
            reg.setSexo(ddlSexo.SelectedValue);
            reg.setEspecialidad(ddlEspecialidad.SelectedValue);
            reg.setHorario(ddlHorario.SelectedValue);
            reg.setDiasAtencion(ddlDiasAtencion.SelectedValue);

            colums.Style.Add("display", "none");
            Confirmacion.Style.Add("display", "block");

        }

        // Método para crear un usuario
        private void CrearUsuario(string legajo, string contraseña, string nombre, string apellido)
        {
            try
            {
                NegocioUsuarios negU = new NegocioUsuarios();
                negU.RegistrarUsuario(legajo, contraseña, nombre, apellido);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al crear el usuario: " + ex.Message;
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
            // 1) Validar que se haya seleccionado un día, mes y año
            if (ddlDia.SelectedValue == "0" || ddlMes.SelectedValue == "0" || ddlAño.SelectedValue == "0")
            {
                lblError.Text = "La fecha de nacimiento es incompleta.";
                return DateTime.MinValue;
            }

            try
            {
                // 2) Crear la fecha a partir de los valores seleccionados
                int dia = int.Parse(ddlDia.SelectedValue);
                int mes = int.Parse(ddlMes.SelectedValue);
                int año = int.Parse(ddlAño.SelectedValue);

                DateTime fechaNacimiento = new DateTime(año, mes, dia);

                // 3) Validar que la fecha no sea futura
                if (fechaNacimiento > DateTime.Now)
                {
                    lblError.Text = "La fecha de nacimiento no puede ser futura.";
                    return DateTime.MinValue;
                }

                // 4) Calcular la edad
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                    edad--;

                // 5) Validar edad mínima (18 años)
                if (edad < 18)
                {
                    lblError.Text = "El médico debe ser mayor de 18 años.";
                    return DateTime.MinValue;
                }

                // 6) Validar edad máxima (120 años)
                if (edad > 120)
                {
                    lblError.Text = "La edad ingresada no es válida.";
                    return DateTime.MinValue;
                }

                // 7) Validar que la fecha no sea muy antigua
                if (fechaNacimiento.Year < 1900)
                {
                    lblError.Text = "La fecha de nacimiento no puede ser tan antigua.";
                    return DateTime.MinValue;
                }

                // Si todas las validaciones son correctas, devolver la fecha de nacimiento
                return fechaNacimiento;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al validar la fecha de nacimiento: " + ex.Message;
                return DateTime.MinValue;
            }
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

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            negM.agregarMedico(reg);
            string codmed;

            /// solucionar usuario

            if (negM.agregarMedico(reg))
            {
                // Crear usuario asociado
                NegocioMedico med = new NegocioMedico();
                DataTable dt = med.RetornarCodMedico(txtDni.Text);

                if (dt.Rows.Count > 0)
                {
                    // Retornar el valor de la primera fila y columna
                    codmed = dt.Rows[0]["CodMedico"].ToString();
                }
                else
                {

                    codmed = null;
                }

                CrearUsuario(codmed, txtDni.Text, txtNombre.Text, txtApellido.Text);
                
                LimpiarCampos();
            }

            Confirmacion.Style.Add("display", "none");
            h1.Style.Add("display", "none");
            mensajeConfirmacion.Style.Add("display", "block");

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            colums.Style.Add("display", "column");
            Confirmacion.Style.Add("display", "none");
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
