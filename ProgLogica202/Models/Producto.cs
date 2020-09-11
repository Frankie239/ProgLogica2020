using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Producto
    {
        public string Nombre;
        public int IdProducto;
        public string Categoria;
        public double Precio;
        public int StockActual;
        public int Vendidos;
       public double Facturacion { get { return Precio * Vendidos; } }
        public Producto ModificarProducto(string nombre, Producto aModificar)
        {
            throw new NotImplementedException();
        }
        public bool EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }
        public bool EliminarProducto(string nombre)
        {
            throw new NotImplementedException();
        }


    }
}
