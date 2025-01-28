using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using ChessUserControls;
using System.Diagnostics;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.set_control_parameters();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void set_control_parameters()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.Size = new System.Drawing.Size(250, 63);
        }
    }
}