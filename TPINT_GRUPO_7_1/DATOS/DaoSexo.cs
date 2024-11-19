using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DaoSexo
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todos los sexos(masculino/femenino) desde la base de datos
        public List<Sexo> ObtenerSexo()
        {
            // Consulta SQL para seleccionar datos de la tabla Sexo
            string consulta = "SELECT CodSexo_SX, Descripcion FROM Sexo";

            // Ejecuta la consulta y obtiene los resultados en un DataTable
            DataTable dt = ds.EjecutarConsulta(consulta);

            // Creo una lista de objetos Sexo para almacenar los resultados.
            List<Sexo> sexo = new List<Sexo>();

            // Recorre cada fila del DataTable.
            foreach (DataRow row in dt.Rows)
            {
                // Crea un nuevo objeto sexo y asigna los valores de la fila actual
                Sexo sex = new Sexo
                {
                    CodSexo_SX = row["CodSexo_SX"].ToString(),
                    DescripcionSexo_SX = row["Descripcion"].ToString()
                };

                // Agrega el objeto sexo  a la lista
                sexo.Add(sex);
            }

            // Retorna la lista de sexos obtenidas
            return sexo;
        }
    }
}
