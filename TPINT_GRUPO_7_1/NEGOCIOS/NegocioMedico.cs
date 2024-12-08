using System;
using System.Data;
using DATOS;
using ENTIDADES;

namespace NEGOCIOS
{
    public class NegocioMedico
    {
        private DaoMedicos daoMedico;
        private DaoUsuario daoUsuario;

        public NegocioMedico()
        {
            // Inicializa las instancias de los DAO necesarios
            daoMedico = new DaoMedicos();
            daoUsuario = new DaoUsuario();
        }

        public bool agregarMedico(Medico medico)
        {
            return daoMedico.agregarMedico(medico);
        }

        public bool eliminarMedico(string codMedico)
        {
            // Primero, elimina el médico de la base de datos
            bool exitoMedico = daoMedico.eliminarMedico(codMedico);

            // Luego, elimina el usuario asociado al médico
            if (exitoMedico)
            {
                // Usa el mismo `codMedico` para identificar al usuario asociado
                bool exitoUsuario = daoUsuario.eliminarUsuario(codMedico);
                if (!exitoUsuario)
                {
                    Console.WriteLine("El médico fue eliminado, pero no se pudo eliminar el usuario asociado.");
                }
                return exitoUsuario;
            }

            return false;
        }

        public bool modificarMedico(Medico medico)
        {
            return daoMedico.modificarMedico(medico);
        }

        public DataTable listarMedicos()
        {
            return daoMedico.listarMedicos();
        }

        public DataTable listarMedicoEspecifico(string CodMedico)
        {
            return daoMedico.listarMedicoEspecifico(CodMedico);
        }

        public DataTable listarMedicoEspecificoDni(string dni)
        {
            return daoMedico.listarMedicoEspecificoDni(dni);
        }

        public DataTable RetornarCodMedico(string dni)
        {
            return daoMedico.RetornarCodMedico(dni);
        }

        public DataTable MedicosSegunEspecialidad(string especialidad)
        {
            return daoMedico.MedicosSegunEspecialidad(especialidad);
        }

        public DataTable HorarioSegunMedico(string medico)
        {
            return daoMedico.HorariosPorMedico(medico);
        }

        public DataTable ObtenerTurnosNombMedico(string Nombre)
        {
            return daoMedico.ObtenerTurnosNombMedico(Nombre);
        }

        public bool verificarDni(string dni)
        {
            return daoMedico.VerificarDniExistente(dni);
        }
    }
}
