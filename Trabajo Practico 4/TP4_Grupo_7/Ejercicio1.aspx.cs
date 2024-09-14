using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4_Grupo_7
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        //private String ruta = "Data Source = localhost\\sqlexpress01;Initial Catalog = Viajes; Integrated Security = True";
        private String ruta = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Viajes;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        private void CargarProvincias()
        {
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT IdProvincia, NombreProvincia FROM Provincias", cn);
                DataSet ds = new DataSet();
                adapt.Fill(ds, "TablaProvincias");

                ddlProvincias.DataSource = ds.Tables[0];
                ddlProvincias.DataTextField = "NombreProvincia";
                ddlProvincias.DataValueField = "IdProvincia";
                ddlProvincias.DataBind();
                ddlProvincias.Items.Insert(0, new ListItem("--Seleccionar--"));
                ddlLocalidadesInicio.Items.Insert(0, new ListItem("--Seleccionar--"));

                ddlProvinciaFinal.DataSource = ds.Tables[0];
                ddlProvinciaFinal.DataTextField = "NombreProvincia";
                ddlProvinciaFinal.DataValueField = "IdProvincia";
                ddlProvinciaFinal.DataBind();
                ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--"));
                ddlLocalidadesFinal.Items.Insert(0, new ListItem("--Seleccionar--"));

                // Guardamos la lista original de provincias en la sesión temporal
                Session["Provincias"] = ds.Tables[0];

                cn.Close();//Podriamos no usar esto, ya que se cierra automaticamente al finalizar el using 
            }
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincias.SelectedIndex > 0)
            {
                CargarLocalidadesPorProvincia(Convert.ToInt32(ddlProvincias.SelectedValue));
                EliminarProvinciaSeleccionada();// Llamamos a la función para eliminar la provincia seleccionada de "Destino Final"
            }
        }

        private void EliminarProvinciaSeleccionada()
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
                ddlLocalidadesInicio.Items.Insert(0, new ListItem("--Seleccionar--"));
            }
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvinciaFinal.SelectedIndex > 0)
            {
                CargarLocalidadesPorProvinciaFinal(Convert.ToInt32(ddlProvinciaFinal.SelectedValue));
            }
        }

        private void CargarLocalidadesPorProvinciaFinal(int idProvincia)
        {
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                cn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = @IdProvincia", cn);
                adapt.SelectCommand.Parameters.AddWithValue("@IdProvincia", idProvincia);

                DataSet ds = new DataSet();
                adapt.Fill(ds, "TablaLocalidades");

                ddlLocalidadesFinal.Items.Clear();
                ddlLocalidadesFinal.DataSource = ds.Tables[0];
                ddlLocalidadesFinal.DataTextField = "NombreLocalidad";
                ddlLocalidadesFinal.DataValueField = "IdLocalidad";
                ddlLocalidadesFinal.DataBind();
                ddlLocalidadesFinal.Items.Insert(0, new ListItem("--Seleccionar--"));
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Todas las opciones tienen q estar seleccionadas para confirmar el viaje
            if (ddlProvincias.SelectedIndex == 0 ||
                ddlLocalidadesInicio.SelectedIndex == 0 ||
                ddlProvinciaFinal.SelectedIndex == 0 ||
                ddlLocalidadesFinal.SelectedIndex == 0)
            {
                lblMensaje.Text = "Error: Debe seleccionar todas las opciones.";
                lblMensaje.ForeColor = System.Drawing.Color.Red; 
            }
            else
            {
                // Si se selecciono todas las opciones lo confirma
                lblMensaje.Text = "VIAJE CONFIRMADO";
                lblMensaje.ForeColor = System.Drawing.Color.Green; 
            }
        }

    }
}
