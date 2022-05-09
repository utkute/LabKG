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

    public partial class SrLab5 : Form
    {
        const double maxValue = 3;
        const double minValue = -3;
        double[,] function;
        double step = 0.5;
        int shift = 5;
        double[,] perenos = new double[4, 4];
        double[,] vrashOX = new double[4, 4];
        double fi = 30;
        double n1, n2, n3;
        int oX, oY, oZ;
        int p, q, r;
        double mX, mY, mZ;
        double s = 1;
        int v1, v2, v3, v4, v5, v6, v7;
        double x1, x2, x3, y1, y2, y3, z1, z2, z3;
        double[,] mash = new double[4, 4];
        Color curentColor = Color.Blue;
        int penSize = 2;
        private void Init_Mash()
        {
            mash[0, 0] = mX; mash[0, 1] = 0; mash[0, 2] = 0; mash[0, 3] = 0;
            mash[1, 0] = 0; mash[1, 1] = mY; mash[1, 2] = 0; mash[1, 3] = 0;
            mash[2, 0] = 0; mash[2, 1] = 0; mash[2, 2] = mZ; mash[2, 3] = 0;
            mash[3, 0] = 0; mash[3, 1] = 0; mash[3, 2] = 0; mash[3, 3] = s;
        }
    private void Init_Function()
        {
            double h = 2;
            int curent =0;
            function = new double[(int)Math.Pow((Math.Abs(maxValue - minValue) / step),2), 4];
            for (double i = -3; i < 3; i+=step)
            {
                for (double j = -3; j < 3; j+=step)
                {
                    function[curent, 0] = i;
                    function[curent, 1] = j;
                    function[curent, 2] = Math.Pow(Math.E, Math.Sin(function[curent, 0]) + Math.Pow(function[curent, 1], 2));
                    function[curent, 3] = 1;
                    curent++;
                }
            }
            for (int i = 0; i < function.GetLength(0); i++)
            {
                function[i, 0] *= 20;
                function[i, 1] *= 20;
                function[i, 2] *= 20;
            }
        }
        private void Init_Perenos(int p, int q, int r)
        {
            perenos[0, 0] = oX; perenos[0, 1] = 0; perenos[0, 2] = 0; perenos[0, 3] = 0;
            perenos[1, 0] = 0; perenos[1, 1] = oY; perenos[1, 2] = 0; perenos[1, 3] = 0;
            perenos[2, 0] = 0; perenos[2, 1] = 0; perenos[2, 2] = oZ; perenos[2, 3] = 0;
            perenos[3, 0] = p; perenos[3, 1] = q; perenos[3, 2] = r; perenos[3, 3] = 1;
        }

        private void Smeshenie(int step)
        {
            if (checkBox1.Checked == true)
            {
                p += step;
            }
            if (checkBox2.Checked == true)
            {
                q += step;
            }
            if (checkBox3.Checked == true)
            {
                r += step;
            }
            if (checkBox4.Checked == true)
            {
                p -= step;
            }
            if (checkBox5.Checked == true)
            {
                q -= step;
            }
            if (checkBox6.Checked == true)
            {
                r -= step;
            }
            if (checkBox1.Checked != true && checkBox2.Checked != true && checkBox3.Checked != true &&
                checkBox4.Checked != true && checkBox5.Checked != true && checkBox6.Checked != true)
            {
                MessageBox.Show("Вы не выбрали направление сдвига!");
            }
        }
        private double[,] Mashtab(double[,] matr)
        {
            Init_Mash();
            matr = Multiply_matr(matr, mash);
            if (mash[3, 3] != 1)
            {
                int n = matr.GetLength(0);
                int m = matr.GetLength(1);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = matr[i, j] / s;
                    }
                }
            }
            return matr;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            if (Math.Sqrt(Math.Pow(n1, 2) + Math.Pow(n3, 2) + Math.Pow(n2, 2)) != 1)
            {
                double vec = Math.Sqrt(Math.Pow(n1, 2) + Math.Pow(n3, 2) + Math.Pow(n2, 2));
                n1 = n1 / vec;
                n2 = n2 / vec;
                n3 = n3 / vec;
            }
            Init_Vrash();
            function = Multiply_matr(function, vrashOX);
            Draw_Function(curentColor);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "-")
            {
                n1 = double.Parse(textBox2.Text);
                label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != "-")
            {
                n2 = double.Parse(textBox3.Text);
                label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox4.Text != "-")
            {
                n3 = double.Parse(textBox4.Text);
                label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                curentColor = colorDialog1.Color;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                penSize = int.Parse(textBox6.Text);
                label14.Text = "Текущий размер линии: " + penSize.ToString();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox5.Text != "-")
            {
                label12.Text = "ф = " + double.Parse(textBox5.Text).ToString();
                fi = double.Parse(textBox5.Text);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                pictureBox1.Refresh();
                oX = 1;
                oY = 0;
                oZ = 1;
                Draw_Function(curentColor);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                pictureBox1.Refresh();
                oX = 0;
                oY = 1;
                oZ = 1;
                Draw_Function(curentColor);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pictureBox1.Refresh();
                oX = 1;
                oY = 1;
                oZ = 0;
                Draw_Function(curentColor);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Smeshenie(shift);
            Draw_Function(curentColor);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label2.Text = "Tекущий шаг: " + int.Parse(textBox1.Text).ToString();
                shift = int.Parse(textBox1.Text);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void Init_Vrash()
        {
            vrashOX[0, 0] = Math.Pow(n1, 2) + (1 - Math.Pow(n1, 2)) * Math.Cos((Math.PI * fi) / 180);
            vrashOX[0, 1] = n1 * n2 * (1 - Math.Cos((Math.PI * fi) / 180)) + n3 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[0, 2] = n1 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) - n2 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[0, 3] = 0;
            vrashOX[1, 0] = n1 * n2 * (1 - Math.Cos((Math.PI * fi) / 180)) - n3 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[1, 1] = Math.Pow(n2, 2) + (1 - Math.Pow(n2, 2)) * Math.Cos((Math.PI * fi) / 180);
            vrashOX[1, 2] = n2 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) + n1 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[1, 3] = 0;
            vrashOX[2, 0] = n1 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) + n2 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[2, 1] = n2 * n3 * (1 - Math.Cos((Math.PI * fi) / 180)) - n1 * Math.Sin((Math.PI * fi) / 180);
            vrashOX[2, 2] = Math.Pow(n3, 2) + (1 - Math.Pow(n3, 2)) * Math.Cos((Math.PI * fi) / 180);
            vrashOX[2, 3] = 0;
            vrashOX[3, 0] = 0;
            vrashOX[3, 1] = 0;
            vrashOX[3, 2] = 0;
            vrashOX[3, 3] = 1;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckForTrack();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked != true)
            {
                x1 = ((double)trackBar2.Value / 5);
                v1 = trackBar2.Value;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                x2 = ((double)trackBar2.Value / 5);
                y1 = ((double)trackBar2.Value / 5);
                v2 = trackBar2.Value;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                x3 = ((double)trackBar2.Value / 5);
                z1 = ((double)trackBar2.Value / 5);
                v3 = trackBar2.Value;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                y2 = ((double)trackBar2.Value / 5);
                v4 = trackBar2.Value;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                y3 = ((double)trackBar2.Value / 5);
                z2 = ((double)trackBar2.Value / 5);
                v5 = trackBar2.Value;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                z3 = ((double)trackBar2.Value / 5);
                v6 = trackBar2.Value;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                s = 1 / ((double)trackBar2.Value / 5);
                v7 = trackBar2.Value;
            }
            mX = x1 * x2 * x3;
            mY = y1 * y2 * y3;
            mZ = z1 * z2 * z3;
            Draw_Function(curentColor);
        }

        private double[,] Multiply_matr(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }
        public SrLab5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw_Function(curentColor);
        }
        
        private void Draw_Function(Color color)
        {
            int firstPoint = 0;
            int secondPoint = 1;
            if (oZ == 0)
            {
                p += pictureBox1.Width / 2;
                q += pictureBox1.Height / 2;
                firstPoint = 0;
                secondPoint = 1;
            }
            else if (oY == 0)
            {
                p += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
                firstPoint = 0;
                secondPoint = 2;
            }
            else if (oX == 0)
            {
                q += pictureBox1.Width / 2;
                r += pictureBox1.Height / 2;
                firstPoint = 1;
                secondPoint = 2;
            }
            Init_Perenos(p, q, r);
            double[,] matr = Mashtab(function);
            matr = Multiply_matr(matr, perenos);
            Point[] splain = new Point[function.GetLength(0)];
            for (int i =0; i < function.GetLength(0); i++)
            {
                splain[i].X = (int)matr[i, firstPoint];
                splain[i].Y = (int)matr[i, secondPoint];
            }
            Pen myPen = new Pen(color, penSize);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            for (int i = 0; i < function.GetLength(0)- (int)(Math.Abs(maxValue - minValue) / step); i++)
            {
           
                    g.DrawLine(myPen, splain[i].X, splain[i].Y, splain[i + 1].X, splain[i + 1].Y);
                    g.DrawLine(myPen, splain[i+1].X, splain[i+1].Y, splain[i + (int)(Math.Abs(maxValue - minValue) / step)].X, splain[i + (int)(Math.Abs(maxValue - minValue) / step)].Y);
                    g.DrawLine(myPen, splain[i + (int)(Math.Abs(maxValue - minValue) / step)].X, splain[i + (int)(Math.Abs(maxValue - minValue) / step)].Y, 
                        splain[i - 1 + (int)(Math.Abs(maxValue - minValue) / step)].X, splain[i - 1 + (int)(Math.Abs(maxValue - minValue) / step)].Y);
                    g.DrawLine(myPen, splain[i -1+ (int)(Math.Abs(maxValue - minValue) / step)].X, splain[i-1 + (int)(Math.Abs(maxValue - minValue) / step)].Y, splain[i].X, splain[i].Y);
                
            }
                
            if (oZ == 0)
            {
                p -= pictureBox1.Width / 2;
                q -= pictureBox1.Height / 2;
            }
            else if (oY == 0)
            {
                p -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
            else if (oX == 0)
            {
                q -= pictureBox1.Width / 2;
                r -= pictureBox1.Height / 2;
            }
        }
        private void CheckForTrack()
        {
            if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked != true)
            {
                trackBar2.Value = v1;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                trackBar2.Value = v2;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                trackBar2.Value = v3;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked != true)
            {
                trackBar2.Value = v4;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                trackBar2.Value = v5;
            }
            else if (checkBox7.Checked != true && checkBox8.Checked != true && checkBox9.Checked == true)
            {
                trackBar2.Value = v6;
            }
            else if (checkBox7.Checked == true && checkBox8.Checked == true && checkBox9.Checked == true)
            {
                trackBar2.Value = v7;
            }
        }

        private void SrLab5_Load(object sender, EventArgs e)
        {
            Init_Function();
            n1 = 1;
            n2 = 0;
            n3 = 0;
            label11.Text = "(" + n1.ToString() + ";" + n2.ToString() + ";" + n3.ToString() + ")";
            r = 0;
            p = 0;
            q = 0;
            mX = 1;
            mY = 1;
            mZ = 1;
            v1 = v2 = v3 = v4 = v5 = v6 = v7 = 5;
            x1 = x2 = x3 = y1 = y2 = y3 = z1 = z2 = z3 = 1;
            radioButton1.Checked = true;
            fi = 15;
            label12.Text = "ф = " + fi.ToString();
        }
    }
}
