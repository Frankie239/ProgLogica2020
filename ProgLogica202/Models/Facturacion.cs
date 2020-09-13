using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class Facturacion
    {
        /// <summary>
        /// Busca el producto que mas facturo de una lista de inventario
        /// </summary>
        /// <param name="inventario">El inventario al que debe buscar el producto</param>
        /// <returns>El producto mas facturado</returns>
       public static Producto ProductoQueMasFacturo(Inventario inventario)
       {
            List<Producto> ListFacturacion = ProductosPorFacturacion(inventario);
           
            int index = ListFacturacion.Count;

            return ListFacturacion[index - 1];
       }

       public static List<Producto> ProductosPorFacturacion(Inventario inventario)
       {
            List<Producto> Ordenados  = new List<Producto>();
            Ordenados = inventario.Productos;
            Ordenados.Sort((x, y) => x.Facturacion.CompareTo(y.Facturacion));
            return Ordenados;
       }

        public static double  MostrarFacturacionTotal(Inventario inventario)
        {
            double Acumulacion = 0;

            foreach(Producto prod in inventario.Productos)
            {
                Acumulacion += prod.Facturacion;
            }

            return Acumulacion;
        }

    }
}
