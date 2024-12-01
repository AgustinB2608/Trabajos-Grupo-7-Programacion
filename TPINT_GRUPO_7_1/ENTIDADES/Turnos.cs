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
        private string Medico_TU;
        private string Nombre_TU;
        private string Apellido_TU;
        private string Dni_TU;
        private string Dia_TU;
        private TimeSpan Horario_TU;
        private string CodEstadoTurno_TU;
        private string Estado;

        public Turnos(string especialidad, string medico, string nombre, string apellido, string dni, string dia, TimeSpan horario)
        {
            Especialidad_TU = especialidad;
            Medico_TU = medico;
            Nombre_TU = nombre;
            Apellido_TU = apellido;
            Dni_TU = dni;
            Dia_TU = dia;
            Horario_TU = horario;
        }

        public string getEspecialidad()
        {
            return Especialidad_TU;
        }

        public void setEspecialidad(string especialidad)
        {
            Especialidad_TU = especialidad;
        }

        public string getDia()
        {
            return Dia_TU;
        }

        public void setDia(string dia)
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
