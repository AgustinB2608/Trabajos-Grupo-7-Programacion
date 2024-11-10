﻿using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIOS
{
    public class NegocioEspecialidades
    {
        private DaoEspecialidad Dao;
        public NegocioEspecialidades()
        {
            Dao = new DaoEspecialidad(); /// Inicializo el objeto DaoEspecialidad
        }

        /// Método para obtener los nombres de todas las especialidades 
        public DataTable ObtenerNombresEspecialidades()
        {
            return Dao.ObtenerNombEspecialidades(); /// Llamo al método del DAO y retorna el resultado
        }



    }
}