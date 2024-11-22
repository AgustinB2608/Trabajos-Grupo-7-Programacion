using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Especialidades
    {

        private string _id_Especialidad;          
        private string _descripcionEspecialidad;  

        public Especialidades()
        {
           
        }

        
        public string Id_Especialidad
        {
            get => _id_Especialidad;   
            set => _id_Especialidad = value;  
        }

        
        public string DescripcionEspecialidad
        {
            get => _descripcionEspecialidad;  
            set => _descripcionEspecialidad = value; 
        }
    }
}
