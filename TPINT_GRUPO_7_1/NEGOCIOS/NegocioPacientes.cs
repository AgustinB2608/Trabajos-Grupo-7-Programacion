using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace NEGOCIOS
{
    class NegocioPacientes
    {
        private DaoPacientes Dao;

        public NegocioPacientes()
        {
            // Inicializa una instancia de DaoPacientes para interactuar con la base de datos de Pacientes
            Dao = new DaoPacientes();
        }

        public bool agregarPaciente(Pacientes Paciente)
        {
            // Instancia de la clase DaoPacientes para acceder a la base de datos
            DaoPacientes Dao = new DaoPacientes();

            // Llama al metodo agregarPaciente de DaoPacientes y almacena el resultado
            bool exito = Dao.agregarPaciente(Paciente);

            // Retorno true si fue agregado con exito si no false
            if (exito)
                return true;
            else
                return false;

        }
    }
}
