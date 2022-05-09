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
    public partial class CG : Form
    {
        public CG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab_1 lab1 = new Lab_1();
            lab1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lab2 lab2 = new lab2();
            lab2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab3 lab3 = new Lab3();
            lab3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab4 lab4 = new Lab4();
            lab4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lab5 lab5 = new Lab5();
            lab5.Show();
        }
    }
}
