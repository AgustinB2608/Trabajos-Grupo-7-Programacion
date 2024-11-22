using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoProvincia
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener lista de todas las provincias desde la base de datos.
        public List<Provincias> ObtenerProvincias()
        {
            // Consulta SQL para seleccionar datos de la tabla Localidades
            string consulta = "SELECT CodProvincia_PR AS CodigoProvincia, Descripcion_PR AS Descripcion FROM Provincias";

            // Crea una lista de objetos Localidades para almacenar los resultados
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Provincia para almacenar los resultados.
            List<Provincias> provincias = new List<Provincias>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Creo un nuevo objeto Provincia y asigna los valores de la fila actual.
                Provincias provincia = new Provincias
                {
                    Id_Provincia = row["CodProvincia_PR"].ToString(),
                    DescripcionProvincia1 = row["Descripcion_PR"].ToString()
                };

                // Agrega la provincia a la lista.
                provincias.Add(provincia);
            }
            return provincias;
        }
    }
}
