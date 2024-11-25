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

        public bool RegistrarUsuario(string contraseña, string tipousuario, string codmedico, string nombre, string apellido)
        {
            // Validar que el usuario no exista previamente
            if (UsuarioYaExiste(codmedico))
            {
                // Opcional: lanzar excepción o retornar false
                throw new Exception("El médico ya tiene un usuario registrado.");
            }

            // Delegar la inserción a la capa de datos
            return daoUsuario.InsertarUsuario(contraseña, tipousuario, codmedico, nombre, apellido);
        }

        private bool UsuarioYaExiste(string codmedico)
        {
            return daoUsuario.VerificarUsuarioExistente(codmedico);
        }
    }

}
