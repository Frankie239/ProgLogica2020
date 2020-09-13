using System;
using Models;

namespace ProgLogica202
{

    //Esto lleva con un informe, necesita saber como analizamos y hacemos las cosas.

    class Program
    {
        static void Main(string[] args)
        {
            Inventario inv = new Inventario();
            inv.MostrarSegunStock('A');
           
        }
    }
}
