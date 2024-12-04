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
    public partial class ModificarMedico : System.Web.UI.Page
    {
        NegocioProvincia negP = new NegocioProvincia();
        NegocioLocalidades negL = new NegocioLocalidades();
        NegocioEspecialidades negE = new NegocioEspecialidades();
        NegocioDiasAtencion negD = new NegocioDiasAtencion();
        NegocioHorarios negH = new NegocioHorarios();

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


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblErrorBusqueda.Text = "";
            lblError.Text = "";
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un Codigo.";
                return;
            }
            //Si la longitud es 4, busca por CODIGO MEDICO
            if (txtBuscar.Text.Length == 4)
            {
                CargarDatosMedicoPorCodigo();
            }
            //Si la longitud es 8, busca por DNI
            else if (txtBuscar.Text.Length == 8)
            {
                CargarDatosMedicoPorDni();
            }

            //Si no cumple ninguna de las condiciones anteriores, muestra un mensaje de error
            else
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un Codigo de Medico.";
            }

            txtBuscar.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtFechaNacimiento.Text)
                || string.IsNullOrWhiteSpace(ddlProvincia.SelectedValue) || string.IsNullOrWhiteSpace(ddlLocalidad.SelectedValue) || string.IsNullOrWhiteSpace(ddlEspecialidad.SelectedValue) || string.IsNullOrWhiteSpace(ddlDiasAtencion.SelectedValue) || string.IsNullOrWhiteSpace(ddlHorario.SelectedValue))
            {
                lblError.Text = "Por favor, complete todos los campos.";
                return;
            }

            NegocioMedico negocio = new NegocioMedico();
            Medico medico = new Medico();

            DateTime fechaNacimiento;
            DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento);
            medico.setCodMedico(txtCodigo.Text.ToString());
            medico.setNombre(txtNombre.Text.ToString());
            medico.setApellido(txtApellido.Text.ToString());
            medico.setSexo(ddlSexo.SelectedValue);
            medico.setNacionalidad(txtNacionalidad.Text.ToString());
            medico.setFechaNacimiento(fechaNacimiento.ToString("yyyy-MM-dd"));
            medico.setDireccion(txtDireccion.Text.ToString());
            medico.setLocalidad(ddlLocalidad.SelectedValue.ToString());
            medico.setProvincia(ddlProvincia.SelectedValue.ToString());
            medico.setEmail(txtEmail.Text.ToString());
            medico.setCelular(txtCelular.Text.ToString());
            medico.setEspecialidad(ddlEspecialidad.SelectedValue.ToString());
            medico.setDiasAtencion(ddlDiasAtencion.SelectedValue.ToString());
            medico.setHorario(ddlHorario.SelectedValue.ToString());

            if (negocio.modificarMedico(medico))
            {

                lblExito.Text = "Médico modificado correctamente.";
                LimpiarCampos();
            }
            else
            {

                lblError.Text = "Error al modificar Médico. ";
            }
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");

        }

        private void CargarDatosMedicoPorCodigo()
        {
            NegocioMedico negM = new NegocioMedico();
            Medico reg = new Medico();
            if (txtBuscar.Text.Length == 4)
            {
                DataTable medico = negM.listarMedicoEspecifico(txtBuscar.Text);

                if (medico.Rows.Count > 0) //Validad que hayan datos para mostrar
                {
                    reg.CodMedico = medico.Rows[0]["CodigoMedico"].ToString(); //Asigna el codigo del medico buscado a codMedico
                    reg.Nombre = medico.Rows[0]["Nombre"].ToString(); //Asigna el nombre del medico buscado a nombre
                    reg.Apellido = medico.Rows[0]["Apellido"].ToString(); //Asigna el apellido del medico buscado a apellido
                    reg.Dni = medico.Rows[0]["Dni"].ToString(); //Asigna el dni del medico buscado a dni
                    reg.Email = medico.Rows[0]["Email"].ToString(); // Asigna el email del medico buscado a email
                    reg.Celular = medico.Rows[0]["Telefono"].ToString(); // Asigna el telefono del medico buscado a celular 
                    reg.Provincia = medico.Rows[0]["Provincia"].ToString(); // Asigna la provincia del medico buscado a provincia
                    reg.CodProvincia = medico.Rows[0]["codProvincia"].ToString(); // Asigna la provincia del medico buscado a provincia
                    reg.Localidad = medico.Rows[0]["Localidad"].ToString(); // Asigna la localidad del medico buscado a localidad
                    reg.CodLocalidad = medico.Rows[0]["codLocalidad"].ToString(); // Asigna la localidad del medico buscado a localidad
                    reg.CodEspecialidad = medico.Rows[0]["codEspecialidad"].ToString(); // Asigna la especialidad del medico buscado a especialidad
                    reg.Direccion = medico.Rows[0]["Direccion"].ToString();// Asigna la direccion del medico buscado a direccion
                    reg.Sexo = medico.Rows[0]["Sexo"].ToString(); // Asigna el sexo del medico buscado
                    reg.FechaNacimiento = medico.Rows[0]["FechaNacimiento"].ToString(); // Asigna la fecha de nacimiento del medico buscado
                    reg.Nacionalidad = medico.Rows[0]["Nacionalidad"].ToString(); // Asigna la nacionalidad del medico buscado
                    reg.Especialidad = medico.Rows[0]["Especialidad"].ToString(); // Asigna la especialidad del medico buscado a especialidad
                    reg.Horario = medico.Rows[0]["HorarioAtencion"].ToString(); // Asigna el horario del medico buscado a Horario
                    reg.CodHorario = medico.Rows[0]["CodHorario"].ToString(); // Asigna el horario del medico buscado a Horario
                    reg.DiasAtencion = medico.Rows[0]["DiasAtencion"].ToString(); // Asigna el dia del medico buscado a Dia
                    reg.CodDiasAtencion = medico.Rows[0]["codAtencion"].ToString(); // Asigna el dia del medico buscado a Dia

                    // Remover el primer item del dropdownlist y agregar el valor de la localidad 
                    ddlLocalidad.Items.RemoveAt(0);
                    ddlLocalidad.Items.Insert(0, new ListItem(reg.Localidad, reg.CodLocalidad));

                    // Remover el primer item del dropdownlist y agregar el valor de la  provincia
                    ddlProvincia.Items.RemoveAt(0);
                    ddlProvincia.Items.Insert(0, new ListItem(reg.Provincia, reg.CodProvincia));

                    // Remover el primer item del dropdownlist y agregar el valor de Especialidad
                    ddlEspecialidad.Items.RemoveAt(0);
                    ddlEspecialidad.Items.Insert(0, new ListItem(reg.Especialidad, reg.CodEspecialidad));

                    // Remover el primer item del dropdownlist y agregar el valor de dias de atencion
                    ddlDiasAtencion.Items.RemoveAt(0);
                    ddlDiasAtencion.Items.Insert(0, new ListItem(reg.DiasAtencion, reg.CodDiasAtencion));

                    // Remover el primer item del dropdownlist y agregar el valor de dias de Horario
                    ddlHorario.Items.RemoveAt(0);
                    ddlHorario.Items.Insert(0, new ListItem(reg.Horario, reg.CodHorario));

                    // Convertir
                    if (reg.Sexo == "M")
                    {
                        reg.Sexo = "Masculino";
                        ddlSexo.SelectedValue = "M";

                    }
                    else if (reg.Sexo == "F")
                    {
                        reg.Sexo = "Femenino";
                        ddlSexo.SelectedValue = "F";

                    }
                    else
                    {
                        reg.Sexo = "Otro";
                        ddlSexo.SelectedValue = "O";

                    }
                    // Asignar valores a los TextBox y ddl
                    txtCodigo.Text = reg.CodMedico;
                    txtNombre.Text = reg.Nombre;
                    txtApellido.Text = reg.Apellido;
                    txtDni.Text = reg.Dni;
                    txtEmail.Text = reg.Email;
                    txtCelular.Text = reg.Celular;
                    txtDireccion.Text = reg.Direccion;
                    txtNacionalidad.Text = reg.Nacionalidad;
                    txtFechaNacimiento.Text = reg.FechaNacimiento;


                }
                else
                {
                    // Error
                    lblErrorBusqueda.Text = "No se encontró el médico.";
                }
            }
        }

        private void CargarDatosMedicoPorDni()
        {
            NegocioMedico negM = new NegocioMedico();
            Medico reg = new Medico();
            if (txtBuscar.Text.Length == 8)
            {
                DataTable medico = negM.listarMedicoEspecificoDni(txtBuscar.Text);

                if (medico.Rows.Count > 0) //Validad que hayan datos para mostrar
                {
                    reg.CodMedico = medico.Rows[0]["CodigoMedico"].ToString(); //Asigna el codigo del medico buscado a codMedico
                    reg.Nombre = medico.Rows[0]["Nombre"].ToString(); //Asigna el nombre del medico buscado a nombre
                    reg.Apellido = medico.Rows[0]["Apellido"].ToString(); //Asigna el apellido del medico buscado a apellido
                    reg.Dni = medico.Rows[0]["Dni"].ToString(); //Asigna el dni del medico buscado a dni
                    reg.Email = medico.Rows[0]["Email"].ToString(); // Asigna el email del medico buscado a email
                    reg.Celular = medico.Rows[0]["Telefono"].ToString(); // Asigna el telefono del medico buscado a celular 
                    reg.Provincia = medico.Rows[0]["Provincia"].ToString(); // Asigna la provincia del medico buscado a provincia
                    reg.Localidad = medico.Rows[0]["Localidad"].ToString(); // Asigna la localidad del medico buscado a localidad
                    reg.Direccion = medico.Rows[0]["Direccion"].ToString();// Asigna la direccion del medico buscado a direccion
                    reg.Sexo = medico.Rows[0]["Sexo"].ToString(); // Asigna el sexo del medico buscado
                    reg.FechaNacimiento = medico.Rows[0]["Fecha de Nacimiento"].ToString(); // Asigna la fecha de nacimiento del medico buscado
                    reg.Nacionalidad = medico.Rows[0]["Nacionalidad"].ToString(); // Asigna la nacionalidad del medico buscado
                    reg.Especialidad = medico.Rows[0]["Especialidad"].ToString(); // Asigna la especialidad del medico buscado a especialidad
                    reg.Horario = medico.Rows[0]["Horarios de Atención"].ToString(); // Asigna el horario del medico buscado a Horario
                    reg.DiasAtencion = medico.Rows[0]["Dias de Atención"].ToString(); // Asigna el dia del medico buscado a Dia

                    // Remover el primer item del dropdownlist y agregar el valor de la localidad y provincia
                    ddlLocalidad.Items.RemoveAt(0);
                    ddlLocalidad.Items.Insert(0, new ListItem(reg.Localidad, reg.Localidad));

                    ddlProvincia.Items.RemoveAt(0);
                    ddlProvincia.Items.Insert(0, new ListItem(reg.Provincia, reg.Provincia));

                    ddlEspecialidad.Items.RemoveAt(0);
                    ddlEspecialidad.Items.Insert(0, new ListItem(reg.Especialidad, reg.Especialidad));

                    ddlDiasAtencion.Items.RemoveAt(0);
                    ddlDiasAtencion.Items.Insert(0, new ListItem(reg.DiasAtencion, reg.DiasAtencion));

                    ddlHorario.Items.RemoveAt(0);
                    ddlHorario.Items.Insert(0, new ListItem(reg.Horario, reg.Horario));

                    // Convertir
                    if (reg.Sexo == "M")
                    {
                        reg.Sexo = "Masculino";
                        ddlSexo.SelectedValue = "M";

                    }
                    else if (reg.Sexo == "F")
                    {
                        reg.Sexo = "Femenino";
                        ddlSexo.SelectedValue = "F";

                    }
                    else
                    {
                        reg.Sexo = "Otro";
                        ddlSexo.SelectedValue = "O";

                    }
                    // Asignar valores a los TextBox y ddl
                    txtCodigo.Text = reg.CodMedico;
                    txtNombre.Text = reg.Nombre;
                    txtApellido.Text = reg.Apellido;
                    txtDni.Text = reg.Dni;
                    txtEmail.Text = reg.Email;
                    txtCelular.Text = reg.Celular;
                    txtDireccion.Text = reg.Direccion;
                    ddlProvincia.Text = reg.Provincia;
                    ddlLocalidad.Text = reg.Localidad;
                    txtNacionalidad.Text = reg.Nacionalidad;
                    txtFechaNacimiento.Text = reg.FechaNacimiento;
                    ddlEspecialidad.Text = reg.Especialidad;
                    ddlHorario.Text = reg.Horario;
                    ddlDiasAtencion.Text = reg.DiasAtencion;

                }
                else
                {
                    // Error
                    lblErrorBusqueda.Text = "No se encontró el médico.";
                }
            }
        }

        protected void LimpiarCampos()
        {
            //TextBox
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtApellido.Text = "";
            ddlSexo.Items.Clear();
            ddlSexo.Items.Insert(0, new ListItem("Sexo"));
            txtEmail.Text = "";
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Insert(0, new ListItem("Provincia"));
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("Localidad"));
            ddlEspecialidad.Items.Clear();
            ddlEspecialidad.Items.Insert(0, new ListItem("Especialidad"));
            ddlHorario.Items.Clear();
            ddlHorario.Items.Insert(0, new ListItem("Horario"));
            ddlDiasAtencion.Items.Clear();
            ddlDiasAtencion.Items.Insert(0, new ListItem("Dia Atencion"));
            txtFechaNacimiento.Text = "";
            txtNacionalidad.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            lblError.Text = "";
            lblErrorBusqueda.Text = "";

        }

        //Funcion para validar solo digitos
        private bool SoloDigitos(string str) //Parametro a checkear
        {
            return str.All(Char.IsDigit); //La funcion usa el metodo All para validar que todos los caracteres sean digitos con IsDigit
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

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            string provincia = ddlProvincia.SelectedValue;

            negL.ObtenerLocalidadesPorProvincia(provincia);

            if (string.IsNullOrEmpty(provincia) || provincia == "0")
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add(new ListItem("Seleccionar Localidad", "0"));
                return;
            }

            try
            {
                // Obtener localidades filtradas por la provincia seleccionada
                List<Localidades> localidades = new NegocioLocalidades().ObtenerLocalidadesPorProvincia(provincia);

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

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            NegocioMedico med = new NegocioMedico();
            DataTable dt = med.RetornarCodMedico(txtDni.Text);

            string codmed = dt.Rows.Count > 0 ? dt.Rows[0]["CodMedico"].ToString() : null;

            if (!string.IsNullOrEmpty(codmed))
            {
                Session["CodMedico"] = codmed;
                Response.Redirect("ModificarUsuario.aspx");
            }
            else
            {
                lblError.Text = "Error al obtener el código del médico. Verifique que el médico fue registrado para modificar correctamente.";
                
            }
        }
    }
}