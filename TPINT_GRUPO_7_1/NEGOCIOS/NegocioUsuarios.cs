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

        public bool RegistrarUsuario(string codmedico, string contraseña)
        {
            // Validar que el usuario no exista previamente
            if (UsuarioYaExiste(codmedico))
            {
                throw new Exception("El médico ya tiene un usuario registrado.");
            }

            // Delegar la inserción a la capa de datos
            return daoUsuario.InsertarUsuario(codmedico, contraseña);
        }

        private bool UsuarioYaExiste(string codmedico)
        {
            return daoUsuario.VerificarUsuarioExistente(codmedico);
        }

        public bool modificarUsuario(Usuarios usuarios)
        {
            // Llama al metodo modificarUsuario de DaoUsuario y almacena el resultado bool
            bool exito = daoUsuario.modificarUsuario(usuarios);

            // Retorno true si fue exitoso si no false
            return exito;
        }

        public DataTable listarUsuarioEspecifico(string CodUsuario)
        {
            //retorna el datatable del metodo listarMedicoEspecifico de DaoMedicos
            return daoUsuario.listarUsuarioEspecifico(CodUsuario);
        }

        public bool eliminarUsuario(string codmedico)
        {
            bool exito = daoUsuario.eliminarMedico(codmedico);

            return exito;

        }
    }

}
