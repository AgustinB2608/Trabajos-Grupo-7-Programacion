using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.EnterpriseServices;


namespace TP4_Grupo_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        //private String ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True";
        private String ruta = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Viajes;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarProvincias();
            }
        }
        private void CargarProvincias()
        {
            SqlConnection cn = new SqlConnection(ruta);
            cn.Open();

            SqlDataAdapter adapt = new SqlDataAdapter("Select IdProvincia, NombreProvincia From Provincias", cn);

            DataSet ds = new DataSet();
            adapt.Fill(ds, "TablaProvincias");

            ddlProvincias.DataSource = ds.Tables[0]; // 0 = TablaProvincias
            ddlProvincias.DataTextField = "NombreProvincia";
            ddlProvincias.DataValueField = "IdProvincia";
            ddlProvincias.DataBind();
            ddlProvincias.Items.Insert(0, new ListItem("--Seleccionar--"));

            ddlProvinciaFinal.DataSource = ds.Tables[0]; // 0 = TablaProvincias
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--"));

            // Guardamos la lista original de provincias en la sesión temporal //Nuevo
            Session["Provincias"] = ds.Tables[0];

            cn.Close();
        }


        private void EliminarProvinciaSeleccionada()//Nuevo
        {
            // Restauramos las opciones completas de provincias antes de eliminar
            DataTable provincias = (DataTable)Session["Provincias"];

            ddlProvinciaFinal.DataSource = provincias;
            ddlProvinciaFinal.DataTextField = "NombreProvincia";
            ddlProvinciaFinal.DataValueField = "IdProvincia";
            ddlProvinciaFinal.DataBind();
            ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--"));

            // Ahora removemos la provincia seleccionada
            string provinciaSeleccionada = ddlProvincias.SelectedValue;
            ListItem itemToRemove = ddlProvinciaFinal.Items.FindByValue(provinciaSeleccionada);
            if (itemToRemove != null)
            {
                ddlProvinciaFinal.Items.Remove(itemToRemove);
            }
        }


        protected void DdlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincias.SelectedIndex > 0)
            {
                CargarLocalidadesPorProvincia(Convert.ToInt32(ddlProvincias.SelectedValue));
                EliminarProvinciaSeleccionada(); // Llamamos a la funcion para eliminar la provincia seleccionada de "Destino Final"//Nuevo
            }
        }

        private void CargarLocalidadesPorProvincia(int idProvincia)
        {
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();
                
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
                adapt.SelectCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

                DataSet ds = new DataSet();
                adapt.Fill(ds, "TablaLocalidades");

                ddlLocalidadesInicio.DataSource = ds.Tables[0];
                ddlLocalidadesInicio.DataTextField = "NombreLocalidad";
                ddlLocalidadesInicio.DataValueField = "IdLocalidad";
                ddlLocalidadesInicio.DataBind();
                
            }
        }

     
    }
}