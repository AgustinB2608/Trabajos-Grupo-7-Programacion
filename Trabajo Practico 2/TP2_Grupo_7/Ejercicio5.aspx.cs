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
            float precioExtras = 0;
            foreach (ListItem item in cblAccesorios.Items)
            {
                if (item.Selected)
                {
                    precioExtras += float.Parse(item.Value);
                }
            }
        }
    }
}