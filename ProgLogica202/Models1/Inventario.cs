using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Models
{

    public class Inventario
    {


        const int MaxProductos = 12;
        /// <summary>
        /// Carga el contenido default de la clase
        /// </summary>
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
              IdProducto = 23,
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

        /// <summary>
        /// Carga en una lista todos los productos de la lista privada productos
        /// </summary>
        /// <returns>Lista de productos ordenados por id</returns>
        public List<Producto> MostrarTodos()
        {
            Productos.Sort((x, y) => x.IdProducto.CompareTo(y.IdProducto));
            return Productos;

        }
        /// <summary>
        /// Elige una categoria y devuelve todos los productos de esa categoria
        /// </summary>
        /// <param name="Categoria">string categoria para buscar</param>
        /// <returns>Lista de productos de la categoria especificada</returns>
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

        /// <summary>
        /// Ordena y devuelve los productos por su cantidad de stock
        /// </summary>
        /// <param name="seleccion">Char, A es stock 0, B es menos de 100 y C es mayor de 100</param>
        /// <returns>Lista de productos con stock especifico</returns>
        public List<Producto> MostrarSegunStock(char seleccion)
        {
            List<Producto> Encontrados = new List<Producto>();

            switch (seleccion)
            {
                case 'A':

                    Encontrados = Buscar(0, 0);



                    break;

                case 'B':
                    Encontrados = Buscar(0, 100);

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

        /// <summary>
        /// Busca el producto con mas unidades vendidas
        /// </summary>
        /// <returns>el producto mas vendido</returns>
        public Producto ProductoMasVendido()
        {
            //Pa refactoring
            List<Producto> encontrados = Productos;
            encontrados.Sort((x, y) => x.Vendidos.CompareTo(y.Vendidos));
            return encontrados[encontrados.Count - 1];

        }
        /// <summary>
        /// Producto con un mayor precio
        /// </summary>
        /// <returns>El producto de mayor precio</returns>

        public Producto ProductoMasCaro()
        {
            //Pa refactoring
            List<Producto> encontrados = Productos;
            encontrados.Sort((x, y) => x.Precio.CompareTo(y.Precio));
            return encontrados[encontrados.Count - 1];
        }
        /// <summary>
        /// Agrega un producto si la cantidad de productos del stock es menor a la cantidad de productos maximos
        /// </summary>
        /// <param name="aAgregar">Producto que se quiere agregar</param>
        /// <returns>Returna el producto que se agrego, si no se pudo, retorna null</returns>
        public Producto AgregarNuevoProducto(Producto aAgregar)
        {
            bool pudo = true; //Flag para controlar si se pudo.
             
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

            else return null;

        }

        /// <summary>
        /// Modifica un producto a traves de su nombre, modifica el producto de MENOR id
        /// </summary>
        /// <param name="nombre">nombre del prod a modificar</param>
        /// <param name="aModificar">producto con la informacion a modificar</param>
        /// <returns>El producto modificado, si no, retorna null</returns>
        public Producto ModificarProducto(string nombre, Producto aModificar)
        {
            Producto encontrado = Buscar(nombre);

            return SeekDestroyAndAdd(encontrado, aModificar);
        }
        /// <summary>
        /// Modifica un producto a traves de su id
        /// </summary>
        /// <param name="id">id del producto a modificar</param>
        /// <param name="aModificar">producto con la informacion a modificar</param>
        /// <returns>El producto modificado, si no, retorna null</returns>
        public Producto ModificarProducto(int id, Producto aModificar)
        {
            Producto encontrado = Buscar(id);

            return SeekDestroyAndAdd(encontrado, aModificar);
        }

        /// <summary>
        /// Ordena los objetos por su categoria y los devuelve ordenados
        /// </summary>
        /// <returns>Lista de los productos ordenados por cateogria</returns>
        public List<Producto> MostrarSegunCategoria()
        {
            List<Producto> encontrados = Productos;
            encontrados.Sort((x, y) => x.Categoria.CompareTo(y.Categoria));
            return encontrados;
        }

        /// <summary>
        /// Elimina un producto por su id
        /// </summary>
        /// <param name="id">Id del producto a eliminar</param>
        /// <returns>Booleano True si se pudo eliminar, False si no.</returns>
        public bool EliminarProducto(int id)
        {
            int countInicial = Productos.Count;

            Productos.Remove(Buscar(id));

            if (countInicial - 1 == Productos.Count)
                return true;

            else return false;
        }
        /// <summary>
        /// Elimina un producto por su nombre, si hay dos coen el mismo, elimina el de menor id
        /// </summary>
        /// <param name="nombre">Nombre del producto a eliminar</param>
        /// <returns>Booleano True si se pudo eliminar, False si no.</returns>
        public bool EliminarProducto(string nombre)
        {
            int countInicial = Productos.Count;
            Productos.Remove(Buscar(nombre));

            if (countInicial - 1 == Productos.Count)
                return true;

            else return false;


        }


        /// <summary>
        /// Busca un producto segun un stock maximo y uno minimo, si quieres que sea de un stock especifico, van los dos del mismo.
        /// </summary>
        /// <param name="stockMin">Stock minimo a buscar</param>
        /// <param name="StockMax">Stock Maximo a buscar</param>
        /// <returns>Una lista de productos en el rango del stock</returns>
        public List<Producto> Buscar(int stockMin, int StockMax)
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
        /// Busca un producto por su id
        /// </summary>
        /// <param name="id">el id del producto que se quiere buscar</param>
        /// <returns>el producto encontrado, si no se ecnuentra, retorna null.</returns>
        public Producto Buscar(int id)
        {
            foreach (Producto prod in Productos)
            {
                if (prod.IdProducto == id)
                    return prod;
            }
            return null;
        }
        /// <summary>
        /// Busca un producto por su nombre, si hay dos con el mismo retorna el de menor id
        /// </summary>
        /// <param name="nombre">Nombre del producto a buscar</param>
        /// <returns>El producto encontrado de menor id.</returns>
        public List<Producto> BuscarBulk(string nombre)
        {
            string pattern = string.Format(@"({0})", nombre);
            RegexOptions options =RegexOptions.Multiline | RegexOptions.IgnoreCase;
            Productos.Sort((x, y) => x.IdProducto.CompareTo(y.IdProducto));
            List<Producto> prods = new List<Producto>();

            foreach (Producto prod in Productos)
            {
                if (Regex.IsMatch(prod.Nombre, pattern,options)){
                    prods.Add(prod);
                }
                   
            }
            
            return prods;
          
            
        }
        public Producto Buscar(string nombre)
        {
            Productos.Sort((x, y) => x.IdProducto.CompareTo(y.IdProducto));
            foreach (Producto prod in Productos)
            {
                if (prod.Nombre == nombre)
                {
                    return prod;
                }

                

            }
            return null;

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

        /// <summary>
        /// Busca un producto, lo elimina y lo agrega nuevamente, esto es para haer un update de un producto especificoo
        /// </summary>
        /// <param name="encontrado">El producto al que se haga el update</param>
        /// <param name="aModificar">El producto que trae las modificaciones</param>
        /// <returns>El producto actualizado</returns>
        private Producto SeekDestroyAndAdd(Producto encontrado, Producto aModificar)
        {
            if (encontrado != null)
            {
                Productos.Remove(encontrado);

                Productos.Add(aModificar);
                return aModificar;
            }
            else
                return null;
        }
    }
}
