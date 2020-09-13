using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public class Inventario
    {


        const int MaxProductos = 12;
        public List<Producto> Productos = new List<Producto>()
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

        public Inventario()
        {
            Productos.Capacity = MaxProductos;
        }

        public List<Producto> MostrarTodos()
        {
            return Productos;

        }

        public List<Producto> MostrarSegunCategoria(string Categoria)
        {
            List<Producto> productos = new List<Producto>();
            foreach (Producto prod in Productos)
            {
                if (prod.Categoria == Categoria)
                {
                    productos.Add(prod);

                }


            }

            return productos;
        }
        public List<Producto> MostrarSegunStock(char seleccion)
        {
            List<Producto> Encontrados = new List<Producto>();
           
            switch (seleccion)
            {
                case 'A':

                    Encontrados = Buscar(0, int.MaxValue);
                    
                    
                    
                    break;

                case 'B':
                    Encontrados = Buscar(0,100);

                    break;

                case 'C':
                    Encontrados = Buscar(100, int.MaxValue);
                    break;

                default:

                    break;
            }
            SortByStock(Encontrados);
            return Encontrados;
        }

        public Producto ProductoMasVendido()
        {
            //Pa refactoring
            List<Producto> encontrados = Productos;
            encontrados.Sort((x, y) => x.Vendidos.CompareTo(y.Vendidos));
            return encontrados[encontrados.Count-1];
            
        }

        public Producto ProductoMasCaro()
        {
            //Pa refactoring
            List<Producto> encontrados = Productos;
            encontrados.Sort((x, y) => x.Precio.CompareTo(y.Precio));
            return encontrados[encontrados.Count - 1];
        }

        public Producto AgregarNuevoProducto(Producto aAgregar)
        {
            bool pudo = true;
            try
            {
                Productos.Add(aAgregar);
            }
            catch (ArgumentOutOfRangeException)
            {
                pudo = false;
                return null;
            }
            if (pudo)
            {
                return aAgregar;
            }
        }
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

        /// <summary>
        /// Busca un producto segun un stock maximo y uno minimo, si quieres que sea de un stock especifico, van los dos del mismo.
        /// </summary>
        /// <param name="stockMin">Stock minimo a buscar</param>
        /// <param name="StockMax">Stock Maximo a buscar</param>
        /// <returns>Una lista de productos en el rango del stock</returns>
        private List<Producto> Buscar(int stockMin, int StockMax)
        {
            List<Producto> encontrados = new List<Producto>();
            foreach (Producto prod in this.Productos)
            {
                if (prod.StockActual >= stockMin && prod.StockActual <= StockMax)
                    encontrados.Add(prod);

            }

            return encontrados;


        }
        /// <summary>
        /// Ordena una lista por el campo stock de los productos
        /// </summary>
        /// <param name="prod">La Lista a Ordenar</param>
        /// <returns>La lista ordenada por el parametro stock</returns>
        private List<Producto> SortByStock(List<Producto> prod) 
        {
            prod.Sort((x, y) => x.StockActual.CompareTo(y.StockActual));

            return prod;
        }
    }
}
