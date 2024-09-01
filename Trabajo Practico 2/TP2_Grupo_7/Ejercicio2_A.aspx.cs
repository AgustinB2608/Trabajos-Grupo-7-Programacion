using System;
using System.Web.UI;

namespace TP2_Grupo_7
{
    public partial class Ejercicio2_A : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResumen_Click(object sender, EventArgs e)
        {
            // Transferir a la segunda página para mostrar el resumen
            Server.Transfer("Ejercicio2_B.aspx");
        }
    }
}
