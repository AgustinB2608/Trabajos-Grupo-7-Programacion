using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2_Grupo_7
{
    public partial class Ejercicio5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculo_Click(object sender, EventArgs e)
        {
            int precioBase = int.Parse(ddlGB.SelectedValue);

            float precioExtras = 0;
            foreach (ListItem item in cblAccesorios.Items)
            {
                if (item.Selected)
                {
                    precioExtras += float.Parse(item.Value);
                }
            }
            float precioFinal = precioBase + precioExtras;
            //N2 significa que se mostrarán 2 decimales- Ej: El precio final es de 2.751,00$
            lblMensaje.Text = $"El precio final es de {precioFinal.ToString("N2")}$";
        }
    }
}