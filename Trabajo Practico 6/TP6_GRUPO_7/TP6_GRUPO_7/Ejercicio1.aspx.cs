using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.EnterpriseServices;


namespace TP6_GRUPO_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private String ruta = "Data Source=localhost\\sqlexpress01; Initial Catalog = Neptuno; Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}