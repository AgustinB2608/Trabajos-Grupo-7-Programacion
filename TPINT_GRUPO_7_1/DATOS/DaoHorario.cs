using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public DataTable EncontrarTurno (string hora, string fecha, string codespecialidad, string codmedico)
        {
            string consulta = "EXEC SP_EncontrarTurno @hora, @fecha, @codespecialidad, @codmedico";

            DataTable dt = ds.EjecutarConsulta(consulta);

            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@hora", hora),
                     new SqlParameter("@fecha", fecha),
                     new SqlParameter("@codespecialidad", codespecialidad),
                     new SqlParameter("@codmedico", codmedico)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);
        }
    }
}
