using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Localidades
    {
        private int id_Localidad;
        private string DescripcionProvincia;
        private int id_Provincia;
        public Localidades()
        {

        }

        public int Id_Localidad { get => id_Localidad; set => id_Localidad = value; }
        public string DescripcionLocalidad { get => DescripcionLocalidad; set => DescripcionLocalidad = value; }
        public int Id_Provincia { get => id_Provincia; set { id_Provincia = value; } }
    }
}
