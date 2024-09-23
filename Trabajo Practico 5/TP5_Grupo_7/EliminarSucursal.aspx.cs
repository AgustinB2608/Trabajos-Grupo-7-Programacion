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

            string consulta = $"SELECT * FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
            DataTable resultado = conexion.EjecutarConsulta(consulta);

            if (resultado.Rows.Count > 0)
            {
                // Si la sucursal existe ejecutar el comando para eliminarla
                string eliminar = $"DELETE FROM Sucursal WHERE Id_Sucursal = {IdSucursal}";
                bool exito = conexion.EjecutarComando(eliminar);

                //agregar if para mostrar mensaje de eliminada con exito o no se pudo eliminar
            }
            else
            {
                // Si no existe mostrar mensaje
                
            }
        }
    }
}