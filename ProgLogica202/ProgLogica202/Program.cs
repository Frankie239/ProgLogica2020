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
                             
                seleccion = MenuController.MenuPrincipal();
                switch (seleccion)
                {
                    case "11":
                                               
                        devueltos = inv.MostrarTodos();
                        MenuController.DesserializarEnMasa(devueltos);
                        break;

                    case "12":
                        Console.WriteLine("Ingrese categoria: ");
                        string cat = Console.ReadLine();
                        List<Producto> encontrados = new List<Producto>();
                        devueltos =  inv.MostrarSegunCategoria(cat);

                        MenuController.DesserializarEnMasa(devueltos);

                        break;
                    case "13":
                        Console.WriteLine("Categoria de stock: \n" +
                            "A sin stock\n" +
                            "B Stock menor a 100\n" +
                            "C Stock mayor a 100");
                        char elegido = char.Parse(Console.ReadLine());
                        devueltos = inv.MostrarSegunStock(elegido);

                        MenuController.DesserializarEnMasa(devueltos);


                        break;
                    case "14":
                        encontrado = inv.ProductoMasVendido();

                        MenuController.Deserializar(encontrado);

                        break;

                    case "21":
                        Console.WriteLine("Ingrese el nombre del producto a buscar");
                        string aBuscar = Console.ReadLine();

                        encontrado = inv.Buscar(aBuscar);

                        MenuController.Deserializar(encontrado);
                        break;
                      
                       
                        
                                                                  

                    case "22":
                        Console.WriteLine("Ingrese el id del producto a buscar");
                        int id = 0;
                        Int32.TryParse(Console.ReadLine(), out id);
                        encontrado = inv.Buscar(id);
                        if (encontrado != null)
                        {
                            MenuController.Deserializar(encontrado);
                        }
                        else Console.WriteLine("El producto que buscas no existe");
                        break;
                        
                    case "3":
                        encontrado = MenuController.Serializar();

                        if (inv.AgregarNuevoProducto(encontrado) != null)
                        {
                            Console.WriteLine("Producto agregado satisfactoriamente");

                        }
                        else Console.WriteLine("El inventario esta lleno, por favor, elimine un producto y vuelva a intentar");
                        break;

                    case "4":
                        encontrado = MenuController.Serializar();

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
                            MenuController.Deserializar(encontrado);
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
                            MenuController.Deserializar(encontrado);
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
                        MenuController.Deserializar(encontrado);
                        break;

                    case "62":
                        encontrados = Facturacion.ProductosPorFacturacion(inv);
                        MenuController.DesserializarEnMasa(encontrados);
                        break;

                    case "63":
                        double fact = Facturacion.MostrarFacturacionTotal(inv);
                        encontrados = Facturacion.ProductosPorFacturacion(inv);
                        encontrado = Facturacion.ProductoQueMasFacturo(inv);

                        Console.WriteLine("Facturacion total: " + fact);

                        Console.Write("Productos por facturacion");
                        MenuController.DesserializarEnMasa(encontrados);
                        Console.WriteLine();

                        Console.Write("Producto que mas facturo");
                        MenuController.Deserializar(encontrado);
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
            

            //Serializa todos los campos del producto mediante consola.
          
            //Des serializa un producto y lo muestra en la consola
            

            //Deserializa todos los productos
           
        }
    }
}
