using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Medico
    {
        private string CodMedico;
        private string Nombre;
        private string Apellido;
        private string Dni;
        private string Legajo;
        private string Email;
        private string Celular;
        private string Nacionalidad;
        private string Sexo;
        private string Provincia;
        private string Localidad;
        private string Direccion;
        private string FechaNacimiento;
        private string Especialidad;
        private string DiasAtencion;
        private string Horario;
        private string Usuario;
        private string Contraseña;


        public Medico() { }

        public string getCodMedico()
        {
            return CodMedico;
        }

        public void setCodMedico(string codMedico)
        {
            CodMedico = codMedico;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public void setNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string getApellido()
        {
            return Apellido;
        }

        public void setApellido(string apellido)
        {
            Apellido = apellido;
        }

        public string getDni()
        {
            return Dni;
        }

        public void setDni(string dni)
        {
            Dni = dni;
        }

        public string getLegajo()
        {
            return Legajo;
        }

        public void setLegajo(string legajo)
        {
            Legajo = legajo;
        }

        public string getEmail()
        {
            return Email;
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        public string getCelular()
        {
            return Celular;
        }

        public void setCelular(string celular)
        {
            Celular = celular;
        }

        public string getNacionalidad()
        {
            return Nacionalidad;
        }

        public void setNacionalidad(string nacionalidad)
        {
            Nacionalidad = nacionalidad;
        }

        public string getSexo()
        {
            return Sexo;
        }

        public void setSexo(string sexo)
        {
            Sexo = sexo;
        }

        public string getProvincia()
        {
            return Provincia;
        }

        public void setProvincia(string provincia)
        {
            Provincia = provincia;
        }

        public string getLocalidad()
        {
            return Localidad;
        }

        public void setLocalidad(string localidad)
        {
            Localidad = localidad;
        }

        public string getDireccion()
        {
            return Direccion;
        }

        public void setDireccion(string direccion)
        {
            Direccion = direccion;
        }

        public string getFechaNacimiento()
        {
            return FechaNacimiento;
        }

        public void setFechaNacimiento(string fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }

        public string getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(string especialidad)
        {
            Especialidad = especialidad;
        }

        public string getDiasAtencion()
        {
            return DiasAtencion;
        }

        public void setDiasAtencion(string diasAtencion)
        {
            DiasAtencion = diasAtencion;
        }

        public string getHorario()
        {
            return Horario;
        }

        public void setHorario(string horario)
        {
            Horario = horario;
        }

        public void setUsuario(string usuario)
        {
            Usuario = usuario;
        }

        public string getUsuario()
        {
            return Usuario;
        }

        public void setContraseña(string contraseña)
        {
            Contraseña = contraseña;
        }

        public string getContraseña()
        {
            return Contraseña;
        }
    }

}
