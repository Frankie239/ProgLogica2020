using System;
using Models;
using System.Collections.Generic;

namespace ProgLogica202
{

    //Esto lleva con un informe, necesita saber como analizamos y hacemos las cosas.

    class Program
    {
        static void Main(string[] args)
        {
            string seleccion = "0";
            Inventario inv = new Inventario();
            List<Producto> devueltos = new List<Producto>();
            Producto encontrado = new Producto();
            Console.WriteLine("Bienvenido, seleccione una opcion para comenzar");
            while (seleccion !="7")
            {

                
                seleccion = MenuPrincipal();
                switch (seleccion)
                {
                    case "11":
                                               
                        devueltos = inv.MostrarTodos();
                        DesserializarEnMasa(devueltos);
                        break;

                    case "12":
                        Console.WriteLine("Ingrese categoria: ");
                        string cat = Console.ReadLine();
                        List<Producto> encontrados = new List<Producto>();
                        devueltos =  inv.MostrarSegunCategoria(cat);

                        DesserializarEnMasa(devueltos);

                        break;
                    case "13":
                        Console.WriteLine("Categoria de stock: \n" +
                            "A sin stock\n" +
                            "B Stock menor a 100\n" +
                            "C Stock mayor a 100");
                        char elegido = char.Parse(Console.ReadLine());
                        devueltos = inv.MostrarSegunStock(elegido);

                        DesserializarEnMasa(devueltos);


                        break;
                    case "14":
                        encontrado = inv.ProductoMasVendido();

                        Deserializar(encontrado);

                        break;

                    case "21":
                        Console.WriteLine("Ingrese el nombre del producto a buscar");
                        string aBuscar = Console.ReadLine();

                        encontrado = inv.Buscar(aBuscar);

                        Deserializar(encontrado);
                        break;
                      
                       
                        
                                                                  

                    case "22":
                        Console.WriteLine("Ingrese el id del producto a buscar");
                        int id = 0;
                        Int32.TryParse(Console.ReadLine(), out id);
                        encontrado = inv.Buscar(id);
                        if (encontrado != null)
                        {
                            Deserializar(encontrado);
                        }
                        else Console.WriteLine("El producto que buscas no existe");
                        break;
                        
                    case "3":
                        encontrado = Serializar();

                        if (inv.AgregarNuevoProducto(encontrado) != null)
                        {
                            Console.WriteLine("Producto agregado satisfactoriamente");

                        }
                        else Console.WriteLine("El inventario esta lleno, por favor, elimine un producto y vuelva a intentar");
                        break;

                    case "4":
                        encontrado = Serializar();

                        Console.WriteLine("Ingrese un id o un nombre del producto a modificar");
                        string Select = Console.ReadLine();
                        
                        if (int.TryParse(Select, out id))
                        {
                            inv.ModificarProducto(id, encontrado);

                        }
                        else
                        {
                            inv.ModificarProducto(Select, encontrado);
                        }
                        break;
                        
                    case "5":

                        Console.WriteLine("Ingrese un id o un nombre del producto a eliminar");

                        Select = Console.ReadLine();

                        if (int.TryParse(Select, out id))
                        {
                            encontrado = inv.Buscar(id);
                            Deserializar(encontrado);
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
                            encontrado = inv.Buscar(Select);
                            Console.WriteLine("¿Esta seguro que desea eliminar este producto? Y/N");
                            Deserializar(encontrado);
                            Select = Console.ReadLine();
                            if (Select == "Y")
                            {
                                inv.EliminarProducto(Select);
                            }
                            else break;
                        }
                        break;

                    case "61":
                        encontrado = Facturacion.ProductoQueMasFacturo(inv);
                        Deserializar(encontrado);
                        break;

                    case "62":
                        encontrados = Facturacion.ProductosPorFacturacion(inv);
                        DesserializarEnMasa(encontrados);
                        break;

                    case "63":
                        double fact = Facturacion.MostrarFacturacionTotal(inv);
                        encontrados = Facturacion.ProductosPorFacturacion(inv);
                        encontrado = Facturacion.ProductoQueMasFacturo(inv);

                        Console.WriteLine("Facturacion total: " + fact);

                        Console.Write("Productos por facturacion");
                        DesserializarEnMasa(encontrados);
                        Console.WriteLine();

                        Console.Write("Producto que mas facturo");
                        Deserializar(encontrado);
                        break;

                    case "7":
                        Console.Write("Esta seguro que desea salir? Y/N");
                        Select = Console.ReadLine();
                        if (Select == "Y")
                            Environment.Exit(0);
                        
                        break;


                }
                
            }


            //Muestra el menu principal y devuelve el string concatenado de seleccion
            static string MenuPrincipal()
            {
                string presionada = "0";
                Console.Write("1 Mostrar productos  2 Buscar producto  3 Agregar nuevo producto\n" +
                    "4 Modificar Producto   5 Eliminar producto  6 Facturacion \n 7 salir \n");
                presionada = Console.ReadLine();
                switch(presionada)
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

            //Serializa todos los campos del producto mediante consola.
            static Producto Serializar()
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
            //Des serializa un producto y lo muestra en la consola
            static  void Deserializar(Producto prod)
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

            //Deserializa todos los productos
            static void DesserializarEnMasa(List<Producto> devueltos)
            {
                Console.WriteLine("Nombre:  Id:   Categoria:   Precio:   Stock:   Vendidos:   Facturacion:  ");
                Console.WriteLine();
                foreach (Producto prod in devueltos)
                {
                    Console.Write(prod.Nombre + "   " + prod.IdProducto + "   " + prod.Categoria + "   " + prod.Precio + "   " + prod.StockActual + "   " + prod.StockActual + "   "+prod.Facturacion+"   \n");
                    //Si te gusta verlo como una lista de productos descomentar esto y comentar lo de arriba
                    //Deserializar(prod);
                    Console.WriteLine();

                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
