using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Localidades
    {
        private string id_Localidad;
        private string descripcionLocalidad;
        private string id_Provincia;
        public Localidades()
        {

        }

        public string Id_Localidad { get => id_Localidad; set => id_Localidad = value; }
        public string DescripcionLocalidad1 { get => descripcionLocalidad; set => descripcionLocalidad = value; }
        public string Id_Provincia { get => id_Provincia; set { id_Provincia = value; } }
    }
}
