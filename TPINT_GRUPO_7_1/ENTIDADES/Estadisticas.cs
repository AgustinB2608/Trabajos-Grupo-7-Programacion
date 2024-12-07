using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Estadisticas
    {
        public string Especialidad { get; set; }
        public string Mes { get; set; }
        public int TotalTurnos { get; set; }
        public int TotalAsistencias { get; set; }
        public int TotalFaltas { get; set; }
        public decimal PorcentajeAsistencias { get; set; }
        public decimal PorcentajeFaltas { get; set; }
    }
}
