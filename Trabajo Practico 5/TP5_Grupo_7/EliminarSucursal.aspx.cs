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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Conexion conexion = new Conexion();

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string IdSucursal = txtID.Text;

            // Validar si el ID es un número entero
            if (!int.TryParse(IdSucursal, out int sucursalId))
            {
                lblMensaje.Text = "Por favor, ingrese un ID de sucursal válido.";
                return;
            }

            string consulta = $"SELECT * FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
            DataTable resultado = conexion.EjecutarConsulta(consulta);

            if (resultado.Rows.Count > 0)
            {
                // Si la sucursal existe ejecutar el comando para eliminarla
                string eliminar = $"DELETE FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
                bool exito = conexion.EjecutarComando(eliminar);

                revID.Text = "Sucursal borrada exitosamente.";
            }
            else
            {

                revID.Text = "No se puede borrar la sucursal.";

            }
        }
    }
}