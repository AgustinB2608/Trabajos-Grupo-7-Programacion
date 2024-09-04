
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
            if (Page.IsValid)
            {
                string localidad = TxtLocalidades.Text.Trim();
                
                    ddlLocalidades.Items.Add(new ListItem(localidad));
                    TxtLocalidades.Text = "";
                
            }
        }

        protected void cvLocalidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string localidad = args.Value.Trim();

            // Verifico si la localidad ya existe en el DropDownList
            if (ddlLocalidades.Items.FindByText(localidad) != null)
            {
                args.IsValid = false; // La localidad ya existe
            }
            else
            {
                args.IsValid = true; // La localidad no existe, es valida
            }
        }
    }
}