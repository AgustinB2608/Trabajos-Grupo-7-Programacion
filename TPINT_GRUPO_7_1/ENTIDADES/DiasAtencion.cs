using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class DiasAtencion
    {
        private string _id_Dias;
        private string _Descripcion;
        public DiasAtencion()
        {

        }

        public string IdDias { get => _id_Dias; set => _id_Dias = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
