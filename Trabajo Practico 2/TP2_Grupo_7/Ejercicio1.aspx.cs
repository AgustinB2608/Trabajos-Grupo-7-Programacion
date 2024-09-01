using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2_Grupo_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            string ProductoUno = txtProducto1.Text;
            string ProductoDos = txtProducto2.Text;

            int CantidadUno = int.Parse(txtCantidad1.Text);
            int CantidadDos = int.Parse(txtCantidad2.Text);

            int Total = CantidadUno + CantidadDos;

            string tabla = "<table border='1' style='width:10%; border-collapse: collapse;'>"; 

            tabla += "<tr style='font-weight: bold; color: black;'>";
            tabla += "<td style='width:10%;'>Producto</td>"; 
            tabla += "<td style='width:10%;'>Cantidad</td>";
            tabla += "</tr>";

            tabla += "<tr>";
            tabla += $"<td>{ProductoUno}</td>";
            tabla += $"<td>{CantidadUno}</td>";
            tabla += "</tr>";

            tabla += "<tr>";
            tabla += $"<td>{ProductoDos}</td>";
            tabla += $"<td>{CantidadDos}</td>";
            tabla += "</tr>";

            tabla += "<tr style='font-weight: bold; color: black;'>";
            tabla += "<td>TOTAL</td>";
            tabla += $"<td>{Total}</td>";
            tabla += "</tr>";

            tabla += "</table>";

            lblTabla.Text = tabla;
        }

    }
}
