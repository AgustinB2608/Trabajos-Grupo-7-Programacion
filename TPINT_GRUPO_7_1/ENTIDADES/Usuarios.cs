using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Usuarios
    {
        public string Legajo { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Usuarios() { }

        public string getLegajo()
        {
            return Legajo;
        }

        public void setLegajo(string Leg)
        {
            Legajo = Leg;
        }
        public string getContraseña()
        {
            return Contraseña;
        }

        public void setContraseña(string contraseña)
        {
            Contraseña = contraseña;
        }


    }

}
