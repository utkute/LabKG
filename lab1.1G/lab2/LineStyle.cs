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
    public partial class LineStyle : Form
    {
        public LineStyle()
        {
            InitializeComponent();
        }
        bool lineCheck = false;
        bool dashCheck = false;
        public int line;
        public int dash;
        public int size;
        public bool isDash;

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "true";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (lineCheck)
                {
                    label5.Text = "false";
                }
                dashCheck = true;
            }
            else
            {
                dashCheck = false;
                label5.Text = "true";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (dashCheck)
                {
                    label5.Text = "false";
                }
                lineCheck = true;
            }
            else
            {
                lineCheck = false;
                label5.Text = "true";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lineCheck && dashCheck)
            {
                isDash = true;
                line = Int16.Parse(textBox2.Text);
                dash = Int16.Parse(textBox3.Text);
            }
            else
            {
                isDash = false;
            }
            size = Int16.Parse(textBox1.Text);
        }
    }
}
