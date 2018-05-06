using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.Visible = true;
            txt.AutoSize = false;
            txt.Width = 44;
            txt.Height = 16;
            txt.Location = new Point(4, 4);
            txt.Show();
            panel1.Controls.Add(txt);
        }

        private void Form3_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
        }
    }
}
