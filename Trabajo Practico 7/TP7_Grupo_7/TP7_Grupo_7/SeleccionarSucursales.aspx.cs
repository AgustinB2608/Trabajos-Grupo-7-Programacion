﻿using System;
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

            // Verificar que los controles de nombre y descripción no sean nulos
            if (lblNombreSucursal != null && lblDescripcionSucursal != null)
            {
                // Guardar el ID y los datos de la sucursal en la sesión
                Session["ID_SUCURSAL"] = idSucursal; // Guardar ID de sucursal
                Session["NOMBRE"] = lblNombreSucursal.Text; // Guardar nombre de la sucursal
                Session["DESCRIPCION"] = lblDescripcionSucursal.Text; // Guardar descripción de la sucursal

                // Mensaje de confirmacion
                lblMensaje.Text = "Sucursal seleccionada: " + lblNombreSucursal.Text;
            }
            else
            {
                // Mensaje de error 
                lblMensaje.Text = "Error al seleccionar la sucursal. Por favor, inténtelo de nuevo.";
            }
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











    }
}