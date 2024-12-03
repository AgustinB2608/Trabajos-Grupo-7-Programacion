using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Usuarios
    {
        public string CodMedico { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Usuarios() { }

        public string getCodMedico()
        {
            return CodMedico;
        }

        public void setCodMedico(string codMedico)
        {
            CodMedico = codMedico;
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
