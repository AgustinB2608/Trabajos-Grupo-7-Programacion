using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIOS;
using ENTIDADES;
using System.Data.SqlClient;


namespace VISTAS
{
    public partial class EliminarMedico : System.Web.UI.Page
    {
        NegocioMedico negocioMedico = new NegocioMedico();
        NegocioUsuarios negU = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si el usuario está logueado y traer los datos de la sesión (Administrador)
            if (Session["UsuarioLegajo"] != null && Session["UsuarioTipo"] != null && Session["UsuarioTipo"].ToString() == "A")
            {
                string nombre = Session["UsuarioNombre"].ToString(); // Nombre
                string apellido = Session["UsuarioApellido"].ToString(); // Apellido
                

                lblUsuario.Text = $"{nombre} {apellido} ";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }
            btnConfirmarEliminar.Visible = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                // si el TextBox está vacío o solo tiene espacios en blanco
                lblMensaje.Text = "Por favor, ingrese un codigo.";
            }
            else if (txtCodigo.Text.Length == 4)
            {
                string medicoEliminar = txtCodigo.Text.Trim();

                // Obtener el médico específico
                DataTable reg = negocioMedico.listarMedicoEspecifico(medicoEliminar);

                if (reg != null && reg.Rows.Count > 0)
                {
                    // Filtrar columnas que no quiero mostrar
                    DataTable tablaFiltrada = reg.Copy();
                    tablaFiltrada.Columns.Clear(); // Limpiar todas las columnas primero

                    // Agregar solo las columnas que quiero mostrar
                    tablaFiltrada.Columns.Add("Nombre");
                    tablaFiltrada.Columns.Add("Apellido");
                    tablaFiltrada.Columns.Add("DNI");

                    // Copiar los valores de las filas del DataTable original a la tabla filtrada
                    foreach (DataRow row in reg.Rows)
                    {
                        DataRow nuevaFila = tablaFiltrada.NewRow();
                        nuevaFila["Nombre"] = row["Nombre"];
                        nuevaFila["Apellido"] = row["Apellido"];
                        nuevaFila["DNI"] = row["DNI"];
                        tablaFiltrada.Rows.Add(nuevaFila);
                    }

                    // Mostrar la información filtrada
                    gvMedicoInfo.DataSource = tablaFiltrada;
                    gvMedicoInfo.DataBind();

                    // Mensaje de confirmación
                    lblMensaje2.Text = "¿Está seguro de que desea eliminar este médico?";
                    btnConfirmarEliminar.Visible = true;
                }
            }
            else
            {
                lblMensaje.Text = "Ingrese un código de médico válido.";
            }

        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            string medicoEliminar = txtCodigo.Text.Trim();
            lblMensaje2.Text = "";
            // Eliminar al médico

            if (negocioMedico.eliminarMedico(medicoEliminar))
            {
                // Si la eliminación fue exitosa
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "El médico ha sido eliminado con éxito.";
                if(eliminarUsuario(medicoEliminar))
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje2.Text = "Su usuario ha sido eliminado con éxito.";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje2.Text = "Su usuario no se ha podido eliminar.";
                }
                // Ocultar el botón y limpiar campos
                btnConfirmarEliminar.Visible = false;
                txtCodigo.Text = "";

                // Limpiar el gridview
                gvMedicoInfo.DataSource = null;
                gvMedicoInfo.DataBind();
            }
            else
            {
                gvMedicoInfo.DataSource = null;
                gvMedicoInfo.DataBind();
                // Si no se pudo eliminar
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No se pudo eliminar el médico. Intente nuevamente.";
                txtCodigo.Text = "";

            }
        }

        public bool eliminarUsuario(string codmedico)
        {
            NegocioUsuarios negU = new NegocioUsuarios();

            return negU.eliminarUsuario(codmedico);
            
        }

    }
}