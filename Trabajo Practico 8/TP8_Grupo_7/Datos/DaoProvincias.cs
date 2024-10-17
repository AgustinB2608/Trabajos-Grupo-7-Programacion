using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoProvincias
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener lista de todas las provincias desde la base de datos.
        public List<Provincias> ObtenerProvincias()
        {
            string consulta = "SELECT Id_Provincia, DescripcionProvincia FROM Provincia";

            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Provincia para almacenar los resultados.
            List<Provincias> provincias = new List<Provincias>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Creo un nuevo objeto Provincia y asigna los valores de la fila actual.
                Provincias provincia = new Provincias
                {
                    Id_Provincia = (int)row["Id_Provincia"], 
                    DescripcionProvincia1 = row["DescripcionProvincia"].ToString().ToCharArray() 
                };

                // Agrega la provincia a la lista.
                provincias.Add(provincia);
            }
            return provincias;
        }
    }
}
