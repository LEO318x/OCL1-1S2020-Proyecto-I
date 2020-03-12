namespace OCL1_1S2020_Proyecto_I
{
    partial class Form1
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.groupBoxSalida = new System.Windows.Forms.GroupBox();
            this.groupBoxAFD = new System.Windows.Forms.GroupBox();
            this.groupBoxTablaTransiciones = new System.Windows.Forms.GroupBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarThompsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresLéxicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(12, 68);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(521, 340);
            this.tabControl.TabIndex = 1;
            // 
            // groupBoxSalida
            // 
            this.groupBoxSalida.Location = new System.Drawing.Point(12, 414);
            this.groupBoxSalida.Name = "groupBoxSalida";
            this.groupBoxSalida.Size = new System.Drawing.Size(521, 93);
            this.groupBoxSalida.TabIndex = 2;
            this.groupBoxSalida.TabStop = false;
            this.groupBoxSalida.Text = "Salida";
            // 
            // groupBoxAFD
            // 
            this.groupBoxAFD.Location = new System.Drawing.Point(540, 92);
            this.groupBoxAFD.Name = "groupBoxAFD";
            this.groupBoxAFD.Size = new System.Drawing.Size(381, 217);
            this.groupBoxAFD.TabIndex = 3;
            this.groupBoxAFD.TabStop = false;
            this.groupBoxAFD.Text = "AFD";
            // 
            // groupBoxTablaTransiciones
            // 
            this.groupBoxTablaTransiciones.Location = new System.Drawing.Point(540, 315);
            this.groupBoxTablaTransiciones.Name = "groupBoxTablaTransiciones";
            this.groupBoxTablaTransiciones.Size = new System.Drawing.Size(381, 192);
            this.groupBoxTablaTransiciones.TabIndex = 4;
            this.groupBoxTablaTransiciones.TabStop = false;
            this.groupBoxTablaTransiciones.Text = "Tabla Transiciones";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(540, 44);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(80, 25);
            this.btnAnalizar.TabIndex = 5;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.archivoToolStripMenuItem, this.herramientasToolStripMenuItem, this.reportesToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.abrirToolStripMenuItem, this.guardarToolStripMenuItem, this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.cargarThompsonToolStripMenuItem, this.guardarTokensToolStripMenuItem,
                this.guardarErroresToolStripMenuItem
            });
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // cargarThompsonToolStripMenuItem
            // 
            this.cargarThompsonToolStripMenuItem.Name = "cargarThompsonToolStripMenuItem";
            this.cargarThompsonToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cargarThompsonToolStripMenuItem.Text = "Cargar Thompson";
            // 
            // guardarTokensToolStripMenuItem
            // 
            this.guardarTokensToolStripMenuItem.Name = "guardarTokensToolStripMenuItem";
            this.guardarTokensToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.guardarTokensToolStripMenuItem.Text = "Guardar Tokens";
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.guardarErroresToolStripMenuItem.Text = "Guardar Errores";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.erroresLéxicosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "&Reportes";
            // 
            // erroresLéxicosToolStripMenuItem
            // 
            this.erroresLéxicosToolStripMenuItem.Name = "erroresLéxicosToolStripMenuItem";
            this.erroresLéxicosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.erroresLéxicosToolStripMenuItem.Text = "&Errores Léxicos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.groupBoxTablaTransiciones);
            this.Controls.Add(this.groupBoxAFD);
            this.Controls.Add(this.groupBoxSalida);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTablaTransiciones;
        private System.Windows.Forms.GroupBox groupBoxAFD;
        private System.Windows.Forms.GroupBox groupBoxSalida;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarThompsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresLéxicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnAnalizar;
    }
}