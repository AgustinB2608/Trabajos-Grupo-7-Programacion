using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace NEGOCIOS
{
    public class NegocioMedico
    {
        private DaoMedicos dao;

        public NegocioMedico() {
            // Inicializa una instancia de DaoMedicos para interactuar con la base de datos de medicos
            dao = new DaoMedicos();
        }

        public bool agregarMedico(Medico medico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            DaoMedicos dao = new DaoMedicos();

            // Llama al metodo agregarMedico de DaoMedicos y almacena el resultado
            bool exito = dao.agregarMedico(medico);

            // Retorno true si fue exitoso sino false
            if (exito)
                return true;
            else
                return false;

        }

        public bool eliminarMedico(Medico Medico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            DaoMedicos dao = new DaoMedicos();

            // Llama al metodo eliminarMedico de DaoMedicos y almacena el resultado
            bool exito = dao.eliminarMedico(Medico.codMedico);

            // Retorno true si fue exitoso si no false
            if (exito)
                return true;
            else
                return false;

        }
    }
}
