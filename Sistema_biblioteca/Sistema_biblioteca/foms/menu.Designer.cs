namespace Sistema_biblioteca.foms
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUnLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarUnLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarUnEstudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarUnEstudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarLibrosPrestadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regresarUnLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.librosToolStripMenuItem,
            this.estudiantesToolStripMenuItem,
            this.consultarLibrosPrestadosToolStripMenuItem,
            this.regresarUnLibroToolStripMenuItem,
            this.informaciónGeneralToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUnLibroToolStripMenuItem,
            this.consultarUnLibroToolStripMenuItem});
            this.librosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("librosToolStripMenuItem.Image")));
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // agregarUnLibroToolStripMenuItem
            // 
            this.agregarUnLibroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("agregarUnLibroToolStripMenuItem.Image")));
            this.agregarUnLibroToolStripMenuItem.Name = "agregarUnLibroToolStripMenuItem";
            this.agregarUnLibroToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarUnLibroToolStripMenuItem.Text = "Agregar un libro";
            this.agregarUnLibroToolStripMenuItem.Click += new System.EventHandler(this.agregarUnLibroToolStripMenuItem_Click);
            // 
            // consultarUnLibroToolStripMenuItem
            // 
            this.consultarUnLibroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarUnLibroToolStripMenuItem.Image")));
            this.consultarUnLibroToolStripMenuItem.Name = "consultarUnLibroToolStripMenuItem";
            this.consultarUnLibroToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.consultarUnLibroToolStripMenuItem.Text = "Consultar un libro";
            this.consultarUnLibroToolStripMenuItem.Click += new System.EventHandler(this.consultarUnLibroToolStripMenuItem_Click);
            // 
            // estudiantesToolStripMenuItem
            // 
            this.estudiantesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarUnEstudianteToolStripMenuItem,
            this.consultarUnEstudianteToolStripMenuItem});
            this.estudiantesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("estudiantesToolStripMenuItem.Image")));
            this.estudiantesToolStripMenuItem.Name = "estudiantesToolStripMenuItem";
            this.estudiantesToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.estudiantesToolStripMenuItem.Text = "Estudiantes";
            // 
            // registrarUnEstudianteToolStripMenuItem
            // 
            this.registrarUnEstudianteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registrarUnEstudianteToolStripMenuItem.Image")));
            this.registrarUnEstudianteToolStripMenuItem.Name = "registrarUnEstudianteToolStripMenuItem";
            this.registrarUnEstudianteToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.registrarUnEstudianteToolStripMenuItem.Text = "Registrar un estudiante";
            this.registrarUnEstudianteToolStripMenuItem.Click += new System.EventHandler(this.registrarUnEstudianteToolStripMenuItem_Click);
            // 
            // consultarUnEstudianteToolStripMenuItem
            // 
            this.consultarUnEstudianteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarUnEstudianteToolStripMenuItem.Image")));
            this.consultarUnEstudianteToolStripMenuItem.Name = "consultarUnEstudianteToolStripMenuItem";
            this.consultarUnEstudianteToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.consultarUnEstudianteToolStripMenuItem.Text = "Consultar un estudiante";
            this.consultarUnEstudianteToolStripMenuItem.Click += new System.EventHandler(this.consultarUnEstudianteToolStripMenuItem_Click);
            // 
            // consultarLibrosPrestadosToolStripMenuItem
            // 
            this.consultarLibrosPrestadosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarLibrosPrestadosToolStripMenuItem.Image")));
            this.consultarLibrosPrestadosToolStripMenuItem.Name = "consultarLibrosPrestadosToolStripMenuItem";
            this.consultarLibrosPrestadosToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.consultarLibrosPrestadosToolStripMenuItem.Text = "Prestar un libro";
            this.consultarLibrosPrestadosToolStripMenuItem.Click += new System.EventHandler(this.consultarLibrosPrestadosToolStripMenuItem_Click);
            // 
            // regresarUnLibroToolStripMenuItem
            // 
            this.regresarUnLibroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("regresarUnLibroToolStripMenuItem.Image")));
            this.regresarUnLibroToolStripMenuItem.Name = "regresarUnLibroToolStripMenuItem";
            this.regresarUnLibroToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.regresarUnLibroToolStripMenuItem.Text = "Regresar un libro";
            this.regresarUnLibroToolStripMenuItem.Click += new System.EventHandler(this.regresarUnLibroToolStripMenuItem_Click);
            // 
            // informaciónGeneralToolStripMenuItem
            // 
            this.informaciónGeneralToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("informaciónGeneralToolStripMenuItem.Image")));
            this.informaciónGeneralToolStripMenuItem.Name = "informaciónGeneralToolStripMenuItem";
            this.informaciónGeneralToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.informaciónGeneralToolStripMenuItem.Text = "Información general";
            this.informaciónGeneralToolStripMenuItem.Click += new System.EventHandler(this.informaciónGeneralToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(820, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(260, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Biblioteca Don Bosco";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(325, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(201, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(202, 251);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(451, 223);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(202, 251);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(451, 223);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(202, 251);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(451, 223);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(202, 251);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(451, 223);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(202, 251);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(451, 223);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 8;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(847, 492);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENÚ - BIBLIOTECA DON BOSCO";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUnLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarUnLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarUnEstudianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarUnEstudianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarLibrosPrestadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regresarUnLibroToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ToolStripMenuItem informaciónGeneralToolStripMenuItem;
    }
}