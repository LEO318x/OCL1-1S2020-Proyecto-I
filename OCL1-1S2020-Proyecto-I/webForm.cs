using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCL1_1S2020_Proyecto_I
{
    public partial class webForm : Form
    {
        public webForm(string txtHtml)
        {
            InitializeComponent();
            cargarHtml(txtHtml);
        }

        public void cargarHtml(string html)
        {
            webBrowser1.DocumentText = html;
        }
    }
}
