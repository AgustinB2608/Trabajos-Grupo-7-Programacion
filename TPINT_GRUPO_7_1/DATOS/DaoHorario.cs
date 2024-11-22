using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoHorario
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todos los horarios de atencion desde la base de datos
        public List<Horarios> ObtenerHorarios()
        {
            // Consulta SQL para seleccionar datos de la tabla HorariosAtencion
            string consulta = "SELECT CodHorariosAtencion_HA AS CodigoHorarios, Descripcion_HA AS Descripcion FROM HorariosAtencion";

            // Ejecuta la consulta y obtiene los resultados en un DataTable
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Horarios de Atencion para almacenar los resultados.
            List<Horarios> horarios = new List<Horarios>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Crea un nuevo objeto horarios y asigna los valores de la fila actual
                Horarios hora = new Horarios
                {
                    IdHorario = row["CodigoHorarios"].ToString(),
                    Horario = row["Descripcion"].ToString(),

                };

                // Agrega el objeto horarios  a la lista
                horarios.Add(hora);
            }

            // Retorna la lista de horarios obtenidas
            return horarios;
        }
    }
}
