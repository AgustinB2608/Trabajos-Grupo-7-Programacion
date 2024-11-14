﻿using ENTIDADES;
using NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias();
                CargarLocalidades();
            }
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

            // item inicial
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione una provincia--"));

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

            // item inicial
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--"));
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            NegocioPacientes Pac = new NegocioPacientes();
            Pacientes paciente = new Pacientes();

            // Validación #1
            if (!ValidarCamposVacios())
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            // Validación #2
            if (!ValidarSeleccionDropDown(ddlProvincia, "Debe seleccionar una provincia.") ||
                !ValidarSeleccionDropDown(ddlLocalidad, "Debe seleccionar una localidad.") ||
                !ValidarSeleccionDropDown(ddlSexo, "Debe seleccionar un sexo.")) 
            {
                return;
            }

            // Validación #3
            if (!CorreoValido(txtEmail.Text))
            {
                lblMensaje.Text = "El formato del correo electrónico es inválido.";
                return;
            }

            // Validación #4
            if (!SoloDigitos(txtCelular.Text) || txtCelular.Text.Length > 15)
            {
                lblMensaje.Text = "El número de celular es inválido.";
                return;
            }

            // Validación #5 (FECHA)

            
                paciente.Nombre = txtApellido.Text;
                paciente.Apellido = txtNombre.Text;
                paciente.Direccion = txtDireccion.Text;
                paciente.Localidad = ddlLocalidad.SelectedValue;
                paciente.Provincia = ddlProvincia.SelectedValue;
                paciente.Email = txtEmail.Text;
                paciente.Celular = txtCelular.Text;
                paciente.codPaciente = "Ejemplo";
                paciente.Sexo = ddlSexo.SelectedValue;
                paciente.Dni = txtDNI.Text;

            //if (Pac.modificarPaciente(paciente))
            //{
            //    LimpiarCampos(); //Limpiar campos despues de añadir
            //}
            //else
            //{
            //    lblMensaje.Text = "Error";
            //}

            lblMensaje.Text =
                      "Datos del paciente:<br>" +
                      $"Nombre: {paciente.Nombre}<br>" +
                      $"Apellido: {paciente.Apellido}<br>" +
                      $"Dirección: {paciente.Direccion}<br>" +
                      $"Localidad: {paciente.Localidad}<br>" +
                      $"Provincia: {paciente.Provincia}<br>" +
                      $"Email: {paciente.Email}<br>" +
                      $"Celular: {paciente.Celular}<br>" +
                      $"Código de Paciente: {paciente.codPaciente} <br>" +
                      $"Sexo: {paciente.Sexo} <br>" +
                      $"DNI: {paciente.Dni} <br>";
        }

        //Funcion limpiar campos
        protected void LimpiarCampos()
        {
            //TextBox
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";

            //DropDownList
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            //(AÑADIR LAS QUE FALTASEN)
        }

        // Función para validar DropDownList
        private bool ValidarSeleccionDropDown(DropDownList ddl, string mensajeError)
        {
            if (ddl.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddl.SelectedValue))
            {
                lblMensaje.Text = mensajeError;
                return false;
            }
            return true;
        } // Valida que el dropdown tenga un valor seleccionado

        // Función para validar campos vacíos
        private bool ValidarCamposVacios()
        {
            return !(string.IsNullOrWhiteSpace(txtNombre.Text) ||
                     string.IsNullOrWhiteSpace(txtApellido.Text) ||
                     string.IsNullOrWhiteSpace(txtDNI.Text) ||
                     string.IsNullOrWhiteSpace(txtEmail.Text) ||
                     string.IsNullOrWhiteSpace(txtCelular.Text) ||
                     string.IsNullOrWhiteSpace(txtDireccion.Text));

        } // Valida que los campos no estén vacíos (AÑADIR LAS QUE FALTASEN)

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
    }
}