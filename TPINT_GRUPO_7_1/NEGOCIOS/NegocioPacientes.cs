using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

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
            // Llama al método agregarPaciente de DaoPacientes y devuelve el resultado
            return dao.agregarPaciente(paciente);
        }
    }
}


