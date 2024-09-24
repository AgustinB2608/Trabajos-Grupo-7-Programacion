using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_Grupo_7
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincia();
            }
        }

        private void CargarProvincia()
        {
            Conexion cargaProvincia = new Conexion();
            DataTable dtProvincias = cargaProvincia.EjecutarConsulta("SELECT Id_Provincia, DescripcionProvincia FROM Provincia");
            {
                ddlProvincia.DataSource = dtProvincias;
                ddlProvincia.DataTextField = "DescripcionProvincia";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, new ListItem("--Selecciona una provincia--", ""));
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            string nombreSucursal = TxtSucursal.Text.Replace("'", "''");
            string descripcionSucursal = TxtDescripcion.Text.Replace("'", "''");
            string direccionSucursal = TxtDireccion.Text.Replace("'", "''");
            string idProvinciaSucursal = ddlProvincia.SelectedValue;

            string consulta = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) " +
                              "VALUES ('" + nombreSucursal + "', '" + descripcionSucursal + "', '" + idProvinciaSucursal + "', '" + direccionSucursal + "')";

            // Ejecutar el comando
            Conexion conex = new Conexion();
            bool resultado = conex.EjecutarComando(consulta);

            // Verificación
            if (resultado)
            {
                lblMensaje.Text = "La sucursal se ha agregado con éxito.";
                LimpiarCampos(); //Añado la funcion de limpiar campos despues de confirmar para evitar cargar repetidas
            }
            else
            {
                lblMensaje.Text = "Error al agregar la sucursal.";
            }
        }

        private void LimpiarCampos()
        {
            TxtSucursal.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            ddlProvincia.SelectedIndex = 0; 
        }

    }
}
