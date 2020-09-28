namespace ConstruccionesForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridViewProductos = new System.Windows.Forms.DataGridView();
            this.ButtonCargar = new System.Windows.Forms.Button();
            this.ButtonFacturacion = new System.Windows.Forms.Button();
            this.TextboxId = new System.Windows.Forms.TextBox();
            this.TextBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxVendidos = new System.Windows.Forms.TextBox();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxCategoria = new System.Windows.Forms.TextBox();
            this.labelFacturacion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonStockZero = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewProductos
            // 
            this.GridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProductos.Location = new System.Drawing.Point(354, 35);
            this.GridViewProductos.Name = "GridViewProductos";
            this.GridViewProductos.RowHeadersWidth = 51;
            this.GridViewProductos.RowTemplate.Height = 24;
            this.GridViewProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewProductos.Size = new System.Drawing.Size(1008, 355);
            this.GridViewProductos.TabIndex = 0;
            this.GridViewProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.GridViewProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewProductos_CellDoubleClick);
            this.GridViewProductos.SelectionChanged += new System.EventHandler(this.GridViewProductos_SelectionChanged_1);
            this.GridViewProductos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridViewProductos_MouseClick);
            // 
            // ButtonCargar
            // 
            this.ButtonCargar.Location = new System.Drawing.Point(175, 30);
            this.ButtonCargar.Name = "ButtonCargar";
            this.ButtonCargar.Size = new System.Drawing.Size(82, 23);
            this.ButtonCargar.TabIndex = 1;
            this.ButtonCargar.Text = "Refrescar";
            this.ButtonCargar.UseVisualStyleBackColor = true;
            this.ButtonCargar.Click += new System.EventHandler(this.ButtonCargar_Click);
            // 
            // ButtonFacturacion
            // 
            this.ButtonFacturacion.Location = new System.Drawing.Point(6, 292);
            this.ButtonFacturacion.Name = "ButtonFacturacion";
            this.ButtonFacturacion.Size = new System.Drawing.Size(166, 23);
            this.ButtonFacturacion.TabIndex = 3;
            this.ButtonFacturacion.Text = "Por Facturacion:";
            this.ButtonFacturacion.UseVisualStyleBackColor = true;
            this.ButtonFacturacion.Click += new System.EventHandler(this.ButtonFacturacion_Click);
            // 
            // TextboxId
            // 
            this.TextboxId.Location = new System.Drawing.Point(4, 102);
            this.TextboxId.Name = "TextboxId";
            this.TextboxId.Size = new System.Drawing.Size(48, 22);
            this.TextboxId.TabIndex = 5;
            // 
            // TextBoxNombre
            // 
            this.TextBoxNombre.Location = new System.Drawing.Point(2, 55);
            this.TextBoxNombre.Name = "TextBoxNombre";
            this.TextBoxNombre.Size = new System.Drawing.Size(167, 22);
            this.TextBoxNombre.TabIndex = 6;
            this.TextBoxNombre.TextChanged += new System.EventHandler(this.TextBoxPrecio_TextChanged);
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(2, 151);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(76, 22);
            this.textBoxPrecio.TabIndex = 7;
            this.textBoxPrecio.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(3, 82);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 17);
            this.labelId.TabIndex = 15;
            this.labelId.Text = "Id:";
            // 
            // textBoxVendidos
            // 
            this.textBoxVendidos.Location = new System.Drawing.Point(2, 199);
            this.textBoxVendidos.Name = "textBoxVendidos";
            this.textBoxVendidos.Size = new System.Drawing.Size(76, 22);
            this.textBoxVendidos.TabIndex = 16;
            this.textBoxVendidos.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(95, 151);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(74, 22);
            this.textBoxStock.TabIndex = 17;
            this.textBoxStock.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Vendidos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Facturacion:";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(2, 229);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(107, 30);
            this.buttonAgregar.TabIndex = 26;
            this.buttonAgregar.Text = "Agregar ";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(131, 229);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(100, 30);
            this.buttonModificar.TabIndex = 27;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(249, 229);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(99, 30);
            this.buttonEliminar.TabIndex = 28;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(175, 55);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(173, 166);
            this.pictureBox.TabIndex = 29;
            this.pictureBox.TabStop = false;
            // 
            // textBoxCategoria
            // 
            this.textBoxCategoria.Location = new System.Drawing.Point(71, 102);
            this.textBoxCategoria.Name = "textBoxCategoria";
            this.textBoxCategoria.Size = new System.Drawing.Size(98, 22);
            this.textBoxCategoria.TabIndex = 8;
            this.textBoxCategoria.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelFacturacion
            // 
            this.labelFacturacion.AutoSize = true;
            this.labelFacturacion.Location = new System.Drawing.Point(91, 199);
            this.labelFacturacion.Name = "labelFacturacion";
            this.labelFacturacion.Size = new System.Drawing.Size(16, 17);
            this.labelFacturacion.TabIndex = 30;
            this.labelFacturacion.Text = "0";
            this.labelFacturacion.Click += new System.EventHandler(this.labelFacturacion_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Stock <100";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonStockZero
            // 
            this.buttonStockZero.Location = new System.Drawing.Point(175, 293);
            this.buttonStockZero.Name = "buttonStockZero";
            this.buttonStockZero.Size = new System.Drawing.Size(167, 23);
            this.buttonStockZero.TabIndex = 32;
            this.buttonStockZero.Text = "Prod. Sin Stock";
            this.buttonStockZero.UseVisualStyleBackColor = true;
            this.buttonStockZero.Click += new System.EventHandler(this.buttonStockZero_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 23);
            this.button3.TabIndex = 33;
            this.button3.Text = "Stock > 100";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 350);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "Prod. Mas vendido";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(176, 351);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 23);
            this.button5.TabIndex = 35;
            this.button5.Text = "Mostrar por categoria";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 449);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonStockZero);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelFacturacion);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.textBoxVendidos);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxCategoria);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.TextBoxNombre);
            this.Controls.Add(this.TextboxId);
            this.Controls.Add(this.ButtonFacturacion);
            this.Controls.Add(this.ButtonCargar);
            this.Controls.Add(this.GridViewProductos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewProductos;
        private System.Windows.Forms.Button ButtonCargar;
        private System.Windows.Forms.Button ButtonFacturacion;
        private System.Windows.Forms.TextBox TextboxId;
        private System.Windows.Forms.TextBox TextBoxNombre;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxVendidos;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxCategoria;
        private System.Windows.Forms.Label labelFacturacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonStockZero;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

