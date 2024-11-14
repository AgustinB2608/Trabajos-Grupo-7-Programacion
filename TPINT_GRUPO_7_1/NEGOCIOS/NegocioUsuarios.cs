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

        public bool RegistrarUsuario(string legajo, string contraseña, string nombre, string apellido)
        {
            
            return daoUsuario.InsertarUsuario(legajo, contraseña, nombre, apellido);
        }
    }
}
