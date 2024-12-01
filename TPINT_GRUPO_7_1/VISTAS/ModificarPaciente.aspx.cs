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


///Error al modificar el paciente: Debe declarar la variable escalar '@Dni'. (btnModificar)


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
            else
            {
                
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

            if (txtBuscar.Text.Length == 8) //Si se "detecta" un DNI guarda los datos y luego los muestra.
            {
                DataTable paciente = reg.listarPacienteEspecificoDni(txtBuscar.Text);

                if (paciente.Rows.Count > 0) //Validad que hayan datos para mostrar
                {
                    obj.Nombre = paciente.Rows[0]["Nombre"].ToString(); //Asigna el nombre del paciente buscado a nombre
                    obj.Apellido = paciente.Rows[0]["Apellido"].ToString(); //Asigna el apellido del paciente buscado a apellido
                    obj.Dni = paciente.Rows[0]["Dni"].ToString(); //Asigna el dni del paciente buscado a dni
                    obj.Email = paciente.Rows[0]["Email"].ToString(); // Asigna el email del paciente buscado a email
                    obj.Celular = paciente.Rows[0]["Telefono"].ToString(); // Asigna el telefono del paciente buscado a celular 
                    obj.Provincia = paciente.Rows[0]["Provincia"].ToString(); // Asigna la provincia del paciente buscado a provincia
                    obj.Localidad = paciente.Rows[0]["Localidad"].ToString(); // Asigna la localidad del paciente buscado a localidad
                    obj.Direccion = paciente.Rows[0]["Direccion"].ToString();// Asigna la direccion del paciente buscado a direccion
                    obj.Sexo = paciente.Rows[0]["Sexo"].ToString(); // Asigna el sexo del paciente buscado
                    obj.FechaNacimiento = paciente.Rows[0]["Fecha de Nacimiento"].ToString(); // Asigna la fecha de nacimiento del paciente buscado
                    obj.Nacionalidad = paciente.Rows[0]["Nacionalidad"].ToString(); // Asigna la nacionalidad del paciente buscado

                    // Remover el primer item del dropdownlist y agregar el valor de la localidad y provincia
                    ddlLocalidad.Items.RemoveAt(0);
                    ddlLocalidad.Items.Insert(0, new ListItem(obj.Localidad, obj.Localidad));

                    ddlProvincia.Items.RemoveAt(0);
                    ddlProvincia.Items.Insert(0, new ListItem(obj.Provincia, obj.Provincia));

                    // Convertir
                    if (obj.Sexo == "M")
                    {
                        obj.Sexo = "Masculino";
                        ddlSexo.SelectedValue = "M";
                        
                    }
                    else if (obj.Sexo == "F")
                    {
                        obj.Sexo = "Femenino";
                        ddlSexo.SelectedValue = "F";
                        
                    }
                    else
                    {
                        obj.Sexo = "Otro";
                        ddlSexo.SelectedValue = "O";
                        
                    }
                    // Asignar valores a los TextBox
                    txtNombre.Text = obj.Nombre;
                    txtApellido.Text = obj.Apellido;
                    txtDNI.Text = obj.Dni;
                    txtEmail.Text = obj.Email;
                    txtCelular.Text = obj.Celular;
                    txtDireccion.Text = obj.Direccion;
                    ddlProvincia.Text = obj.Provincia;
                    ddlLocalidad.Text = obj.Localidad;
                    txtNacionalidad.Text = obj.Nacionalidad;
                    txtFechaNacimiento.Text = obj.FechaNacimiento;

                }
                else
                {
                    // Error
                    lblErrorBusqueda.Text = "No se encontró el paciente.";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Validacion por si se ingresa vacio
            if (string.IsNullOrWhiteSpace(txtBuscar.Text)) 
            {
                lblErrorBusqueda.Text = "Por favor, ingrese un DNI o un Codigo.";
                return; 
            }
            //Valida si solo son digitos
            if(SoloDigitos(txtBuscar.Text) == false) 
            {
                lblErrorBusqueda.Text = "Por favor, ingrese solo números.";
                return; 
            }
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) || string.IsNullOrWhiteSpace(ddlProvincia.SelectedValue) || string.IsNullOrWhiteSpace(ddlLocalidad.SelectedValue))
            {
                lblError.Text = "Por favor, complete todos los campos.";
                return;
            }
            NegocioPacientes negocio = new NegocioPacientes();
            Pacientes paciente = new Pacientes
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDNI.Text,
                Email = txtEmail.Text,
                Celular = txtCelular.Text,
                Direccion = txtDireccion.Text,
                Provincia = ddlProvincia.SelectedValue,
                Localidad = ddlLocalidad.SelectedValue,
                Nacionalidad = txtNacionalidad.Text,
                Sexo = ddlSexo.SelectedValue,
                FechaNacimiento = txtFechaNacimiento.ToString(),
            };

            //Borrar despues
            string datos = $"Nombre: {paciente.Nombre}, Apellido: {paciente.Apellido}, DNI: {paciente.Dni}, " +
                           $"Email: {paciente.Email}, Celular: {paciente.Celular}, Direccion: {paciente.Direccion}, " +
                           $"Provincia: {paciente.Provincia}, Localidad: {paciente.Localidad}, " +
                           $"Nacionalidad: {paciente.Nacionalidad}, " +
                           $"Sexo: {paciente.Sexo}, Fecha de Nacimiento: {paciente.FechaNacimiento.ToString()}";

            try
            {
                lblError.Text = datos; // Mostrar datos 
                negocio.modificarPaciente(paciente); // Descomentar para guardar
                lblErrorBusqueda.Text = "Paciente modificado correctamente.";
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblErrorBusqueda.Text = "Error al modificar el paciente: " + ex.Message; // Muestra el error del sistema
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