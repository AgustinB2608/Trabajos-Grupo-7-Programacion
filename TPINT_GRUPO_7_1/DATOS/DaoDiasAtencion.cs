using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoDiasAtencion
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todos los dias de atencion desde la base de datos
        public List<DiasAtencion> ObtenerDiasAtencion()
        {
            // Consulta SQL para seleccionar datos de la tabla DiasAtencion
            string consulta = "SELECT IdDia, Nombre FROM DiasAtencion";

            // Ejecuta la consulta y obtiene los resultados en un DataTable
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Dias de Atencion para almacenar los resultados.
            List<DiasAtencion> diasAtencion = new List<DiasAtencion>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Crea un nuevo objeto Dias de Atencion y asigna los valores de la fila actual
                DiasAtencion dias = new DiasAtencion
                {
                    IdDia = (int)row["IdDia"],
                    Dias = row["Nombre"].ToString(),
                    
                };

                // Agrega el objeto Dias de Atencion a la lista
                diasAtencion.Add(dias);
            }

            // Retorna la lista de Dias de Atencion obtenidas
            return diasAtencion;
        }
    }
}
