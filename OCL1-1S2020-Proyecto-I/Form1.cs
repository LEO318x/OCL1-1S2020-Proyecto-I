using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCL1_1S2020_Proyecto_I
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            agregarTab();
            agregarTab();
        }

        private void agregarTab()
        {
            string nombre = "tab";
            TextBox txt = new TextBox();
            TabPage newTab = new TabPage(nombre);

            txt.Name = nombre;
            txt.Multiline = true;
            txt.Width = tabControl.Size.Width-6;
            txt.Height = tabControl.Size.Height-26;
            txt.BorderStyle = BorderStyle.None;
            txt.ScrollBars = ScrollBars.Vertical;

            newTab.Controls.Add(txt);
            tabControl.TabPages.Add(newTab);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var nombreArchivo = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivo ER (*.er)|*.er";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    nombreArchivo = openFileDialog.SafeFileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            

             tabControl.SelectedTab.Text = nombreArchivo;
             
             TextBox tmpTextBox = new TextBox();
             tmpTextBox = (TextBox) tabControl.SelectedTab.Controls["tab"];
             tmpTextBox.Text = fileContent;
             
             
            
            

            MessageBox.Show(nombreArchivo);

        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            //MessageBox.Show("Analizando...");
            TextBox tmptb;
            tmptb = (TextBox) tabControl.SelectedTab.Controls["tab"];
            //AnalisisLexico x = new AnalisisLexico(tmptb.Text);
            Analisis x = new Analisis(tmptb.Text);
            // x.imprimir();
            // x.imprimirError();
            //x.htmlT();
            x.htmlT();
            x.htmlE();
            //AnalisisER er = new AnalisisER();
            //er.analisis(x.getTablaTokens().getTablaT().getPrimero());

            Thompson t = new Thompson();
            t.Mas("a");

            //AnalisisER er = new AnalisisER();
            //er.analisisTokens(x.getTablaTokens());

            /*Thompson t = new Thompson();
            t.Or("a", "b");
            t.testOr();
            t.graficar();*/

        }
    }
}