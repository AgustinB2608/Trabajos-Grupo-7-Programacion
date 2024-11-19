using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Horarios
    {
        private string id_Horario;
        private string horarios;
        public Horarios()
        {

        }

        public string IdHorario { get => id_Horario; set => id_Horario = value; }
        public string Horario { get => horarios; set => horarios = value; }
    }
}
