
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Grupo_7
{
    
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BtnGuardarLocalidad_Click(object sender, EventArgs e)
        {
            string Localidad = TxtLocalidades.Text;
            ddlLocalidades.Items.Add(new ListItem(Localidad));
            TxtLocalidades.Text = "";
        }
    }
}