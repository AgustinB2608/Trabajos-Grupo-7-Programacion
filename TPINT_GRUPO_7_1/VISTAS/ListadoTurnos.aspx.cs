using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VISTAS
{
    public partial class ListadoTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTurnos();
        }
        protected void CargarTurnos()
        {
            // Crear una DataTable para almacenar los datos de prueba
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Medico", typeof(string));
            dt.Columns.Add("Especialidad", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Presentismo", typeof(string));

            // Agregar filas de datos de prueba
            dt.Rows.Add("2024-11-01", "Juan Pérez", "Dr. López", "Cardiología", "Activo", "");
            dt.Rows.Add("2024-11-02", "Ana Gómez", "Dr. Ramírez", "Dermatología", "Activo", "");
            dt.Rows.Add("2024-11-03", "Carlos Díaz", "Dra. Fernández", "Pediatría", "Inactivo", "");
            dt.Rows.Add("2024-11-04", "Lucía Hernández", "Dr. García", "Neurología", "Activo", "");
            dt.Rows.Add("2024-11-05", "Marta García", "Dra. Martín", "Ginecología", "Inactivo", "");
            dt.Rows.Add("2024-11-06", "Pedro Suárez", "Dr. Rojas", "Oncología", "Activo", "");
            dt.Rows.Add("2024-11-07", "Laura Fuentes", "Dra. Ortega", "Psiquiatría", "Activo", "");
            dt.Rows.Add("2024-11-08", "Luis Romero", "Dr. Benítez", "Oftalmología", "Inactivo", "");
            dt.Rows.Add("2024-11-09", "Sofía Torres", "Dra. Molina", "Reumatología", "Activo", "");
            dt.Rows.Add("2024-11-10", "Miguel Vargas", "Dr. Sánchez", "Endocrinología", "Inactivo", "");

            // Asignar la DataTable como origen de datos del GridView
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

    }
}