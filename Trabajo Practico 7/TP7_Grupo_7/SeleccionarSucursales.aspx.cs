using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TP7_Grupo_7
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSucursales();
            }
        }

        private void CargarSucursales(string idProvincia = null)
        {
            try
            {
                Conexion conexion = new Conexion();
                string consulta = "SELECT Id_Sucursal, NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal";

                if (!string.IsNullOrEmpty(idProvincia))
                {
                    consulta += " WHERE Id_ProvinciaSucursal = " + idProvincia;
                }

                DataTable dtSucursales = conexion.EjecutarConsulta(consulta);
                lvSucursales.DataSource = dtSucursales;
                lvSucursales.DataBind();

                // Si no hay sucursales cargadas en la provincia seleccionada se muestra el mensaje, sino se limpia el mensaje
                if (dtSucursales.Rows.Count == 0)
                {
                    lblMensaje.Text = "No hay sucursales en esta provincia.";
                }
                else
                {
                    lblMensaje.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar las sucursales: " + ex.Message;
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Obtener el contenedor del item que contiene el botón q se presiono
            ListViewItem item = (ListViewItem)((Button)sender).NamingContainer; // Lo que hace es identificar en que fila se encuentra el boton que se presiono, ya que hay varias cards(sucursales) y cada una tiene un boton de seleccionar

            // Obtener el ID de la sucursal 
            string idSucursal = lvSucursales.DataKeys[item.DisplayIndex].Value.ToString();

            // Obtener el control que muestra el nombre de la sucursal
            Label lblNombreSucursal = (Label)item.FindControl("NombreSucursalLabel");

            // Obtener el control que muestra la descripción de la sucursal
            Label lblDescripcionSucursal = (Label)item.FindControl("DescripcionSucursalLabel");


            if (Session["tabla"] == null)
            {
                Session["tabla"] = crearTablaSucursales();
            }

            agregarSucursalesSeleccionadas((DataTable)Session["tabla"], idSucursal, lblNombreSucursal.Text, lblDescripcionSucursal.Text);
        }

        protected void BtnNombreProv_Command(object sender, CommandEventArgs e)
        {
            string idProvinciaSeleccionada = e.CommandArgument.ToString();
            CargarSucursales(idProvinciaSeleccionada);


        }

        protected void btnMostrarTodasSucursales_Click(object sender, EventArgs e)
        {
            // Llamar al método para cargar todas las sucursales
            CargarSucursales();
        }

        public DataTable crearTablaSucursales()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ID Sucursal", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Nombre Sucursal", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("Descripcion", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void agregarSucursalesSeleccionadas(DataTable tabla, String idSucursal, String NombreSucursal, string DescripcionSucursal)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Sucursal"] = idSucursal;
            dr["Nombre Sucursal"] = NombreSucursal;
            dr["Descripcion"] = DescripcionSucursal;
            tabla.Rows.Add(dr);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            // Si el TextBox está vacío, mostramos todas las sucursales
            if (string.IsNullOrEmpty(textoBusqueda))
            {
                CargarSucursales();
            }
            else
            {
                try
                {
                    // Cargar todas las sucursales para filtrar
                    Conexion conexion = new Conexion();
                    string consulta = "SELECT Id_Sucursal, NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal";
                    DataTable dtSucursales = conexion.EjecutarConsulta(consulta);

                    // Filtrar las sucursales que contienen el texto ingresado
                    var sucursalesFiltradas = dtSucursales.AsEnumerable()
                        .Where(row => row.Field<string>("NombreSucursal").ToLower().Contains(textoBusqueda))
                        .CopyToDataTable();

                    // Guardar las sucursales filtradas en la sesión
                    if (sucursalesFiltradas.Rows.Count > 0)
                    {
                        Session["SucursalesFiltradas"] = sucursalesFiltradas;
                    }
                    else
                    {
                        Session.Remove("SucursalesFiltradas"); // Limpiar sesión si no hay resultados
                    }

                    // Cargar las sucursales filtradas en el ListView
                    lvSucursales.DataSource = sucursalesFiltradas;
                    lvSucursales.DataBind();

                    // Verificar si hay sucursales filtradas
                    if (sucursalesFiltradas.Rows.Count == 0)
                    {
                        lblMensaje.Text = "No hay sucursales que coincidan con la búsqueda.";
                    }
                    else
                    {
                        lblMensaje.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al buscar sucursales: " + ex.Message;
                }
            }
        }
    }
}
