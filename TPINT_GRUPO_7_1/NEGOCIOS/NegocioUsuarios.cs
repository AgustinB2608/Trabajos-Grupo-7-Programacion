using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioUsuarios
    {
        private DaoUsuario daoUsuario = new DaoUsuario();

        public bool InsertarUsuario(string codmedico, string nombre, string apellido, string contraseña)
        {
            // Validar que el usuario no exista previamente
            if (UsuarioYaExiste(codmedico, contraseña))
            {
                return false;
            }

            // Delegar la inserción a la capa de datos
            return daoUsuario.InsertarUsuario(codmedico, nombre, apellido, contraseña);
        }

        private bool UsuarioYaExiste(string codmedico, string contraseña)
        {
            return daoUsuario.VerificarUsuarioExistente(codmedico, contraseña);
        }

        public bool modificarUsuario(Usuarios usuarios)
        {
            // Llama al metodo modificarUsuario de DaoUsuario y almacena el resultado bool
            bool exito = daoUsuario.modificarUsuario(usuarios);

            // Retorno true si fue exitoso si no false
            return exito;
        }

        public bool eliminarUsuario(string codmedico)
        {
           return daoUsuario.eliminarUsuario(codmedico);
        }

        public string recuperarContraseñaMedico(string dni, string legajo)
        {
            return daoUsuario.RecuperarContraseña(dni, legajo);
        }

        public string recuperarLegajo(string dni)
        {
            return daoUsuario.recuperarLegajo(dni);
        }
    }

}
