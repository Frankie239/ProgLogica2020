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
            
            Inventario inv = new Inventario();
           

            Console.WriteLine("Bienvenido, seleccione una opcion para comenzar");
            MenuController.Inicializar(inv);


            //Muestra el menu principal y devuelve el string concatenado de seleccion
            

            //Serializa todos los campos del producto mediante consola.
          
            //Des serializa un producto y lo muestra en la consola
            

            //Deserializa todos los productos
           
        }
    }
}
