using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    
    public class Inventario
    {

        
        const int MaxProductos = 12;
        public Producto[] Productos =
        {
            new Producto
            {
              Nombre = "Ladrillo",
              IdProducto = 12,
              Categoria = "Construccion",
              Precio =80.00,
              StockActual = 120,
              Vendidos = 50           


            },
            new Producto
            {
              Nombre = "Destornillador",
              IdProducto = 15,
              Categoria = "Herramientas",
              Precio =95.00,
              StockActual = 124,
              Vendidos = 13

            },
            new Producto
            {
              Nombre = "Bombillas",
              IdProducto = 4,
              Categoria = "Electricidad",
              Precio =20.00,
              StockActual = 300,
              Vendidos = 100

            },
            new Producto
            {
              Nombre = "Caños de agua",
              IdProducto = 1,
              Categoria = "Plomaria",
              Precio =100.00,
              StockActual = 0,
              Vendidos = 500

            },
            new Producto
            {
              Nombre = "Pinza",
              IdProducto = 9,
              Categoria = "Herramientas",
              Precio =135.00,
              StockActual = 80,
              Vendidos = 25

            },
            new Producto
            {
              Nombre = "Flexible Caño",
              IdProducto = 10,
              Categoria = "Plomeria",
              Precio =100.00,
              StockActual = 5,
              Vendidos = 495
            },

            new Producto
            {
              Nombre = "canillas",
              IdProducto = 11,
              Categoria = "Plomeria",
              Precio =45.00,
              StockActual = 15,
              Vendidos = 1200
            },

            new Producto
            {
              Nombre = "Bolsa Arena",
              IdProducto = 90,
              Categoria = "Construccion",
              Precio =60.00,
              StockActual =45,
              Vendidos = 1500
            },

            new Producto
            {
              Nombre = "Martillo",
              IdProducto = 31,
              Categoria = "Herramientas",
              Precio =120.00,
              StockActual = 150,
              Vendidos = 95
            },

            new Producto
            {
              Nombre = "cable por metro",
              IdProducto = 7,
              Categoria = "Electricidad",
              Precio =50.00,
              StockActual = 98,
              Vendidos = 30
            }
        };

        static public List<Producto> MostrarTodos()
        {
            throw new NotImplementedException();

        }

        public List<Producto> MostrarSegunCategoria(string Categoria)
        {
            throw new NotImplementedException();
        }
        public List<Producto> MostrarSegunStock(char seleccion)
        {
            throw new NotImplementedException();
        }

        public Producto ProductoMasVendido()
        {
            throw new NotImplementedException();
        }

        public Producto ProductoMasCaro()
        {
            throw new NotImplementedException();
        }

        public Producto AgregarNuevoProducto(Producto aAgregar)
        {
            throw new NotImplementedException();
        }
    }
}
