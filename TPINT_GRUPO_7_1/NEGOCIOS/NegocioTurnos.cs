using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioTurnos
    {
        private DaoTurnos dao;
        public NegocioTurnos()
        {
            dao = new DaoTurnos();
        }

        public bool agregarTurno(Turnos turno)
        {
            
            dao = new DaoTurnos();

            // Llamamos al metodo agregarTurno de DaoTurnos con el objeto turno
            bool exito = dao.agregarTurno(turno);

            // Retornamos true si el turno fue agregado correctamente
            return exito;
        }


        public DataTable ObtenerTurnos()
        {
            return dao.ObtenerTurnos();
        }

      

     
        public DataTable ObtenerTurnosFiltrados(string especialidad, string estado, string nombreMedico)
        {
            

            return dao.ObtenerTurnosFiltrados(especialidad, estado, nombreMedico);
        }

        public DataTable ObtenerTurnoPorID(string turnoID)
        {
            return dao.ObtenerTurnoPorID(turnoID);
        }
        
        


        // 06/12
        public DataTable TurnoEspecifico(string codespecialidad, string codmedico, string dni, string fecha, TimeSpan hora)
        {
            return dao.TurnoEspecifico(codespecialidad, codmedico, dni, fecha, hora);
        }

        public string RetornarCodigoTurno(string codespecialidad, string codmedico, string dni, string fecha, TimeSpan hora)
        {
            string codigoturno = dao.RetornarCodigoTurno(codespecialidad, codmedico, dni, fecha, hora);

            return codigoturno;
        }

        public bool ModificarEstado(string estado, string codturno)
        {
            return dao.ModificarEstado(estado, codturno);
        }

        public bool AgregarObservacion (string codturno, string observacion)
        {
            return dao.AgregarObservacion(codturno, observacion);
        }
    }
}
