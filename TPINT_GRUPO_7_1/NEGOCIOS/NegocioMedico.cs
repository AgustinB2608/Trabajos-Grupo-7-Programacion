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
            dao = new DaoMedicos();
        }

        public bool agregarMedico(Medico medic)
        {
            DaoMedicos dao = new DaoMedicos();

            bool exito = dao.agregarMedico(medic);

            if (exito)
                return true;
            else
                return false;

        }
    }
}
