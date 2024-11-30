using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Pacientes
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }         
        public string Nacionalidad { get; set; } 
        public bool Estado { get; set; }

    }
}
