using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NEGOCIOS;
using ENTIDADES;

namespace VISTAS
{
    public partial class ListarMedico : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarMedicos();
            }
            if (!IsPostBack)
            {
                lblMensaje1.Visible = false;
            }
            else
            {
                lblMensaje1.Visible = false;
            }
           
        }
        private void CargarMedicos()
        {
            try
            {
                // Crear una instancia de la clase NegocioMedico para acceder a sus metodos
                NegocioMedico negocioMedico = new NegocioMedico();

                // Llamar al metodo listarMedicos para obtener todos los medicos en un DataTable
                DataTable dt = negocioMedico.listarMedicos();

                // Asignar el DataTable como origen de datos de la grilla grvMedicos
                grvMedicos.DataSource = dt;

                // Actualizar la grilla para mostrar los datos de los medicos
                grvMedicos.DataBind();

                // Si el DataTable tiene filas limpiar el mensaje de lo contrario mostrar un mensaje
                lblMensaje.Text = dt.Rows.Count > 0
                    ? ""
                    : "No se encontraron médicos.";
            }
            catch (Exception)
            {
                // En caso de excepcion mostrar un mensaje de error
                lblMensaje.Text = "Ocurrió un error al cargar los médicos.";

            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de texto txtMedico esta vacio o solo contiene espacios en blanco
            if (string.IsNullOrWhiteSpace(txtMedico.Text))
            {
                // Mostrar un mensaje de error si no se ingreso un codigo de medico
                lblMensaje.Text = "Por favor, ingrese un CODIGO de medico.";
                return; // Salir del metodo si el campo está vacío
            }

            // Intentar convertir el texto ingresado en un numero entero
            if (int.TryParse(txtMedico.Text, out int codMedico))
            {
                try
                {
                    // Crear una instancia de la clase NegocioMedico para acceder a sus metodos
                    NegocioMedico negocioMedico = new NegocioMedico();

                    // Llamar al metodo listarMedicoEspecifico con el codigo del medico ingresado
                    DataTable dt = negocioMedico.listarMedicoEspecifico(codMedico.ToString());

                    // Asignar el DataTable como origen de datos de la grilla grvMedicos
                    grvMedicos.DataSource = dt;

                    // Actualizar la grilla para mostrar los datos del medico especifico
                    grvMedicos.DataBind();

                    // Mostrar un mensaje segun si se encontraron medicos con el codigo especificado o no
                    lblMensaje.Text = dt.Rows.Count > 0
                        ? ""
                        : "No se encontraron médicos con ese CODIGO.";
                }
                catch (Exception)
                {
                    // En caso de excepcion, mostrar un mensaje de error
                    lblMensaje.Text = "Ocurrió un error al filtrar el médico.";
                }
            }
            else
            {
                // Mostrar un mensaje de error si el codigo ingresado no es un numero entero
                lblMensaje.Text = "El código ingresado debe ser un número entero.";
            }

            // Limpiar el campo de texto txtMedico después de procesar el evento
            txtMedico.Text = string.Empty;
        }



        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            NegocioMedico negMedico = new NegocioMedico();

            DataTable reg = negMedico.listarMedicos();


            if (reg != null && reg.Rows.Count > 0)
            {
                grvMedicos.DataSource = reg;
                grvMedicos.DataBind();

            }
            else
            {
                lblMensaje1.Visible = true;
                // Si no se encontraron registros
                lblMensaje1.Text = "No se encontraron resultados.";
            }
        }
    }
}