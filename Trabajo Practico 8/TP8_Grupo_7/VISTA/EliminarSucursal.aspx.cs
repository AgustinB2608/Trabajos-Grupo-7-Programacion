﻿using System;
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
            Boolean estado = false;
            estado = neg.eliminarSucursal(int.Parse(txtID.Text));
            if (estado == true)
            {
               
            }
            else
            {
                
            }
        }
    }
}