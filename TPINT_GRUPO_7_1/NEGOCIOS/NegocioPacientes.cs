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

        public bool modificarPaciente(Pacientes Paciente)
        {
            dao = new DaoPacientes();

            bool exito = dao.modificarPaciente(Paciente);

            // Retorno true si fue exitoso si no false
            if (exito)
                return true;
            else
                return false;
        }

        public DataTable listarPacientes()
        {
            dao = new DaoPacientes();

            return dao.listarPacientes();
        }

        public DataTable listarPacienteEspecifico(string CodPaciente)
        {
            dao = new DaoPacientes();

            return dao.listarPacienteEspecifico(CodPaciente);
        }

    }
}


