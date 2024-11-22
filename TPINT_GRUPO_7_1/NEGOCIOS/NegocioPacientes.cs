using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;
using System.Data.SqlClient;
using System.Data;

namespace NEGOCIOS
{
    public class NegocioPacientes
    {
        private DaoPacientes dao;

        public NegocioPacientes()
        {
            // Inicializa la instancia de DaoPacientes para interactuar con la base de datos de Pacientes
            dao = new DaoPacientes();
        }

        public bool AgregarPaciente(Pacientes paciente)
        {
            // Instancia de la clase DaoMedicos para acceder a la base de datos
            dao = new DaoPacientes();
            // Llama al método agregarPaciente de DaoPacientes y devuelve el resultado
            return dao.agregarPaciente(paciente);
        }

        public bool eliminarPaciente(Pacientes Paciente)
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            dao = new DaoPacientes();

            // Llama al metodo eliminarPaciente de DaoPacientes y almacena el resultado bool
            bool exito = dao.eliminarPaciente(Paciente.codPaciente);

            // Retorno true si fue exitoso si no false
            if (exito)
                return true;
            else
                return false;

        }

        public bool eliminarPacienteDni(string DNI)
        {
            
            dao = new DaoPacientes();

            // Llama al metodo eliminarPacienteDNI
            bool exito = dao.eliminarPacienteDNI(DNI);

            // Retorno true si fue exitoso
            if (exito)
                return true;
            else
                return false;

        }



        public bool modificarPaciente(Pacientes Paciente)
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            dao = new DaoPacientes();


            // Llama al metodo modificarPaciente de DaoPacientes y almacena el resultado bool
            bool exito = dao.modificarPaciente(Paciente);

            // Retorno true si fue exitoso si no false
            return exito;
        }

        public DataTable listarPacientes(string contenido = "")
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            dao = new DaoPacientes();
            //retorna el datatable del metodo listarPacientes de DaoPacientes
            return dao.listarPacientes(contenido);
        }

        public DataTable listarPacienteEspecificoCod(string CodPaciente)
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            dao = new DaoPacientes();

            //retorna el datatable del metodo listarPacienteEspecifico de DaoPacientes
            return dao.listarPacienteEspecifico(CodPaciente);
        }
        public DataTable listarPacienteEspecificoDni(string dni)
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            dao = new DaoPacientes();

            //retorna el datatable del metodo listarPacienteEspecificoDni de DaoPacientes
            return dao.listarPacienteEspecificoDni(dni);
        }
    }
}


