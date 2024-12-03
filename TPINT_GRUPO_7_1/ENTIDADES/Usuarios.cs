using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Usuarios
    {
        public string CodUsuario { get; set; }
        public string Contraseña { get; set; }
        public Usuarios() { }

        public string getCodUsuario()
        {
            return CodUsuario;
        }

        public void setCodUsuario(string codUsuario)
        {
            CodUsuario = codUsuario;
        }
        public string getContraseña()
        {
            return Contraseña;
        }

        public void setContrasñea(string contraseña)
        {
            Contraseña = contraseña;
        }

    }

}
