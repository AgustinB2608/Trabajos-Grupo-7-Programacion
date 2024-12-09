using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Threading.Tasks;



namespace VISTAS
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {
        NegocioLocalidades ngl = new NegocioLocalidades();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias();
                CargarLocalidades();
                CargarSexo();

            }
            // Verificar si el usuario está logueado y traer los datos de la sesión (Administrador)
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                lblUsuario.Text = $"{nombre} {apellido} {tipoUsuario}";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }

        }
        
        public void CargarSexo()
        {
            ddlSexo.Items.Insert(0, new ListItem("Sexo"));
            ddlSexo.Items.Insert(1, new ListItem("Femenino", "F"));
            ddlSexo.Items.Insert(2, new ListItem("Masculino", "M"));
            ddlSexo.Items.Insert(3, new ListItem("Otro", "O"));
        }
        public void CargarProvincias()
        {
            NegocioProvincia negocioProvincia = new NegocioProvincia();
            List<Provincias> listaProvincias = negocioProvincia.ObtenerProvincias();

            // Cargamos el dropdown provincias
            ddlProvincia.DataSource = listaProvincias;
            ddlProvincia.DataTextField = "DescripcionProvincia1"; // Propiedad para mostrar
            ddlProvincia.DataValueField = "Id_Provincia"; // Propiedad para el valor
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("Provincia"));
        }

        public void CargarLocalidades()
        {
            NegocioLocalidades negocioLocalidad = new NegocioLocalidades();
            List<Localidades> listaLocalidades = negocioLocalidad.ObtenerLocalidad();

            // Cargamos el dropdown localidades
            ddlLocalidad.DataSource = listaLocalidades;
            ddlLocalidad.DataTextField = "DescripcionLocalidad1"; // Propiedad para mostrar
            ddlLocalidad.DataValueField = "Id_Localidad"; // Propiedad para el valor
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("Localidad"));
        }

        public void DatosSegunDni()
        {
            NegocioPacientes reg = new NegocioPacientes();
            Pacientes obj = new Pacientes();

            if (txtBuscar.Text.Length == 8) //DNI, guarda los datos y luego los muestra.
            {
                DataTable paciente = reg.listarPacienteEspecificoDni(txtBuscar.Text);

                if (paciente.Rows.Count > 0) //Validad que hayan datos para mostrar
                {
                    obj.Provincia = paciente.Rows[0]["CodProvincia"].ToString(); // Asigna la provincia del paciente buscado a provincia
                    obj.Localidad = paciente.Rows[0]["CodLocalidad"].ToString(); // Asigna la localidad del paciente buscado a localidad
                    obj.Dni = paciente.Rows[0]["Dni"].ToString(); //Asigna el dni del paciente buscado a dni
                    obj.Nombre = paciente.Rows[0]["Nombre"].ToString(); //Asigna el nombre del paciente buscado a nombre
                    obj.Apellido = paciente.Rows[0]["Apellido"].ToString(); //Asigna el apellido del paciente buscado a apellido
                    obj.FechaNacimiento = paciente.Rows[0]["Fecha de Nacimiento"].ToString(); // Asigna la fecha de nacimiento del paciente buscado
                    obj.Nacionalidad = paciente.Rows[0]["Nacionalidad"].ToString(); // Asigna la nacionalidad del paciente buscado
                    obj.Direccion = paciente.Rows[0]["Direccion"].ToString();// Asigna la direccion del paciente buscado a direccion
                    obj.Email = paciente.Rows[0]["Email"].ToString(); // Asigna el email del paciente buscado a email
                    obj.Sexo = paciente.Rows[0]["Sexo"].ToString(); // Asigna el sexo del paciente buscado
                    obj.Celular = paciente.Rows[0]["Telefono"].ToString(); // Asigna el telefono del paciente buscado a celular 
                    string provincia = paciente.Rows[0]["Provincia"].ToString();
                    string localidad = paciente.Rows[0]["Localidad"].ToString();

                    CargarSexo();
                   
                    // Convertir
                    if (obj.Sexo == "M")
                    {
                        obj.Sexo = "Masculino";
                        ddlSexo.Items.RemoveAt(0);
                        ddlSexo.SelectedValue = "M";
                        

                    }
                    else if (obj.Sexo == "F")
                    {
                        obj.Sexo = "Femenino";
                        ddlSexo.Items.RemoveAt(0);
                        ddlSexo.SelectedValue = "F";
                        
                    }
                    else
                    {
                        obj.Sexo = "Otro";
                        ddlSexo.Items.RemoveAt(0);
                        ddlSexo.SelectedValue = "O";
                        
                    }
                    // Asigna valores a los TextBox
                    // Remover el primer item del dropdownlist y agregar el valor de la localidad y provincia
                    CargarProvincias();
                    CargarLocalidades();
                    ddlProvincia.Items.RemoveAt(0);
                    ddlProvincia.Items.Insert(0, new ListItem(provincia, obj.Provincia));
                    ddlLocalidad.Items.RemoveAt(0);
                    ddlLocalidad.Items.Insert(0, new ListItem(localidad, obj.Localidad));
                    txtDNI.Text = obj.Dni;
                    txtNombre.Text = obj.Nombre;
                    txtApellido.Text = obj.Apellido;
                    txtFechaNacimiento.Text = obj.FechaNacimiento;
                    txtNacionalidad.Text = obj.Nacionalidad;
                    txtDireccion.Text = obj.Direccion;
                    txtEmail.Text = obj.Email;
                    txtCelular.Text = obj.Celular;

                }
                else
                {
                    // Error
                    lblErrorBusqueda.Text = "No se encontró el paciente.";
                }
            }
            else
            {
                lblErrorBusqueda.Text = "Debe ingresar un dni válido.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            lblError.Text = "";
            lblErrorBusqueda.Text = "";

            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtBuscar.Text)) 
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un DNI.";
                return; 
            }
            //Valida si solo son digitos
            if(SoloDigitos(txtBuscar.Text) == false) 
            {
                lblErrorBusqueda.Text = "Por favor, ingrese solo números.";
                return; 
            }
            CargarProvincias();
            CargarLocalidades();
            //Si la longitud es 8, busca por DNI
            if (txtBuscar.Text.Length == 8 )
            {
                DatosSegunDni();
            }
            
            //Si no cumple ninguna de las condiciones anteriores, muestra un mensaje de error
            else
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un DNI.";
            }

            txtBuscar.Text = "";

        }

        protected void btnLimpiar_Click(object sender, EventArgs e) //Boton limpiar campos
        {
            LimpiarCampos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || 
                string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || 
                string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || 
                string.IsNullOrWhiteSpace(txtFechaNacimiento.Text))
            {
                lblError.Text = "Por favor, complete todos los campos de texto.";
                return;
            }
            NegocioPacientes negocio = new NegocioPacientes();
            Pacientes paciente = new Pacientes();

            DateTime fechaNacimiento;
            string fecha = (txtFechaNacimiento.Text.Trim().ToString());
            DateTime.TryParse(fecha, out fechaNacimiento);

            paciente.Provincia = (ddlProvincia.SelectedValue.ToString());
            paciente.Localidad = (ddlLocalidad.SelectedValue.ToString());
            paciente.Dni = (txtDNI.Text.Trim().ToString());
            paciente.Nombre = (txtNombre.Text.Trim().ToString());
            paciente.Apellido = (txtApellido.Text.Trim().ToString());
            paciente.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
            paciente.Nacionalidad = (txtNacionalidad.Text.Trim().ToString());
            paciente.Direccion = (txtDireccion.Text.Trim().ToString());
            paciente.Email = (txtEmail.Text.Trim().ToString());
            paciente.Sexo = (ddlSexo.SelectedValue.ToString());
            paciente.Celular = (txtCelular.Text.Trim().ToString());

            if (negocio.modificarPaciente(paciente)) 
            {
                lblErrorBusqueda.ForeColor = System.Drawing.Color.Green;
                lblErrorBusqueda.Text = "Paciente modificado correctamente.";
                LimpiarCampos();
            }
            else
            {
                lblErrorBusqueda.Text = "No se pudo modificar el Paciente.";
                
            }
            
        }


        //---------------------------------Funciones------------------------------------------
        //Funcion limpiar campos
        protected void LimpiarCampos()
        {
            //TextBox
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtApellido.Text = "";
            ddlSexo.Items.Clear();
            ddlSexo.Items.Insert(0, new ListItem("Sexo"));
            txtEmail.Text = "";
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Insert(0, new ListItem("Provincia"));
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("Localidad"));
            txtFechaNacimiento.Text = "";
            txtNacionalidad.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            
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

            filtradoProvincia();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMLPacientes.aspx");
        }

        public void filtradoProvincia()
        {
            string provincia = ddlProvincia.SelectedValue;

            ngl.ObtenerLocalidadesPorProvincia(provincia);

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

    }
}