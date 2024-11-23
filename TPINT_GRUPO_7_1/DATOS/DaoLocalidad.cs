using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class DaoLocalidad
    {
        private Conexion ds = new Conexion();

        // Metodo para obtener la lista de todas las Localidades desde la base de datos
        public List<Localidades> ObtenerLocalidadesPorProvincia(string idProvincia)
        {
            // Consulta SQL para obtener localidades por provincia
            string consulta = "SELECT CodLocalidad_LO AS CodigoLocalidad, Descripcion_LO AS Descripcion, CodProvincia_LO AS CodigoProvincia " +
                              "FROM Localidades WHERE CodProvincia_LO = @IdProvincia";

            // Crear parámetros SQL
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@IdProvincia", idProvincia)
            };

            // Ejecutar la consulta con parámetros
            DataTable dt = ds.EjecutarConsultaConParametros(consulta, parametros);

            // Convertir el DataTable en una lista de localidades
            List<Localidades> listaLocalidades = new List<Localidades>();
            foreach (DataRow row in dt.Rows)
            {
                Localidades localidad = new Localidades
                {
                    Id_Localidad = row["CodigoLocalidad"].ToString(),
                    DescripcionLocalidad1 = row["Descripcion"].ToString(),
                    Id_Provincia = row["CodigoProvincia"].ToString()
                };
                listaLocalidades.Add(localidad);
            }

            return listaLocalidades;
        }

        public List<Localidades> ObtenerLocalidad()
        {
            string consulta = "SELECT CodLocalidad_LO AS CodigoLocalidad, Descripcion_LO AS Descripcion, CodProvincia_LO AS CodigoProvincia FROM Localidades";

            DataTable dt = ds.EjecutarConsulta(consulta);

            List<Localidades> listaLocalidades = new List<Localidades>();

            foreach (DataRow row in dt.Rows)
            {
                Localidades localidad = new Localidades
                {
                    Id_Localidad = row["CodigoLocalidad"].ToString(),
                    DescripcionLocalidad1 = row["Descripcion"].ToString(),
                    Id_Provincia = row["CodigoProvincia"].ToString()
                };

                listaLocalidades.Add(localidad);
            }

            return listaLocalidades;
        }
    }
}
