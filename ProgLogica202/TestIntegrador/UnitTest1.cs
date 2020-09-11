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

        /// <summary>
        /// Verifica que el producto se modifica correctamente, en este caso mediante la categoria
        /// </summary>
        [TestMethod]
        public void ModificarProducto_DevuelveProductoModif()
        {
            Inventario inv = new Inventario();
            Producto AEditar = new Producto
            {
                Nombre = "Pinza",
                IdProducto = 9,
                Categoria = "Plomeria",
                Precio = 135.00,
                StockActual = 80,
                Vendidos = 25

            };
            

            //Act
            Producto Devuelto = ProductoController.ModificarProducto("Pinza", AEditar);
            //Assert:
            Assert.AreEqual(AEditar.Categoria, Devuelto.Categoria);

       

        }
        [TestMethod]
        public void CalcularFacturacion_DevuelveCoef()
        {    //Arrange
            //varible de lo que espero que valga
            double Esperado = 10000.00;
                           
            //Creo el objeto para calcular el valor de facturacion            
            Producto ACalcular = new Producto()
            {
                Nombre = "Chancletas",
                IdProducto = 3,
                Categoria = "Plomeria",
                Precio = 100.00,
                StockActual = 5,
                Vendidos = 100

            };

            //Act y assert:
            //Si el calculo esta bien hecho, deberia dar 10.000 porque es 100 de precio * 100 de vendidos
            Assert.AreEqual(Esperado, ACalcular.Facturacion);

        }

        /// <summary>
        /// Este caso asegura que el producto devuelto es el que mas facturo,
        /// o sea el que tiene el coeficiente mas alto de la propiedad facturacion 
        /// que es una multiplicacion de los valores de precio y cantidad vendida
        /// </summary>
        [TestMethod]
        public void ProductoQueMasFacturo_returnsProductoConCoefMasAlto()
        {
            //Arrange:
            Inventario Inventario = new Inventario();
            Producto Facturado = new Producto
            {
                Nombre = "Bolsa Arena",
                IdProducto = 90,
                Categoria = "Construccion",
                Precio = 60.00,
                StockActual = 45,
                Vendidos = 1500
            };

            //Act
            Producto encontrado = FacturacionController.ProductoQueMasFacturo(Inventario);
            //Assert:
            Assert.AreEqual(Facturado.Nombre, encontrado.Nombre);

        }
        /// <summary>
        ///Este test se encarga de verificar que el producto que devuelve la función se encuentra dentro de la lista de productos
        ///primero elimina un producto y luego agrega otro, ya que la cant. maxima es 12. Si no lo encuentra, falla
        /// </summary>
        [TestMethod]
        public void AgregarProducto_returnsProductoAgregado()
        {
            //Arrange:
            Inventario Inventario = new Inventario();

            Producto Nuevo = new Producto
            {
                Nombre = "Tubo termoretractil por metro",
                IdProducto = 140,
                Categoria = "Electricidad",
                Precio = 10,
                StockActual = 300,
                Vendidos = 400
            };
            //act: 
            bool funciono = ProductoController.EliminarProducto(12);
            if (funciono)
            {
               
                Producto devuelto =  InventarioController.AgregarNuevoProducto(Nuevo);

                //Assert
                Assert.AreEqual(Nuevo, devuelto);


            }
            else
                Assert.Fail();


        }


    }
}
