using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoLocalidad
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todas las Localidades desde la base de datos
        public List<Localidades> ObtenerLocalidad()
        {
            // Consulta SQL para seleccionar datos de la tabla Localidades
            string consulta = "SELECT CodLocalidad_LL, Nombre, CodProvincia_LL FROM Localidades";

            // Ejecuta la consulta y obtiene los resultados en un DataTable
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Localidades para almacenar los resultados.
            List<Localidades> listaLocalidades = new List<Localidades>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Crea un nuevo objeto Localidades y asigna los valores de la fila actual
                Localidades localidad = new Localidades
                {
                    Id_Localidad = (int)row["CodLocalidad_LL"],
                    DescripcionLocalidad1 = row["Nombre"].ToString(),
                    Id_Provincia = Convert.ToInt32(row["CodProvincia_LL"])
                };

                // Agrega el objeto Localidades a la lista
                listaLocalidades.Add(localidad);
            }

            // Retorna la lista de localidades obtenidas
            return listaLocalidades;
        }
    }
}

