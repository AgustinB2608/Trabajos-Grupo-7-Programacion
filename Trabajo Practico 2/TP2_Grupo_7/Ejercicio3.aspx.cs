using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2_Grupo_7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            lblCOLOR.ForeColor = System.Drawing.Color.Red;
            lblCOLOR.Text = "Texto Coloreado";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            lblCOLOR.ForeColor = System.Drawing.Color.Blue;
            lblCOLOR.Text = "Texto Coloreado";
        }
    }
}