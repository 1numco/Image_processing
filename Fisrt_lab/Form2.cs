using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fisrt_lab
{
    public partial class Form2 : Form
    {
        private int firstDim;
        private int secondDim;
        private TextBox[,] MatrText = null;
        public int[,] kernel = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstDim = Convert.ToInt32(textBox1.Text);
            secondDim = Convert.ToInt32(textBox2.Text);
            int dx = 40, dy = 20;
            MatrText = new TextBox[firstDim, secondDim];
            for (int i = 0; i != firstDim; ++i)
                for (int j = 0; j != secondDim; ++j)
                {
                    MatrText[i, j] = new TextBox();
                    MatrText[i, j].Text = "0";
                    MatrText[i, j].Location = new System.Drawing.Point(200 + i * dx, 50 + j * dy);
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    Controls.Add(MatrText[i, j]);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kernel = new int[firstDim, secondDim];
            for (int i = 0; i != firstDim; ++i)
                for (int j = 0; j != secondDim; ++j)
                {
                    kernel[i, j] = Convert.ToInt32(MatrText[i, j].Text);
                }
            this.Visible = false;
        }
    }
}
