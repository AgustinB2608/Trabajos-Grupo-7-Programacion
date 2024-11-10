using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class DiasAtencion
    {
        private int id_Dia;
        private string dias;
        public DiasAtencion()
        {

        }

        public int IdDia { get => id_Dia; set => id_Dia = value; }
        public string Dias { get => dias; set => dias = value; }
    }
}
