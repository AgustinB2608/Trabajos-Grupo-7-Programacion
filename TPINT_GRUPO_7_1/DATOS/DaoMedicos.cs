using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data;

namespace DATOS
{
    public class DaoMedicos
    {
        private Conexion ds = new Conexion();

        // Metodo para agregar un nuevo medico a la base de datos retorna true si el registro fue exitoso, o false en caso contrario.

        public bool agregarMedico(Medico medic)
        {
            string agregar = "EXEC SP_AgregarMedico @Provincia, @Localidad, @CodEspecialidad, @Dias, @HorarioAtencion, @Dni, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, @Email, @Telefono";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Provincia", medic.getProvincia()),
                new SqlParameter("@Localidad", medic.getLocalidad()),
                new SqlParameter("@CodEspecialidad", medic.getEspecialidad()),
                new SqlParameter("@Dias", medic.getDiasAtencion()),
                new SqlParameter("@HorarioAtencion", medic.getHorario()),
                new SqlParameter("@Dni", medic.getDni()),
                new SqlParameter("@Nombre", medic.getNombre()),
                new SqlParameter("@Apellido", medic.getApellido()),
                new SqlParameter("@Sexo", medic.getSexo()),
                new SqlParameter("@Nacionalidad", medic.getNacionalidad()),
                new SqlParameter("@FechaNacimiento", medic.getFechaNacimiento()),
                new SqlParameter("@Direccion", medic.getDireccion()),
                new SqlParameter("@Email", medic.getEmail()),
                new SqlParameter("@Telefono", medic.getCelular())               
            };

            int exito = ds.EjecutarConsultaSinRetorno(agregar, parametros);

            return exito > 0;
        }



        public bool eliminarMedico(string CodMedico)
        {
            //Consulta SQL para dar de baja un medico en la tabla Medicos

            //ejecuta un procedimiento almacenado enviando el codigo del medico a dar de baja

            string eliminar = "EXEC SP_bajaMedico @codMedico";

            // envia mi string codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@CodMedico", CodMedico)
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(eliminar, parametros);

            return exito > 0;
            
        }

        public bool modificarMedico(Medico medico)
        {

            // Consulta SQL para ejecutar el procedimiento almacenado que actualiza los valores
            string modificar = "EXEC SP_modificarMedico @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento" +
            "@Direccion, @Localidad, @Provincia, @Email, @Telefono, @CodEspecialidad, @Dias, @HorarioAtencion,";

            // envia los valores de mi obj medico como parametro

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", medico.getNombre()),
                new SqlParameter("@Apellido", medico.getApellido()),
                new SqlParameter("@Sexo", medico.getSexo()),
                new SqlParameter("@Nacionalidad", medico.getNacionalidad()),
                new SqlParameter("@FechaNacimiento", medico.getFechaNacimiento()),
                new SqlParameter("@Direccion", medico.getDireccion()),
                new SqlParameter("@Localidad", medico.getLocalidad()),
                new SqlParameter("@Provincia", medico.getProvincia()),
                new SqlParameter("@Email", medico.getEmail()),
                new SqlParameter("@Telefono", medico.getCelular()),
                new SqlParameter("@CodEspecialidad", medico.getEspecialidad()), 
                new SqlParameter("@Dias", medico.getDiasAtencion()),
                new SqlParameter("@HorarioAtencion", medico.getHorario()), 
            };

            //Ejecuta una consulta SQL usando un metodo que no devuelve un resultado (solo verifica exito o fracaso)
            int exito = ds.EjecutarConsultaSinRetorno(modificar, parametros);

            if (exito > 0) return true;
            return false;
        }

        public DataTable listarMedicos()
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae todos los registros
            string consulta = "EXEC SP_RegistrosMedicos";


            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsulta(consulta);

        }

        public DataTable listarMedicoEspecifico(string codMedico)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistroMedicoCod @CodMedico";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@CodMedico", codMedico)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public DataTable listarMedicoEspecificoDni(string dni)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "EXEC SP_retornarRegistroMedicoDni @Dni";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Dni", dni)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

        public DataTable RetornarCodMedico(string dni)
        {
            // Consulta SQL para ejecutar el procedimiento almacenado que trae el registro especificado
            string consulta = "SELECT CodMedico_ME AS CodMedico FROM Medicos WHERE Dni_ME = @Dni";

            // envia el valor del codMedico como parametro
            SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Dni", dni)
                };
            //retorna el datatable del metodo de Conexion
            return ds.EjecutarConsultaConParametros(consulta, parametros);

        }

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


    }
}
