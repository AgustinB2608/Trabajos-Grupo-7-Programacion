using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Sexo
    {
        private int CodSexo;
        private string DescripcionSexo;
        public Sexo()
        {

        }

        public int codSexo { get => CodSexo; set => CodSexo = value; }
        public string descripcionSexo { get => DescripcionSexo; set => DescripcionSexo = value; }
    }
}
