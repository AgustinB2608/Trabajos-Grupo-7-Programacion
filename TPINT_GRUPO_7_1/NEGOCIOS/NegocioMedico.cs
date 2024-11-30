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

            // Llama al método agregarMedico de DaoMedicos y devuelve el resultado
            return dao.agregarMedico(medico);

        }

        public bool eliminarMedico(string codmedico)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();

            // Llama al metodo eliminarMedico de DaoMedicos y almacena el resultado bool
            bool exito = dao.eliminarMedico(codmedico);

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

            //retorna el datatable del metodo listarMedicoEspecifico de DaoMedicos
            return dao.listarMedicoEspecifico(CodMedico);
        }

        public DataTable listarMedicoEspecificoDni(string dni)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();

            //retorna el datatable del metodo listarMedicoEspecificoDni de DaoMedicos
            return dao.listarMedicoEspecificoDni(dni);
        }
        
        public DataTable RetornarCodMedico(string dni)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoMedicos();

            //retorna el datatable del metodo RetornarCodMedico de DaoMedicos
            return dao.RetornarCodMedico(dni);
        }

        public DataTable MedicosSegunEspecialidad(string especialidad)
        {

            // Llamar al método correspondiente en la capa DAO
            return dao.MedicosSegunEspecialidad(especialidad);
        }
        public DataTable HorarioSegunMedico(string medico)
        {

            // Llamar al método correspondiente en la capa DAO
            return dao.HorariosPorMedico(medico);
        }
    }
}
