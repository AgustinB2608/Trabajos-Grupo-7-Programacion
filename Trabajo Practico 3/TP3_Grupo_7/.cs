using System;
using System.Web;

namespace TP3_Grupo_7
{
    public class MyModule1 : IHttpModule
    {
        /// <summary>
        /// Deberá configurar este módulo en el archivo Web.config de su
        /// web y registrarlo en IIS para poder usarlo. Para obtener más información
        /// consulte el vínculo siguiente: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Miembros de IHttpModule

        public void Dispose()
        {
            //Ponga aquí el código de limpieza.
        }

        public void Init(HttpApplication context)
        {
            // El siguiente es un ejemplo de cómo se puede controlar el evento LogRequest y proporcionar 
            // una implementación de registro personalizado para él
            context.LogRequest += new EventHandler(OnLogRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //Aquí puede poner la lógica de registro personalizado
        }
    }
}
