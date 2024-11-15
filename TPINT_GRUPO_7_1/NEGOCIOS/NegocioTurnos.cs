using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioTurnos
    {
        private DaoTurnos dao;

        public bool agregarTurno(string medico, string especialidad, string horario, string paciente, int duracion, string fecha, string estado)
        {
            // Convertir la fecha
            TimeSpan horarioTimeSpan = TimeSpan.Parse(horario);
            DateTime diaDateTime = DateTime.Parse(fecha);

            // Comprobar que el estado sea valido
            if (string.IsNullOrEmpty(estado) || (estado != "A" && estado != "P" && estado != "C"))
            {
                return false;
            }

            // Creamos un objeto turnos con los valores
            Turnos turno = new Turnos(especialidad, diaDateTime, horarioTimeSpan, paciente, medico, duracion, "A", estado);

            dao = new DaoTurnos();

            // Llamamos al metodo agregarTurno de DaoTurnos con el objeto turno
            bool exito = dao.agregarTurno(turno);

            // Retornamos true si el turno fue agregado correctamente
            return exito;
        }

    }
}
