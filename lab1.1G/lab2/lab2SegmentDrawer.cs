using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1._1G
{
    public partial class lab2SegmentDrawer : Form
    {
        public int xn, yn, xk, yk;

        public lab2SegmentDrawer()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели координаты начала отрезка!");
            }
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Вы не ввели координаты конца отрезка!");
            }
            xn = Int16.Parse(textBox1.Text);
            yn = Int16.Parse(textBox2.Text);
            xk = Int16.Parse(textBox3.Text);
            yk = Int16.Parse(textBox4.Text);
        }
    }
}
