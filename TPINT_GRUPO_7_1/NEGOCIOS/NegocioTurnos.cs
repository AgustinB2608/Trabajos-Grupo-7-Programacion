using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioTurnos
    {
        private DaoTurnos dao;
        public NegocioTurnos()
        {
            dao = new DaoTurnos();
        }

        public bool agregarTurno(string especialidad, string medico, string nombre, string apellido, string dni, string dia, TimeSpan horario)
        {
            // Convertir la fecha
            //TimeSpan horarioTimeSpan = TimeSpan.Parse(horario);

            // Creamos un objeto turnos con los valores
            Turnos turno = new Turnos(especialidad, medico, nombre, apellido, dni, dia, horario);

            dao = new DaoTurnos();

            // Llamamos al metodo agregarTurno de DaoTurnos con el objeto turno
            bool exito = dao.agregarTurno(turno);

            // Retornamos true si el turno fue agregado correctamente
            return exito;
        }
        public DataTable ObtenerTurnos()
        {
            return dao.ObtenerTurnos();
        }

        public DataTable ObtenerTurnosPorEstado(string estado)
        {

            // Llamar al método correspondiente en la capa DAO
            return dao.ObtenerTurnosPorEspecialidad(estado);
        }

        public DataTable ObtenerTurnosPorEspYEst(string especialidadSeleccionada, string estadoSeleccionado)
        {
            return dao.ObtenerTurnosPorEspYEst(especialidadSeleccionada, estadoSeleccionado);

        }

    }
}
