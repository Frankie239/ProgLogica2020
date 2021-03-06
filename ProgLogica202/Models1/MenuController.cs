﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class MenuController
    {
        
        /// <summary>
        /// Muestra el menu principal
        /// </summary>
        /// <returns>Devuelve la decision la cual se quiere seguir en el menu secundario</returns>
        private static string MenuPrincipal()
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

        /// <summary>
        /// Inicializa la aplicacion llamando al menu principal siempre y cuando sea distinto a 7(Escape de la aplicacion)
        /// </summary>
        /// <param name="inv">inventario a modificar</param>
        public static void Inicializar(Inventario inv)
        {
            string seleccion = "0";

            while (seleccion != "7")
            {
                seleccion = MenuPrincipal();
                MenuSecundario(inv, seleccion);
            }


        }
        /// <summary>
        /// Serializa un objeto desde el 
        /// </summary>
        /// <returns>El producto serializado para utilizar</returns>
        private static Producto Serializar()
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

        /// <summary>
        /// Agarra un objeto y lo muestra en pantalla en forma de una fila de una tabla
        /// </summary>
        /// <param name="prod">Producto a mostrar</param>
        private static void Deserializar(Producto prod)
        {
            if (prod != null)
            {
                StringBuilder mySb = new StringBuilder();
                mySb.Append("|");
                mySb.Append(string.Format("{0, -18}  | ",prod.Nombre));
                mySb.Append(string.Format("{0, -14}  | ", prod.Categoria));
                mySb.Append(string.Format("{0, -6}  | ", prod.IdProducto));
                mySb.Append(string.Format("{0, -6}  | ", prod.Precio));
                mySb.Append(string.Format("{0, -6}  | ", prod.StockActual));
                mySb.Append(string.Format("{0, -6}  | ", prod.Vendidos));
                mySb.AppendLine(string.Format("${0, -6}  | ", prod.Facturacion));

                Console.Write(mySb.ToString());
            }
            else Console.WriteLine("El producto no existe");

        }

        /// <summary>
        /// Muestra los headers de la tabla
        /// </summary>
        private static void Headers()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black; 
            StringBuilder mySb = new StringBuilder();
            mySb.Append(string.Format("{0, -19}  | ", "Nombre: "));
            mySb.Append(string.Format("{0, -14}  | ", "Categoria: "));
            mySb.Append(string.Format("{0, -6}  | ", "Id: "));
            mySb.Append(string.Format("{0, -4}| ", "Precio: "));
            mySb.Append(string.Format("{0, -4} | ", "Stock: "));
            mySb.Append(string.Format("{0, -4}  | ", "Vend: "));
            mySb.Append(string.Format("{0, -4}   | ", "Fact: "));

            Console.WriteLine(mySb.ToString());

            Console.BackgroundColor = ConsoleColor.Black;
           
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Deserializa todos los productos de la lista y los muestra en consola
        /// </summary>
        /// <param name="devueltos">Lista de productos a deserializar</param>
        private static void DesserializarEnMasa(List<Producto> devueltos)
        {

            Headers();
            
            foreach (Producto prod in devueltos)
            {
                Deserializar(prod);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        /// <summary>
        /// Muestra el menu secundario en la consola que tiene las decisiones para seguir, tambien llama los metodos pertinentes
        /// </summary>
        /// <param name="inv">inventario a modificar</param>
        /// <param name="seleccion">seleccion que viene de una anterior iteracion con el menu principal</param>
        private static void MenuSecundario(Inventario inv, string seleccion)
        {



            switch (seleccion)
            {
                case "11":

                    //Mostar todos
                    MenuController.DesserializarEnMasa(inv.MostrarTodos());
                    break;

                case "12":
                    //Mostrar por categoria
                    Console.WriteLine("Ingrese categoria: ");
                    string cat = Console.ReadLine();


                    MenuController.DesserializarEnMasa(inv.MostrarSegunCategoria(cat));

                    break;
                case "13":
                    //Mostrar segun stock
                    Console.WriteLine("Categoria de stock: \n" +
                        "A sin stock\n" +
                        "B Stock menor a 100\n" +
                        "C Stock mayor a 100");
                    char elegido = char.Parse(Console.ReadLine());
                    MenuController.DesserializarEnMasa(inv.MostrarSegunStock(elegido));


                    break;
                case "14":

                    //Muestra producto mas vendido
                    MenuController.Deserializar(inv.ProductoMasVendido());

                    break;

                case "21":
                    //Busca un producto por su nombre
                    Console.WriteLine("Ingrese el nombre del producto a buscar");
                    string aBuscar = Console.ReadLine();


                    MenuController.Deserializar(inv.Buscar(aBuscar));
                    break;





                case "22":
                    //busca un producto por su id
                    Console.WriteLine("Ingrese el id del producto a buscar");
                    int id = 0;
                    Int32.TryParse(Console.ReadLine(), out id);
                    Producto producto = inv.Buscar(id);
                    Deserializar(producto);
                    break;

                case "3":
                    //Agrega un producto a la lista de inventario
                    producto = MenuController.Serializar();
                    if (inv.Productos.Count != 12)
                    {
                        if (inv.AgregarNuevoProducto(producto) != null)
                        {
                            Console.WriteLine("Producto agregado satisfactoriamente");

                        }
                    }
                    
                    else Console.WriteLine("El inventario esta lleno, por favor, elimine un producto y vuelva a intentar");
                    break;

                case "4":
                    //Modifica un producto
                    producto = MenuController.Serializar();

                    Console.WriteLine("Ingrese un id o un nombre del producto a modificar");
                    string Select = Console.ReadLine();

                    if (int.TryParse(Select, out id))//Si es un int: 
                    {
                        //usa la sobrecarga del id
                        inv.ModificarProducto(id, producto);

                    }
                    else
                    {
                        //Sino, usa la del nombre
                        inv.ModificarProducto(Select, producto);
                    }
                    break;

                case "5":

                    Console.WriteLine("Ingrese un id o un nombre del producto a eliminar");

                    Select = Console.ReadLine();

                    if (int.TryParse(Select, out id))
                    {

                        MenuController.Deserializar(inv.Buscar(id));
                        Console.WriteLine("¿Esta seguro que desea eliminar este producto? Y/N");






                        Select = Console.ReadLine();
                        if (Select == "Y")
                        {
                            inv.EliminarProducto(id);
                        }
                        else break;


                    }
                    else
                    {

                        Console.WriteLine("¿Esta seguro que desea eliminar este producto? Y/N");
                        Deserializar(inv.Buscar(Select));
                        Select = Console.ReadLine();
                        if (Select == "Y")
                        {
                            inv.EliminarProducto(Select);
                        }
                        else break;
                    }
                    break;

                case "61":
                    //Muestra el producto que mas facturo
                    MenuController.Deserializar(Facturacion.ProductoQueMasFacturo(inv));
                    break;

                case "62":
                    //Muestra los prods ordenados por facturacion
                    MenuController.DesserializarEnMasa(Facturacion.ProductosPorFacturacion(inv));
                    break;

                case "63":
                    //Muestra todos los campos de facturacin
                    double fact = Facturacion.MostrarFacturacionTotal(inv);
                    List<Producto> encontrados = Facturacion.ProductosPorFacturacion(inv);
                    Producto encontrado = Facturacion.ProductoQueMasFacturo(inv);

                    Console.WriteLine("Facturacion total: " + fact);

                    Console.Write("Productos por facturacion");
                    MenuController.DesserializarEnMasa(encontrados);
                    Console.WriteLine();

                    Console.Write("Producto que mas facturo");
                    MenuController.Deserializar(encontrado);
                    break;

                case "7":
                    //confirmacion de salida
                    Console.Write("Esta seguro que desea salir? Y/N");
                    Select = Console.ReadLine();
                    if (Select == "Y")
                        Environment.Exit(0);

                    break;


            }


        }



    }
}
