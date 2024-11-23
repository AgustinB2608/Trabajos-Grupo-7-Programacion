using DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioUsuarios
    {
        private DaoUsuario daoUsuario = new DaoUsuario();

        public bool RegistrarUsuario (string contraseña, string tipousuario, string codmedico, string nombre, string apellido)
        {
            
            return daoUsuario.InsertarUsuario(contraseña, tipousuario, codmedico, nombre, apellido);
        }
    }
}
