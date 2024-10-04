using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_7
{
    public class Producto
    {
    private int c_IdProducto;
    private string c_NombreProducto;
    private int c_IdProveedor;
    private string c_CantidadPorUnidad;
    private decimal c_PrecioUnidad;
    private bool c_Suspendido; 

        public Producto() { }
        public Producto(int c_IdProducto, string c_NombreProducto, int c_IdProveedor, int c_IdCategoria, string c_CantidadPorUnidad, decimal c_PrecioUnidad, bool c_Suspendido)
        {
            this.c_IdProducto= c_IdProducto; ;
            this.c_NombreProducto = c_NombreProducto;
            this.c_IdProveedor = c_IdProveedor;
            this.c_CantidadPorUnidad = c_CantidadPorUnidad;
            this.c_PrecioUnidad = c_PrecioUnidad;
            this.c_Suspendido = c_Suspendido;
        }

        public int IdProducto
        {
            set { c_IdProducto = value; }
            get { return c_IdProducto; }
        }
        public string NombreProducto
        {
            set { c_NombreProducto = value; }
            get { return c_NombreProducto; }
        }
        public int IdProveedor
        {
            set { c_IdProveedor = value; }
            get { return c_IdProveedor; }
        }
        public string CantidadPorUnidad
        {
            set { c_CantidadPorUnidad = value; }
            get { return c_CantidadPorUnidad; }
        }
        public decimal PrecioUnidad
        {
            set { c_PrecioUnidad = value; }
            get { return c_PrecioUnidad; }
        }
        public bool Suspendido
        {
            set { c_Suspendido = value; }
            get { return c_Suspendido; }
        }
        
    }
}