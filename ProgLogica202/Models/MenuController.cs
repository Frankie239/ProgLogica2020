using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class MenuController
    {
        public static string MenuPrincipal()
        {
            string presionada = "0";
            Console.Write("1 Mostrar productos  2 Buscar producto  3 Agregar nuevo producto\n" +
                "4 Modificar Producto   5 Eliminar producto  6 Facturacion \n 7 salir \n");
            presionada = Console.ReadLine();
            switch (presionada)
            {
                case "1":
                    Console.WriteLine("1 Mostrar todos\n2 Mostrar segun stock\n3 Mostrar segun stock\n4 Produto mas vendido\n");
                    presionada += Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("1 Buscar segun nombre\n2 Buscar segun id\n");
                    presionada += Console.ReadLine();
                    break;



                case "6":
                    Console.WriteLine("1 Mostrar Producto que mas facturo\n2 Mostrar Facturacion por producto ordenada de menor a mayor\n3 Mostrar Facturacion total \n");
                    presionada += Console.ReadLine();
                    break;


            }
            return presionada;
        }

        public static void Inicializar()
        {
           //seleccion = MenuPrincipal();
        }

        public  static Producto Serializar()
        {
            Producto serializado = new Producto();
            Console.WriteLine("Ingrese nombre del producto");
            serializado.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese un id");
            serializado.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese una categoria");
            serializado.Categoria = Console.ReadLine();

            Console.WriteLine("Ingrese un precio (Es un double) ");
            serializado.Precio = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese una cantidad de stock");
            serializado.StockActual = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese una cantidad de vendidos");
            serializado.Vendidos = int.Parse(Console.ReadLine());


            return serializado;
        }

        public static void Deserializar(Producto prod)
        {
            if (prod != null)
            {
                Console.WriteLine("Producto:");
                Console.WriteLine("Nombre: " + prod.Nombre);
                Console.WriteLine("Categoria: " + prod.Categoria);
                Console.WriteLine("Id: " + prod.IdProducto);
                Console.WriteLine("Precio $" + prod.Precio);
                Console.WriteLine("Stock: " + prod.StockActual);
                Console.WriteLine("Vendidos: " + prod.Vendidos);
                Console.WriteLine("Facturacion: $" + prod.Facturacion);
            }
            else Console.WriteLine("El producto no existe");

        }

        public static void DesserializarEnMasa(List<Producto> devueltos)
        {
            Console.WriteLine("Nombre:  Id:   Categoria:   Precio:   Stock:   Vendidos:   Facturacion:  ");
            Console.WriteLine();
            foreach (Producto prod in devueltos)
            {
                Console.Write(prod.Nombre + "   " + prod.IdProducto + "   " + prod.Categoria + "   " + prod.Precio + "   " + prod.StockActual + "   " + prod.StockActual + "   " + prod.Facturacion + "   \n");
                //Si te gusta verlo como una lista de productos descomentar esto y comentar lo de arriba
                //Deserializar(prod);
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.ReadKey();
        }



    }
}
