using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;
using System.Data;

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
             dao = new DaoMedicos();

            // Llama al metodo agregarMedico de DaoMedicos y almacena el resultado
            bool exito = dao.agregarMedico(medico);

            // Retorno true si fue exitoso sino false
            if (exito)
                return true;
            else
                return false;

        }

        public bool eliminarMedico(Medico medico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();

            // Llama al metodo eliminarMedico de DaoMedicos y almacena el resultado bool
            bool exito = dao.eliminarMedico(medico.getLegajo());

            // Retorno true si fue exitoso si no false
            return exito;

        }

        public bool modificarMedico(Medico medico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();
           

            // Llama al metodo modificarMedicos de DaoMedicos y almacena el resultado bool
            bool exito = dao.modificarMedico(medico);

            // Retorno true si fue exitoso si no false
            return exito;
        }

        public DataTable listarMedicos()
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();
            //retorna el datatable del metodo listarMedicos de DaoMedicos
            return dao.listarMedicos();
        }

        public DataTable listarMedicoEspecifico(string CodMedico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();

            //retorna el datatable del metodo listarMedicoEspecificp de DaoMedicos
            return dao.listarMedicoEspecifico(CodMedico);
        }
    }
}
