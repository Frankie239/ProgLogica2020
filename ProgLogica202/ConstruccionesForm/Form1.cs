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

        private void ButtonCargar_Click(object sender, EventArgs e)
        {




            CargarEnGrid(inventario.MostrarTodos());








        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarEnGrid(List<Producto> prods)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = prods;
            GridViewProductos.DataSource = bs;
            bs.ResetBindings(false);


        }
     

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ButtonFacturacion_Click(object sender, EventArgs e)
        {
            //List<Producto> prods = inventario.MostrarSegunStock('A');
            List<Producto> prods = Facturacion.ProductosPorFacturacion(inventario);
            CargarEnGrid(prods);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void GridViewProductos_SelectionChanged_1(object sender, EventArgs e)
        {
            
        }

        private void GridViewProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        /// <summary>
        /// 
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
        private Producto FromTextboxToObject()
        {
            Producto Arranged = new Producto();
            Arranged.IdProducto = int.Parse(TextboxId.Text);
            Arranged.Nombre = TextBoxNombre.Text;
            Arranged.Categoria = textBoxCategoria.Text;
            Arranged.Precio = int.Parse(textBoxPrecio.Text);
            Arranged.StockActual = int.Parse(textBoxStock.Text);
            Arranged.Vendidos = int.Parse(textBoxVendidos.Text);
           

            return Arranged;
        }

        /// <summary>
        /// Carga una imagen en la UI a partir del id del producto(Debe ser el mismo nombre en la carpeta imagenes)
        /// </summary>
        /// <param name="id">id del producto con el mism nombre que la imagen</param>
        private void cargarThumbnail(string id)
        {

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox.Image = Image.FromFile(string.Format(@"C:\Users\Fran\source\repos\ProgLogica2020\ProgLogica202\ConstruccionesForm\img\" + id + ".jpg"));
            }
            catch (FileNotFoundException)
            {
                pictureBox.Image = Image.FromFile(string.Format(@"C:\Users\Fran\source\repos\ProgLogica2020\ProgLogica202\ConstruccionesForm\img\notFound.jpg"));
            }
            
        }

        private void TextBoxPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if(!string.IsNullOrEmpty(TextboxId.Text))
            {
                flag = inventario.EliminarProducto(int.Parse(TextboxId.Text));
            }
            else if(!string.IsNullOrEmpty(TextBoxNombre.Text))
            {
               flag = inventario.EliminarProducto(TextBoxNombre.Text);
            }
            

            if (flag)
            {
                CargarEnGrid(inventario.MostrarTodos());
            }

               

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            Producto prod = FromTextboxToObject();
            inventario.AgregarNuevoProducto(prod);
            CargarEnGrid(inventario.MostrarTodos());
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Producto prod = FromTextboxToObject();
            inventario.ModificarProducto(int.Parse(TextboxId.Text), prod);
            CargarEnGrid(inventario.MostrarTodos());
        }

        private void labelFacturacion_Click(object sender, EventArgs e)
        {

        }

        private void buttonStockZero_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('A'));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('B'));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunStock('C'));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Producto encontrado = inventario.ProductoMasVendido();
            List<Producto> prods = new List<Producto>
            {
                encontrado
            };

            CargarEnGrid(prods);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CargarEnGrid(inventario.MostrarSegunCategoria());
        }
    }
}

