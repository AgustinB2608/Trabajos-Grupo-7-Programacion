﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoEspecialidad
    {
        private Conexion ds = new Conexion();
        /// Metodo para obtener los nombres de todas las especialidades
        public List<Especialidades> ObtenerNombEspecialidades()
        {
            string consulta = "SELECT CodEspecialidad_ES AS CodigoEspecialidad, Descripcion_ES AS Descripcion, FROM Especialidades"; 
            
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Provincia para almacenar los resultados.
            List<Especialidades> especialidades = new List<Especialidades>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Creo un nuevo objeto Especialidades y asigna los valores de la fila actual.
                Especialidades especialidad = new Especialidades
                {
                    Id_Especialidad = row["CodigoEspecialidad"].ToString(),
                    DescripcionEspecialidad = row["Descripcion"].ToString()
                };

                // Agrega la provincia a la lista.
               especialidades.Add(especialidad);
            }
            return especialidades;
        }
    }
}
