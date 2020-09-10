using Microsoft.VisualStudio.TestTools.UnitTesting;

using Models;
using ProgLogica202.Controllers;
namespace TestIntegrador
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verificar que realmente sea el producto mas caro, o sea el de mayor precio.
        /// </summary>
        [TestMethod]
        
        public void ProductoMasCaro_returns_ProdConMayorPrecio()
        {
            //Arrange:
            Inventario inventario = new Inventario();
            Producto MasCaro = new Producto
            {
                Nombre = "Pinza",
                IdProducto = 9,
                Categoria = "Herramientas",
                Precio = 135.00,
                StockActual = 80,
                Vendidos = 25

            };


            //Act:
            Producto Encontrado = InventarioController.ProductoMasCaro();

            //Assert:
            Assert.AreEqual(MasCaro.Nombre, Encontrado.Nombre);



        }
    }
}
