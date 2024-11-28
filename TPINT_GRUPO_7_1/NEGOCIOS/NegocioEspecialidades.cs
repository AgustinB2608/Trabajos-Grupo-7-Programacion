using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;

namespace NEGOCIOS
{
    public class NegocioEspecialidades
    {
        private DaoEspecialidad Dao;
        public NegocioEspecialidades()
        {
            Dao = new DaoEspecialidad(); /// Inicializo el objeto DaoEspecialidad
        }

        /// Método para obtener los nombres de todas las especialidades 
        public List<Especialidades> ObtenerNombresEspecialidades()
        {
            return Dao.ObtenerNombEspecialidades(); /// Llamo al método del DAO y retorna el resultado
        }

        public DataTable ObtenerTurnosPorEspecialidad(string especialidad)
        {

            // Llamar al método correspondiente en la capa DAO
            return Dao.ObtenerTurnosPorEspecialidad(especialidad);
        }

        
    }
}
