using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.IO;
using System.Reflection;

namespace ConstruccionesForm
{
    public partial class Form1 : Form
    {
        private Inventario inventario = new Inventario();
        public Form1()
        {
            InitializeComponent();
            CargarEnGrid(inventario.MostrarTodos());
        }

        /// <summary>
        /// Carga todos los datos en la grilla ordenados por su id  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCargar_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarTodos());
            ClearTextbox();
            cargarThumbnail("0");
        }

        /// <summary>
        /// Limpia todas las textbox para que no quedn datos sueltos
        /// </summary>
        private void ClearTextbox()
        {
            TextboxId.Text = "";
            TextBoxNombre.Text =  "";
            textBoxCategoria.Text = "";
            textBoxPrecio.Text = "";
            textBoxStock.Text = "";
            textBoxVendidos.Text = "";
            labelFacturacion.Text = "";
        }
        /// <summary>
        /// Carga en grid todos los elementos del inventario
        /// </summary>
        /// <param name="prods">Lista de productos a cargar en la grilla</param>
        private void CargarEnGrid(List<Producto> prods)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = prods;
            GridViewProductos.DataSource = bs;
            bs.ResetBindings(false);


        }
     

        
        /// <summary>
        /// Carga y ordena los productos por el coef. de facturacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFacturacion_Click(object sender, EventArgs e)
        {
            //List<Producto> prods = inventario.MostrarSegunStock('A');
            List<Producto> prods = Facturacion.ProductosPorFacturacion(inventario);
            CargarEnGrid(prods);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// Carga los datos en las textbox a traves del click en una de sus rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewProductos_MouseClick(object sender, MouseEventArgs e)
        {
            string id = GridViewProductos.SelectedRows[0].Cells[0].Value.ToString();

            TextboxId.Text = id;
            TextBoxNombre.Text = GridViewProductos.SelectedRows[0].Cells[1].Value.ToString();
            textBoxCategoria.Text = GridViewProductos.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPrecio.Text = GridViewProductos.SelectedRows[0].Cells[3].Value.ToString();
            textBoxStock.Text = GridViewProductos.SelectedRows[0].Cells[4].Value.ToString();
            textBoxVendidos.Text = GridViewProductos.SelectedRows[0].Cells[5].Value.ToString();
            labelFacturacion.Text = String.Format("${0}",GridViewProductos.SelectedRows[0].Cells[6].Value.ToString());
            cargarThumbnail(id);
           


        }
        /// <summary>
        /// Agarra la informacion desde las textbox y las pone en un producto para luego manipularlo
        /// </summary>
        /// <returns>Producto con toda la informacion para cargar en la lista</returns>
        private Producto FromTextboxToObject()
        {
            Producto Arranged = new Producto();
            if (CheckCompletion())
            {

                Arranged.IdProducto = int.Parse(TextboxId.Text);
                Arranged.Nombre = TextBoxNombre.Text;
                Arranged.Categoria = textBoxCategoria.Text;
                Arranged.Precio = int.Parse(textBoxPrecio.Text);
                Arranged.StockActual = int.Parse(textBoxStock.Text);
                Arranged.Vendidos = int.Parse(textBoxVendidos.Text);


            }
            else
            {
                string message = string.Format("Por favor, complete todos los campos");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, "Campos no completos", buttons);
                Arranged.Nombre = "";

            }
            return Arranged;




        }

        /// <summary>
        /// Carga una imagen en la UI a partir del id del producto(Debe ser el mismo nombre en la carpeta imagenes)
        /// </summary>
        /// <param name="id">id del producto con el mism nombre que la imagen</param>
        private void cargarThumbnail(string id)
        {
            string ImagesDirectory =
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "img/"
                );

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox.Load(ImagesDirectory+id+".jpg");
                //ictureBox.Image = Image.FromFile(string.Format(@"C:\Users\Fran\source\repos\ProgLogica2020\ProgLogica202\ConstruccionesForm));
               // Image.FromFile(string.Format(@"\img\" + id + ".jpg"));
            }
            catch (FileNotFoundException)
            {
                pictureBox.Image = Image.FromFile(string.Format(@"C:\Users\Fran\source\repos\ProgLogica2020\ProgLogica202\ConstruccionesForm\img\notFound.jpg"));
            }
            
        }
        private void ClearThumbnail()
        {

            Graphics g = Graphics.FromImage(pictureBox.Image);
            g.Clear(pictureBox.BackColor);
        }

        private bool CheckCompletion()
        {
            if (string.IsNullOrEmpty(TextBoxNombre.Text) || string.IsNullOrEmpty(textBoxCategoria.Text) || string.IsNullOrEmpty(TextboxId.Text) || string.IsNullOrEmpty(textBoxPrecio.Text))
            {
                return false;
            }
            else
                return true;
        }


    

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            bool flag = false;//Flag para saber si se pudo eliminar
            if(!string.IsNullOrEmpty(TextboxId.Text)) //Si no esta vacio el textbox
            {
                Producto prod = inventario.Buscar(int.Parse(TextboxId.Text));//busca por id
                if(prod != null)
                {
                    //Y si existe, lo borra
                    flag = inventario.EliminarProducto(int.Parse(TextboxId.Text));
                }
                

                
            }

            else if(!string.IsNullOrEmpty(TextBoxNombre.Text)) //Sino, busca el dato con un string, de la misma forma que el anterior
            {
               flag = inventario.EliminarProducto(TextBoxNombre.Text);
            }
            else
            {
                NoEncontrado();//Sino, muestra un error message
                
            }

            if (flag)//SI salio bien, refresca
            {
                CargarEnGrid(inventario.MostrarTodos());
            }

               

        }


        /// <summary>
        /// Agrega un producto si la cantidad de productos es menor a 12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (inventario.Productos.Count != 12)//Si la lista tiene menos de 12 productos
            {
                //Metelo en un objeto
                Producto prod = FromTextboxToObject();

                if (!string.IsNullOrEmpty(prod.Nombre))
                {
                    //Agregalo a la lista
                    inventario.AgregarNuevoProducto(prod);
                    //Refrescame la lista
                    CargarEnGrid(inventario.MostrarTodos());
                }
            
            }
            else
            {
                //Mostrame un error de que esta lleno y un ok
                string message = string.Format("El inventario esta lleno, elimine algun producto e intente nuevamente");
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, "Inventario lleno", buttons);
            }
           
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Producto prod = FromTextboxToObject();
            if (!string.IsNullOrEmpty(prod.Nombre))
            {

                inventario.ModificarProducto(int.Parse(TextboxId.Text), prod);
                CargarEnGrid(inventario.MostrarTodos());
            }
        }


        /// <summary>
        /// Carga los objetos que tengan stock 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStockZero_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('A'));
        }
        /// <summary>
        /// Carga los objetos que tengan stock menor a 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('B'));
        }
        /// <summary>
        /// Carga los objetos que tengan stock mayor a 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('C'));
        }
        /// <summary>
        /// Muestra el prod. mas vendido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Producto encontrado = inventario.ProductoMasVendido();
            List<Producto> prods = new List<Producto>
            {
                encontrado
            };

            CargarEnGrid(prods);
        }
        /// <summary>
        /// Muestra segun categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunCategoria());
        }

        /// <summary>
        /// Carga un producto a partir de su id o su string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            List<Producto> prods = new List<Producto>();
            if (!string.IsNullOrEmpty(TextboxId.Text))
            {
                prod = inventario.Buscar(int.Parse(TextboxId.Text));
                FromObjectToTextbox(prod);



            }
            else if (!string.IsNullOrEmpty(TextBoxNombre.Text))
            {
                prods = inventario.BuscarBulk(TextBoxNombre.Text);
                CargarEnGrid(prods);
                if (prods.Count != 0)
                {
                    Producto first = prods[0];
                    FromObjectToTextbox(first);
                }
                else NoEncontrado();
                


            }
            else
            {
                NoEncontrado();
                prod = null;

            }

            if (prod != null)
            {
                FromObjectToTextbox(prod);
                cargarThumbnail(prod.IdProducto.ToString());
            }


        }

        /// <summary>
        /// serializa un producto hacia las textbox
        /// </summary>
        /// <param name="prod">Producto a cargar</param>
        private void FromObjectToTextbox(Producto prod)
        {
            if (prod != null)
            {
                TextboxId.Text = prod.IdProducto.ToString();
                TextBoxNombre.Text = prod.Nombre;
                textBoxCategoria.Text = prod.Categoria;
                textBoxPrecio.Text = prod.Precio.ToString();
                textBoxStock.Text = prod.StockActual.ToString();
                textBoxVendidos.Text = prod.Vendidos.ToString();

            }
            else
                NoEncontrado();
            
        }

        /// <summary>
        /// si un producto no esta, muestra un messageBox
        /// </summary>
        private void NoEncontrado()
        {
            string message = string.Format("El producto que buscas no existe");
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, "prod no existe", buttons);
        }

        private bool Existe(int id)
        {
            Producto prod = inventario.Buscar(id);
            if (prod.IdProducto != null && prod.Nombre != null) return true;
            else return false;
        }
    }
}

