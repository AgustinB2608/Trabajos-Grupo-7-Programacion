using System;
using System.Data;
using System.Data.SqlClient;
using DATOS;
using ENTIDADES;

namespace NEGOCIO
{
    public class LoginNegocio
    {
        private DaoLogin daoLogin;

        public LoginNegocio()
        {
            daoLogin = new DaoLogin(); // Inicializa DaoLogin para interactuar con la base de datos
        }

       public Login ValidarLogin(string legajo, string contrasena)
        {
            int legajoInt = int.Parse(legajo);
            return daoLogin.ValidarLogin(legajoInt, contrasena);
        }

        public void GuardarUsuario(Login usuario)
        {
            daoLogin.InsertUsuario(usuario);
        }
    }
}