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
                string tipoUsuario = Session["UsuarioTipo"].ToString(); // Tipo de usuario

                lblUsuario.Text = $"{nombre} {apellido} {tipoUsuario}";
            }
            else
            {
                Response.Redirect("InicioLogin.aspx"); // Redirigir si no es un administrador logueado
            }
            btnConfirmarEliminar.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                // si el TextBox está vacío o solo tiene espacios en blanco
                lblMensaje.Text = "Por favor, ingrese un codigo.";
            }
            else
            {
                string medicoEliminar = txtCodigo.Text;

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
                else
                {
                    lblMensaje.Text = "No se encontraron resultados para el médico.";
                }
            }
        }



        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {

            string medicoEliminar = txtCodigo.Text;

            // Eliminar al médico
            bool exito = negocioMedico.eliminarMedico(medicoEliminar);

            if (exito)
            {
                // Si la eliminación fue exitosa
                lblMensaje.Text = "El médico y su usuario han sido eliminado con éxito.";
                lblMensaje2.Text = string.Empty;

                // Ocultar el botón y limpiar campos
                btnConfirmarEliminar.Visible = false;
                txtCodigo.Text = string.Empty;

                // Limpiar el gridview
                gvMedicoInfo.DataSource = null;
                gvMedicoInfo.DataBind();
            }
            else
            {
                // Si no se pudo eliminar
                lblMensaje.Text = "No se pudo eliminar el médico. Intente nuevamente.";
            }

        }
    }
}