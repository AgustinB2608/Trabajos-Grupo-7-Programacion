using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DaoEspecialidad
    {
        private Conexion ds = new Conexion();
        /// Metodo para obtener los nombres de todas las especialidades
        public DataTable ObtenerNombEspecialidades()
        {
            string consulta = "SELECT NombreEspecialidad_ES FROM Especialidad"; 
            return ds.EjecutarConsulta(consulta); 
        }
    }
}
