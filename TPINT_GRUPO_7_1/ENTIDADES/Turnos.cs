using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Turnos
    {
        private string Especialidad_TU;
        private DateTime Dia_TU;
        private TimeSpan Horario_TU;
        private string Nombre_TU;
        private string Apellido_TU;
        private string Dni_TU;
        private string Medico_TU;
        private int Duracion_TU;
        private string CodEstadoTurno_TU;
        private string Estado;

        public Turnos(string especialidad, DateTime dia, TimeSpan horario, string nombre, string apellido, string dni, string medico, int duracion, string codEstadoTurno, string estado)
        {
            Especialidad_TU = especialidad;
            Dia_TU = dia;
            Horario_TU = horario;
            Nombre_TU = nombre;
            Apellido_TU = apellido;
            Dni_TU = dni;
            Medico_TU = medico;
            Duracion_TU = duracion;
            CodEstadoTurno_TU = codEstadoTurno;
            Estado = estado;
        }

        public string getEspecialidad()
        {
            return Especialidad_TU;
        }

        public void setEspecialidad(string especialidad)
        {
            Especialidad_TU = especialidad;
        }

        public DateTime getDia()
        {
            return Dia_TU;
        }

        public void setDia(DateTime dia)
        {
            Dia_TU = dia;
        }

        public TimeSpan getHorario()
        {
            return Horario_TU;
        }

        public void setHorario(TimeSpan horario)
        {
            Horario_TU = horario;
        }

        public string getNombre()
        {
            return Nombre_TU;
        }

        public void setNombre(string nombre)
        {
            Nombre_TU = nombre;
        }

        public string getApellido()
        {
            return Apellido_TU;
        }

        public void setApellido(string apellido)
        {
            Apellido_TU = apellido;
        }

        public string getDni()
        {
            return Dni_TU;
        }

        public void setDni(string dni)
        {
            Dni_TU = dni;
        }

        public string getMedico()
        {
            return Medico_TU;
        }

        public void setMedico(string medico)
        {
            Medico_TU = medico;
        }

        public int getDuracion()
        {
            return Duracion_TU;
        }

        public void setDuracion(int duracion)
        {
            Duracion_TU = duracion;
        }

        public string getCodEstadoTurno()
        {
            return CodEstadoTurno_TU;
        }

        public void setCodEstadoTurno(string estadoTurno)
        {
            CodEstadoTurno_TU = estadoTurno;
        }

        public string getEstado()
        {
            return Estado;
        }

        public void setEstado(string estado)
        {
            Estado = estado;
        }
    }
}
