using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoTurnos
    {
        private Conexion ds = new Conexion();

        public bool agregarTurno(Turnos turno)
        {
            string consulta = "INSERT INTO Turnos (Especialidad_TU, Dia_TU, Paciente_TU, Medico_TU, Duracion_TU, CodEstadoTurno_TU, Estado)" +
                               " VALUES (@Especialidad, @Dia, @Paciente, @Medico, @Duracion, @CodEstadoTurno, @Estado)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@Especialidad", turno.getEspecialidad()),
                    new SqlParameter("@Dia", turno.getDia()),
                    new SqlParameter("@Paciente", turno.getPaciente()),
                    new SqlParameter("@Medico", turno.getMedico()),
                    new SqlParameter("@Duracion", turno.getDuracion()),
                    new SqlParameter("@CodEstadoTurno", turno.getCodEstadoTurno()),
                    new SqlParameter("@Estado", turno.getEstado())
            };

            int exito = ds.EjecutarConsultaSinRetorno(consulta, parametros);

            return exito > 0;
        }

    }
}
