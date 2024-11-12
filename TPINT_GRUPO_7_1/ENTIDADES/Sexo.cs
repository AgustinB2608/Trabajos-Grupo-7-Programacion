using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Sexo
    {
        private string codSexo;
        private string descripcionSexo;

        public Sexo()
        {
        }

        public string CodSexo_SX
        {
            get => codSexo;
            set => codSexo = value;
        }

        public string DescripcionSexo_SX
        {
            get => descripcionSexo;
            set => descripcionSexo = value;
        }
    }
}
