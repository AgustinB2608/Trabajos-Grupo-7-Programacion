using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace TP5_Grupo_7
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        // Instancia de la clase de conexión 
        Conexion conexion = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            revID.AccessKey = ""; // Limpiar el mensaje de validación al intentar eliminar una sucursal

            string IdSucursal = txtID.Text;

            // Verificar si el TextBox está vacío
            if (string.IsNullOrWhiteSpace(IdSucursal))
            {
                lblMensaje.Text = "Por favor, ingrese un ID de sucursal.";
                lblMensaje.ForeColor = System.Drawing.Color.Red; 
                return; 
            }

            // Consulta para verificar si la sucursal existe 
            string consulta = $"SELECT * FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
            DataTable resultado = conexion.EjecutarConsulta(consulta);

            if (resultado.Rows.Count > 0)
            {
                // Si la sucursal existe, ejecutar el comando para eliminarla 
                string eliminar = $"DELETE FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
                bool exito = conexion.EjecutarComando(eliminar);


                if (exito)
                {   // Mensaje de confirmación si la eliminación fue exitosa 
                    lblMensaje.Text = "Sucursal borrada exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    // Mensaje de error si la eliminación falló x algun error
                    lblMensaje.Text = "Error al intentar borrar la sucursal.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                // Mensaje de error si la sucursal no existe(que no se halla encontrado el ID)
                lblMensaje.Text = "No se puede borrar la sucursal. ID no encontrado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            txtID.Text = ""; // Limpiar el campo de texto después de la eliminación

        }
    }
}
