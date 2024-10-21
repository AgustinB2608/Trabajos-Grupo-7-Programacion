using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIO;


namespace VISTA
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        NegocioSucursal neg = new NegocioSucursal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
           
            if (int.TryParse(txtID.Text, out id))
            {
               
                Boolean estado = neg.eliminarSucursal(id);

                if (estado)
                {
                    lblMensaje.Text = "Sucursal eliminada con éxito";
                    txtID.Text = ""; 
                }
                else
                {
                    lblMensaje.Text = "No se pudo eliminar la sucursal";
                    txtID.Text = ""; 
                }
            }
            else
            {
               
                lblMensaje.Text = "Por favor, ingrese un número válido.";
                txtID.Text = ""; 
            }
        }
    }
}