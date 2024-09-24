using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5_Grupo_7
{
    public partial class ListadoSucursales : System.Web.UI.Page
    {
        private Conexion conexion = new Conexion();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }
        private void CargarSucursales()
        {
            // Cambié la consulta para incluir el nombre de la provincia utilice @ para simplificar la consulta
            string consulta = @" 
        SELECT 
            S.Id_Sucursal, 
            S.NombreSucursal, 
            S.DescripcionSucursal, 
            P.DescripcionProvincia,
            S.DireccionSucursal 
        FROM 
            Sucursal S
        INNER JOIN 
            Provincia P ON P.Id_Provincia = S.Id_ProvinciaSucursal;";

            DataTable dt = conexion.EjecutarConsulta(consulta); 
            grvSucursales.DataSource = dt;
            grvSucursales.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string IDsucursal = txtSucursal.Text;

            // Validar que no sea una sucursal vacia
            if (string.IsNullOrEmpty(IDsucursal))
            {
                // Mostrar un mensaje de error
                lblMensaje.Text = "Por favor, ingrese un ID de sucursal.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string consulta = "SELECT Id_Sucursal, NombreSucursal, DescripcionSucursal, " +
                    "DescripcionProvincia, DireccionSucursal " +
                    "FROM Sucursal " +
                    "INNER JOIN Provincia ON Provincia.Id_Provincia = Sucursal.Id_ProvinciaSucursal " +
                    "WHERE Id_Sucursal = '" + IDsucursal + "'";
            DataTable dt = conexion.EjecutarConsulta(consulta);
            if (dt.Rows.Count > 0)
            {
                grvSucursales.DataSource = dt;
                grvSucursales.DataBind();
                lblMensaje.Text = ""; // Limpia el mensaje si se encuentra la sucursal
            }
            txtSucursal.Text = "";

        }
   
        

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtSucursal.Text = "";

            CargarSucursales();
            
        } 
    }
}
