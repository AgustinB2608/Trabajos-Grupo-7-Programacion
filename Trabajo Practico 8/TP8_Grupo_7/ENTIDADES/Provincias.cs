﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Provincias
    {
        private int id_Provincia;
        private char[] DescripcionProvincia;

        public Provincias() { 
        
        }

        public int Id_Provincia { get => id_Provincia; set => id_Provincia = value; }
        public char[] DescripcionProvincia1 { get => DescripcionProvincia; set => DescripcionProvincia = value; }
    }
}