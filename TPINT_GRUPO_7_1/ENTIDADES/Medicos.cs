using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Medico
    {
        public string codMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Legajo { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string FechaNacimiento { get; set; }
        public string Especialidad { get; set; }
        public string DiasAtencion { get; set; }
        public string Horario { get; set; }
        public bool Estado { get; set; }
    }
}
