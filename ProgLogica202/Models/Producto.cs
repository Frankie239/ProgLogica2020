﻿using System;
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
        double Facturacion { get { throw new NotImplementedException(); } }
       

    }
}
