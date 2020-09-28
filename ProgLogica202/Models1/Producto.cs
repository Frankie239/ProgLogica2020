using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Producto
    {
        public int IdProducto { set; get; }
        public string Nombre { set; get; }
        
        public string Categoria { set; get; }
        public double Precio { set; get; }
        public int StockActual { set; get; }
        public int Vendidos { set; get; }


        public double Facturacion
        {
            get { return Precio * Vendidos; }
        }




    }
}
