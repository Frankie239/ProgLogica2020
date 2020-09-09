using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Producto
    {
        string Nombre;
        int IdProducto;
        string Categoria;
        double Precio;
        int StockActual;
        int Vendidos;
        double Facturacion { get { throw new NotImplementedException(); } }
    }
}
